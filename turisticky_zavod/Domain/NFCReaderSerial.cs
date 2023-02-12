using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using turisticky_zavod.Data;

namespace turisticky_zavod.Domain
{
    public class NFCReaderSerial
    {
        private SerialPort serialPort = new();

        public NFCReaderSerial()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (!serialPort.IsOpen)
            {
                serialPort = new()
                {
                    PortName = SerialPort.GetPortNames().Last(),
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };
                serialPort.Open();
                serialPort.ReadTimeout = 2000;
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(idk);
            }
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
                    string block;
                    try
                    {
                        block = ReadBlock(i);
                    }
                    catch (Exception)
                    {
                        i += i == 1 ? 3 : 4;
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

            var runner_split = all_str.Split(";");
            var runner = new Runner()
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

            return runner;
        }

        private void SendKeyToReader()
        {
            Thread.Sleep(100);
            serialPort.Write(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0, 11);
        }

        private bool AuthenticateBlock(int block)
        {
            Thread.Sleep(100);
            serialPort.Write(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, (byte)block, 0x60, 0x00 }, 0, 10);
            Thread.Sleep(100);
            byte[] buffer = new byte[18];
            serialPort.Read(buffer, 0, 18);

            return DetectResult(buffer, 18);
        }

        private string ReadBlock(int block)
        {
            Thread.Sleep(100);
            serialPort.Write(new byte[] { 0xFF, 0xB0, 0x00, (byte)block, 0x10 }, 0, 5);
            byte[] buffer = new byte[18];
            Thread.Sleep(100);
            serialPort.Read(buffer, 0, 18);
            if (!DetectResult(buffer, 18))
                throw new Exception("Reading failed");
            return Encoding.GetEncoding("iso-8859-2")
                .GetString(buffer.Take(16).TakeWhile(b => b != 0x00).ToArray());
        }

        private bool WriteToBlock(int block, byte[] data)
        {
            var reader_data = new byte[21];
            new byte[] { 0xFF, 0xD6, 0x00, (byte)block, 0x10 }.CopyTo(reader_data, 0);
            data.CopyTo(reader_data, 5);
            Thread.Sleep(100);
            serialPort.Write(reader_data, 0, reader_data.Length);
            byte[] buffer = new byte[2];
            Thread.Sleep(100);
            serialPort.Read(buffer, 0, 2);
            return buffer[0] == 0x90 && buffer[1] == 0x00;
        }

        private bool DetectResult(byte[] data, int length)
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

        ~NFCReaderSerial()
        {
            serialPort.Dispose();
        }
    }
}
