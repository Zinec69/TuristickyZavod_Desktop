using PCSC;
using PCSC.Monitoring;
using System.Text;
using Data;

namespace Logic
{
    public class NFCReaderPCSC
    {
        private ISCardMonitor Monitor;
        private string ReaderName;

        public SCRState State;
        private IntPtr controlCode = new(0x310000 + (3500 * 4));

        public NFCReaderPCSC()
        {
            Monitor = MonitorFactory.Instance.Create(SCardScope.System);

            Monitor.StatusChanged += (_, args) => State = args.NewState;
            Monitor.MonitorException += (_, args) =>
            {
                if (args.SCardError == SCardError.ServiceStopped || args.SCardError == SCardError.NoService)
                    Monitor.Cancel();
                //else
                    // TODO
                    //MessageBox.Show($"Reader monitor exception: {args.SCardError}");
            };
            Monitor.Initialized += (_, args) => State = args.State;
        }

        public bool Connect()
        {
            var readers = GetReaderNames();
            if (readers.Length > 0)
            {
                ReaderName = readers.FirstOrDefault(s => s.Contains("PICC"), readers[0]);
                Monitor.Start(ReaderName);

                using (var context = ContextFactory.Instance.Establish(SCardScope.System))
                {
                    using (var reader = context.ConnectReader(ReaderName, SCardShareMode.Direct, SCardProtocol.Unset))
                    {
                        var buffer = new byte[6];
                        try
                        {
                            reader.Control(controlCode, new byte[] { 0xE0, 0x00, 0x00, 0x21, 0x01, 0B_0110_1111 }, buffer);
                        }
                        catch { }
                    }
                }

                return true;
            }

            return false;
        }

        public Runner ReadRunnerFromTag(bool eraseAfterwards = false)
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
                            while ((i + 1) % blocks_in_sector != 0)
                            {
                                string block = ReadBlock(reader, i);

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
                            if (count < 0) break;
                        }
                        else
                        {
                            i += i == 1 ? blocks_in_sector - 1 : blocks_in_sector;
                        }
                    }

                    if (eraseAfterwards && !EraseTag(reader, starting_block, num_of_blocks))
                        throw new NFCException("Nepodařilo se vymazat čip");
                }
            }

            if (count > 0)
                throw new NFCException("Nepodařilo se z čipu přečíst všechna data");

            var runner_split = all_str.Split(";");
            var name = runner_split[1].Split(' ');

            if (runner_split.Length < 6)
                throw new NFCException("Data na čipu jsou nekompletní nebo ve špatném formátu");

            var checkpointInfos = new List<CheckpointRunnerInfo>();
            if (runner_split.Length > 6)
            {
                for (int j = 6; j < runner_split.Length; j += 6)
                {
                    checkpointInfos.Add(new CheckpointRunnerInfo()
                    {
                        Checkpoint = Database.Instance.Checkpoints.First(ch => ch.CheckpointID == int.Parse(runner_split[j])),
                        Referee = new() { Name = runner_split[j + 1] },
                        TimeArrived = long.Parse(runner_split[j + 2]) * 1000,
                        TimeDeparted = runner_split[j + 3] == "0" ? null : long.Parse(runner_split[j + 3]) * 1000,
                        TimeWaitedSeconds = int.Parse(runner_split[j + 4]),
                        PenaltySeconds = int.Parse(runner_split[j + 5])
                    });
                }
            }

            return new Runner()
            {
                RunnerID = int.Parse(runner_split[0]),
                FirstName = name[0],
                LastName = name[1],
                Team = runner_split[2],
                StartTime = long.Parse(runner_split[3]) * 1000,
                FinishTime = runner_split[4] == "0" ? null : long.Parse(runner_split[4]) * 1000,
                Disqualified = runner_split[5] == "1",
                CheckpointInfo = checkpointInfos
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

        private static string ReadBlock(ICardReader reader, int block)
        {
            var buffer = new byte[18];
            reader.Transmit(new byte[] { 0xFF, 0xB0, 0x00, (byte)block, 0x10 }, buffer);

            if (!(buffer[16] == 0x90 && buffer[17] == 0x00))
                throw new NFCException("Nastala chyba při čtení dat");

            return Encoding.GetEncoding("iso-8859-2")
                .GetString(buffer.Take(16).TakeWhile(b => b != 0x00).ToArray());
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

        public void Beep(ICardReader reader, int ms = 50)
        {
            var buffer = new byte[6];
            reader.Control(controlCode, new byte[] { 0xE0, 0x00, 0x00, 0x28, 0x01, (byte)(ms / 10) }, buffer);
        }

        private static int GetBlocksInSector(int sector) => sector < 32 ? 4 : 16;
        private static int GetBlockSector(int block) => block < 32 * 4 ? block / 4 : 32 + (block - 32 * 4) / 16;

        public void AddOnCardInserted(CardInsertedEvent event_handler)
        {
            if (Monitor.Monitoring)
                Monitor.CardInserted += event_handler;
        }

        public void AddOnCardRemoved(CardRemovedEvent event_handler)
        {
            if (Monitor.Monitoring)
                Monitor.CardRemoved += event_handler;
        }

        public bool CheckTagCompatibility(byte[] atr) => !(atr.Length < 15 || atr[13] != 0x00 || !(atr[14] == 0x01 || atr[14] == 0x02));
        public bool IsConnected() => Monitor != null && Monitor.Monitoring;

        private static string[] GetReaderNames()
        {
            using var context = ContextFactory.Instance.Establish(SCardScope.System);

            return context.GetReaders();
        }

        public void Dispose()
        {
            Monitor.Cancel();
            Monitor.Dispose();
        }
    }

    public class NFCException : Exception
    {
        public NFCException(string message) : base(message) { }
    }
}
