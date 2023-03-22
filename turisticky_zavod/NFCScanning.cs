using PCSC.Monitoring;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Data;
using Usb.Events;
using Logic;

namespace Forms
{
    public partial class NFCScanning : Form
    {
        private NFCReaderPCSC Reader;
        private NFCReaderSerial ReaderSerial;
        private IUsbEventWatcher UsbEventWatcher = new UsbEventWatcher();

        private ObservableCollection<Runner> Runners = new();

        public NFCScanning()
        {
            InitializeComponent();

            try
            {
                Reader = new();

                if (!Reader!.Connect())
                {
                    readerStatusTextVar.Text = "Nenalezena";
                }
                else
                {
                    readerStatusTextVar.Text = "Připravena";
                    Reader.AddOnCardInserted(OnTagDiscovered);
                }

                UsbEventWatcher.UsbDeviceRemoved += (_, _) => OnUSBDisconnected();
                UsbEventWatcher.UsbDeviceAdded += (_, _) => OnUSBConnected();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Nepodařila se spustit služba pro komunikaci s chytrými čtečkami. Podrobnosti:\n\n{e}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            try
            {
                ReaderSerial = new();
                button_scanSerialPort.Enabled = true;
            }
            catch { }
        }

        private void OnTagDiscovered(object sender, CardStatusEventArgs args)
        {
            if (!Reader.CheckTagCompatibility(args.Atr))
            {
                MessageBox.Show("Nepodporovaný typ čipu");
                return;
            }

            var timer = Stopwatch.StartNew();

            try
            {
                var runner = Reader.ReadRunnerFromTag();
                timer.Stop();
                Runners.Add(runner);
                toolStripStatusLabel.Text = $"Běžec č. {runner.RunnerID} úspěšně načten [{timer.ElapsedMilliseconds}ms]";
            }
            catch (NFCException ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
            catch
            {
                toolStripStatusLabel.Text = $"Nastala neočekávaná chyba, zkuste to prosím znovu";
            }
        }

        private void OnUSBConnected()
        {
            if (!Reader.IsConnected())
            {
                if (Reader.Connect())
                {
                    readerStatusTextVar.Invoke(() => readerStatusTextVar.Text = "Připravena");
                    Reader.AddOnCardInserted(OnTagDiscovered);
                }
            }
            if (ReaderSerial == default)
            {
                try
                {
                    ReaderSerial = new();
                    button_scanSerialPort.Enabled = true;
                }
                catch { }
            }
        }

        private void OnUSBDisconnected()
        {
            if (!Reader.IsConnected())
            {
                readerStatusTextVar.Invoke(() => readerStatusTextVar.Text = "Odpojena");
            }
        }

        public void SubscribeToNewRunners(NotifyCollectionChangedEventHandler event_handler) => Runners.CollectionChanged += event_handler;

        private void NFCScanning_FormClosed(object sender, EventArgs e)
        {
            UsbEventWatcher?.Dispose();
            Reader?.Dispose();
            ReaderSerial?.Dispose();
        }

        private void button_scanSerialPort_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            try
            {
                var runner = ReaderSerial.ReadRunner();
                timer.Stop();
                Runners.Add(runner);
                toolStripStatusLabel.Text = $"Běžec č. {runner.RunnerID} úspěšně načten [{timer.ElapsedMilliseconds}ms]";
            }
            catch (NFCException ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
            catch
            {
                toolStripStatusLabel.Text = $"Nastala neočekávaná chyba, zkuste to prosím znovu";
            }
        }
    }
}
