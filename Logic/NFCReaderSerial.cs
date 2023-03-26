using System.IO.Ports;
using System.Management;
using System.Text;
using turisticky_zavod.Data;
using Usb.Events;

namespace turisticky_zavod.Logic
{
    public class NFCReaderSerial
    {
        private readonly IUsbEventWatcher UsbEventWatcher = new UsbEventWatcher();

        public event EventHandler OnReaderReconnected;

        private SerialPort serialPort = new();

        private List<byte[]> Data = new();
        private bool awaitingResponse = false;
        private int expectedResponseLength = 2;

        public NFCReaderSerial()
        {
            UsbEventWatcher.UsbDeviceAdded += (_, _) =>
            {
                if (!IsConnected() && Connect())
                    OnReaderReconnected?.Invoke(null, new());
            };
        }

        public bool Connect()
        {
            try
            {
                var serialDevices = new ManagementObjectSearcher("SELECT * FROM Win32_SerialPort").Get();

                foreach (var device in serialDevices)
                {
                    var name = Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(device["Name"].ToString().ToLower()));
                    if (!(name.Contains("usb") && name.Contains("seri")))
                        continue;

                    serialPort = new()
                    {
                        PortName = device["DeviceID"].ToString(),
                        BaudRate = 9600,
                        DataBits = 8,
                        Parity = Parity.None,
                        StopBits = StopBits.One,
                        ReadTimeout = 2000
                    };
                    serialPort.Open();
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedCallback);

                    return true;
                }
                
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void DataReceivedCallback(object sender, SerialDataReceivedEventArgs e)
        {
            var buffer = new byte[expectedResponseLength];
            for (int i = 0; i < expectedResponseLength; i++)
            {
                try
                {
                    buffer[i] = (byte)serialPort.ReadByte();
                }
                catch
                {
                    break;
                }
            }
            Data.Add(buffer);
            awaitingResponse = false;
        }
        
        public Runner ReadRunner()
        {
            SendKeyToReader();
            int i = 1, count = -1;
            string all_str = "";
            while (i < 64)
            {
                if ((i + 1) % 4 == 0)
                {
                    i++;
                    continue;
                }

                if (AuthenticateBlock(i))
                {
                    while ((i + 1) % 4 != 0)
                    {
                        string block = ReadBlock(i);

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
                    if (count < 0) break;
                }
                else
                {
                    SendKeyToReader();
                    i += i == 1 ? 3 : 4;
                }
            }

            var runner_split = all_str.Split(";");
            var name = runner_split[1].Split(' ');
            
            return new Runner()
            {
                RunnerID = int.Parse(runner_split[0]),
                FirstName = name[0],
                LastName = name[1],
                Team = runner_split[2],
                StartTime = new DateTime().AddSeconds(long.Parse(runner_split[3])),
                FinishTime = runner_split[4] == "0" ? null : new DateTime().AddSeconds(long.Parse(runner_split[4])),
                Disqualified = runner_split[5] == "1"
            };
        }

        private void SendKeyToReader()
        {
            expectedResponseLength = 2;
            awaitingResponse = true;
            serialPort.Write(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0, 11);

            while (awaitingResponse)
                Thread.Sleep(1);

            Data.RemoveAt(Data.Count - 1);
        }

        private bool AuthenticateBlock(int block)
        {
            expectedResponseLength = 2;
            awaitingResponse = true;
            serialPort.Write(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, (byte)block, 0x60, 0x00 }, 0, 10);

            while (awaitingResponse)
                Thread.Sleep(1);

            var buffer = Data.Last();
            Data.RemoveAt(Data.Count - 1);

            return DetectResult(buffer, expectedResponseLength);
        }

        private string ReadBlock(int block)
        {
            expectedResponseLength = 18;
            awaitingResponse = true;
            serialPort.Write(new byte[] { 0xFF, 0xB0, 0x00, (byte)block, 0x10 }, 0, 5);

            while (awaitingResponse)
                Thread.Sleep(1);

            var buffer = Data.Last();
            Data.RemoveAt(Data.Count - 1);

            if (!DetectResult(buffer, expectedResponseLength))
                throw new Exception();

            return Encoding.GetEncoding("iso-8859-2")
                    .GetString(buffer.Take(16).TakeWhile(b => b != 0x00).ToArray());
        }
        
        private bool WriteToBlock(int block, byte[] data)
        {
            var reader_data = new byte[21];
            new byte[] { 0xFF, 0xD6, 0x00, (byte)block, 0x10 }.CopyTo(reader_data, 0);
            data.CopyTo(reader_data, 5);

            expectedResponseLength = 2;
            awaitingResponse = true;
            serialPort.Write(reader_data, 0, reader_data.Length);

            while (awaitingResponse)
                Thread.Sleep(1);

            var buffer = Data.Last();
            Data.RemoveAt(Data.Count - 1);

            return buffer[0] == 0x90 && buffer[1] == 0x00;
        }

        private static bool DetectResult(byte[] data, int length)
        {
            for (int i = length - 2; i >= 0; i--)
            {
                if (data[i + 1] == 0x00 && data[i] == 0x90)
                    return true;

                if (data[i + 1] == 0x00 && data[i] == 0x63)
                    return false;
            }

            return false;
        }


        public bool IsConnected() => serialPort.IsOpen;

        public void Dispose()
        {
            serialPort.Dispose();
        }
    }
}
