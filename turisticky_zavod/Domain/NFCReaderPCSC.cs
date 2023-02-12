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
            Monitor = MonitorFactory.Instance.Create(SCardScope.System);

            //Monitor.StatusChanged += (sender, args) => MessageBox.Show($"Reader monitor status changed\nLast: {args.LastState}\nNew: {args.NewState}");
            Monitor.MonitorException += (sender, args) => MessageBox.Show($"Reader monitor exception: {args.Message}");
            //Monitor.Initialized += (sender, args) => MessageBox.Show($"\"{args.ReaderName}\" successfully initialized, state: {args.State}");

            var readers = GetReaderNames();
            ReaderName = readers.FirstOrDefault(s => s.Contains("PICC"), readers[0]);
            Monitor.Start(ReaderName);
        }

        public Runner ReadRunnerFromTag()
        {
            string all_str = "";
            int i = 1, count = -1;
            using (var context = ContextFactory.Instance.Establish(SCardScope.System))
            {
                using (var reader = context.ConnectReader(ReaderName, SCardShareMode.Shared, SCardProtocol.Any))
                {
                    LoadAuthenticationKey(reader);

                    while (i < 64)
                    {
                        if ((i + 1) % 4 == 0)
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
                            i += i == 1 ? 3 : 4;
                        }
                    }
                }
            }

            if (count > 0)
                throw new Exception("Nepodařilo se z čipu přečíst všechny informace");

            var runner_split = all_str.Split(";");
            return new Runner()
            {
                ID = int.Parse(runner_split[0]),
                Name = runner_split[1],
                Team = runner_split[2],
                StartTime = long.Parse(runner_split[3]),
                FinishTime = runner_split[4] == "0" ? null : long.Parse(runner_split[4]),
                TimeWaited = int.Parse(runner_split[5]),
                PenaltySeconds = int.Parse(runner_split[6]),
                Disqualified = runner_split[7] == "1"
            };
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
