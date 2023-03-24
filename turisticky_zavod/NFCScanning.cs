using PCSC.Monitoring;
using System.Diagnostics;
using turisticky_zavod.Data;
//using Usb.Events;
using turisticky_zavod.Logic;

namespace turisticky_zavod.Forms
{
    public partial class NFCScanning : Form
    {
        private readonly NFCReaderPCSC Reader = new();
        private NFCReaderSerial ReaderSerial = new();
        //private IUsbEventWatcher UsbEventWatcher = new UsbEventWatcher();

        public event EventHandler<Runner> OnRunnerNotInDB;

        private readonly Database database;

        public NFCScanning()
        {
            InitializeComponent();

            database = Database.Instance;

            try
            {
                if (!Reader!.Connect())
                {
                    readerStatusTextVar.Text = "Nenalezena";
                }
                else
                {
                    readerStatusTextVar.Text = "Připravena";
                    Reader.AddOnCardInserted(OnTagDiscovered);
                }

                //UsbEventWatcher.UsbDeviceRemoved += (_, _) => OnUSBDisconnected();
                //UsbEventWatcher.UsbDeviceAdded += (_, _) => OnUSBConnected();

                //Reader.Monitor.StatusChanged += (_, args) => MessageBox.Show(args.NewState.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show($"Nepodařila se spustit služba pro komunikaci s chytrými čtečkami. Podrobnosti:\n\n{e}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (ReaderSerial.Connect())
                button_scanSerialPort.Enabled = true;
        }

        private void OnTagDiscovered(object sender, CardStatusEventArgs args)
        {
            if (!NFCReaderPCSC.CheckTagCompatibility(args.Atr))
            {
                MessageBox.Show("Nepodporovaný typ čipu");
                return;
            }

            var timer = Stopwatch.StartNew();

            try
            {
                var runner = Reader.ReadRunnerFromTag();
                timer.Stop();
                Invoke(() =>
                {
                    var dbRunner = database.Runner.Where(r => r.RunnerID == runner.RunnerID).FirstOrDefault();

                    if (dbRunner == default)
                        OnRunnerNotInDB?.Invoke(null, runner);
                    else
                    {
                        dbRunner.StartTime = runner.StartTime;
                        dbRunner.FinishTime = runner.FinishTime;
                        dbRunner.Disqualified = runner.Disqualified;
                        foreach (var ci in runner.CheckpointInfo)
                        {
                            if (dbRunner.CheckpointInfo.FirstOrDefault(c => c.Checkpoint.CheckpointID == ci.Checkpoint.CheckpointID, null) == null)
                            {
                                dbRunner.CheckpointInfo.Add(ci);
                            }
                        }
                        database.Runner.Update(dbRunner);
                        database.SaveChanges();
                    }
                });
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

        private void NFCScanning_FormClosed(object sender, EventArgs e)
        {
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
                database.Runner.Add(runner);
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
