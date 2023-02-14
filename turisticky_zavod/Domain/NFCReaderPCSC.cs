using MiFare.Classic;
using PCSC;
using PCSC.Monitoring;
using System.Text;
using turisticky_zavod.Data;

namespace turisticky_zavod.Domain
{
    public class NFCReaderPCSC
    {
        private ISCardMonitor Monitor;
        private string ReaderName;

        public NFCReaderPCSC()
        {
            var readers = GetReaderNames();
            if (readers.Length < 1)
                throw new Exception("Čtečka nenalezena");

            Monitor = MonitorFactory.Instance.Create(SCardScope.System);

            //Monitor.StatusChanged += (sender, args) => MessageBox.Show($"Reader monitor status changed\nLast: {args.LastState}\nNew: {args.NewState}");
            Monitor.MonitorException += (sender, args) => MessageBox.Show($"Reader monitor exception: {args.Message}");
            //Monitor.Initialized += (sender, args) => MessageBox.Show($"\"{args.ReaderName}\" successfully initialized, state: {args.State}");

            ReaderName = readers.FirstOrDefault(s => s.Contains("PICC"), readers[0]);
            Monitor.Start(ReaderName);
        }

        public Runner ReadRunnerFromTag()
        {
            string all_str = "";
            int i = 1, count = -1;
            int starting_block = 0, num_of_blocks = 0;
            using (var context = ContextFactory.Instance.Establish(SCardScope.System))
            {
                using (var reader = context.ConnectReader(ReaderName, SCardShareMode.Shared, SCardProtocol.Any))
                {
                    LoadAuthenticationKey(reader);

                    while (i < 64)
                    {
                        int blocks_in_sector = GetBlocksInSector(GetBlockSector(i));
                        if ((i + 1) % blocks_in_sector == 0)
                        {
                            i++;
                            continue;
                        }

                        if (AuthenticateBlock(reader, i))
                        {
                            if (!ReadBlock(reader, i, out string block))
                            {
                                i++;
                                continue;
                            }

                            if (count < 0)
                            {
                                count = int.Parse(block);
                                starting_block = i;
                                num_of_blocks = count;
                            }
                            else
                            {
                                all_str += block;
                            }

                            i++;
                            if (--count < 0) break;
                        }
                        else
                        {
                            i += i == 1 ? blocks_in_sector - 1 : blocks_in_sector;
                        }
                    }

                    if (!EraseTag(reader, starting_block, num_of_blocks))
                        throw new Exception("Nepodařilo se vymazat čip");
                }
            }

            if (count > 0)
                throw new Exception("Nepodařilo se z čipu přečíst všechny informace");

            var runner_split = all_str.Split(";");
            var name = runner_split[1].Split(' ');
            return new Runner()
            {
                ID = int.Parse(runner_split[0]),
                FirstName = name[0],
                LastName = name[1],
                Team = runner_split[2],
                StartTime = long.Parse(runner_split[3]),
                FinishTime = runner_split[4] == "0" ? null : long.Parse(runner_split[4]),
                TimeWaited = int.Parse(runner_split[5]),
                PenaltySeconds = int.Parse(runner_split[6]),
                Disqualified = runner_split[7] == "1"
            };
        }

        private static bool EraseTag(ICardReader reader, int starting_block, int num_of_blocks)
        {
            var data = new byte[16];
            int i = starting_block, count = num_of_blocks;
            while (i < 64 && count >= 0)
            {
                int blocks_in_sector = GetBlocksInSector(GetBlockSector(i));
                if ((i + 1) % blocks_in_sector == 0)
                {
                    i++;
                    continue;
                }
                if (AuthenticateBlock(reader, i))
                {
                    if (UpdateBlock(reader, i++, data))
                        count--;
                }
                else
                    i += i == 1 ? blocks_in_sector - 1 : blocks_in_sector;
            }

            return true;
        }

        private static bool LoadAuthenticationKey(ICardReader reader)
        {
            var buffer = new byte[2];
            reader.Transmit(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, buffer);

            return buffer[0] == 0x90 && buffer[1] == 0x00;
        }

        private static bool AuthenticateBlock(ICardReader reader, int block)
        {
            var buffer = new byte[2];
            reader.Transmit(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, (byte)block, 0x60, 0x00 }, buffer);

            return buffer[0] == 0x90 && buffer[1] == 0x00;
        }

        private static bool ReadBlock(ICardReader reader, int block, out string result)
        {
            result = "";
            var buffer = new byte[18];
            reader.Transmit(new byte[] { 0xFF, 0xB0, 0x00, (byte)block, 0x10 }, buffer);

            if (!(buffer[16] == 0x90 && buffer[17] == 0x00))
                return false;

            result = Encoding.GetEncoding("iso-8859-2")
                     .GetString(buffer.Take(16).TakeWhile(b => b != 0x00).ToArray());

            return true;
        }

        private static bool UpdateBlock(ICardReader reader, int block, byte[] data)
        {
            if (data.Length != 16)
                return false;

            var buffer = new byte[2];
            var cmd = new byte[21];

            new byte[] { 0xFF, 0xD6, 0x00, (byte)block, 0x10 }.CopyTo(cmd, 0);
            data.CopyTo(cmd, 5);

            reader.Transmit(cmd, buffer);

            return buffer[0] == 0x90 && buffer[1] == 0x00;
        }

        private static int GetBlocksInSector(int sector) => sector < 32 ? 4 : 16;
        private static int GetBlockSector(int block) => block < 32 * 4 ? block / 4 : 32 + (block - 32 * 4) / 16;

        public void AddOnCardInserted(CardInsertedEvent event_handler) => Monitor.CardInserted += event_handler;
        public void AddOnCardRemoved(CardRemovedEvent event_handler) => Monitor.CardRemoved += event_handler;

        private static string[] GetReaderNames()
        {
            using var context = ContextFactory.Instance.Establish(SCardScope.System);

            return context.GetReaders();
        }

        ~NFCReaderPCSC()
        {
            Monitor.Cancel();
            Monitor.Dispose();
        }
    }
}
