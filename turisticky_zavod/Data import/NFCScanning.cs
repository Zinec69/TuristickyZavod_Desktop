using Forms.Properties;
using PCSC.Monitoring;
using System.Diagnostics;
using System.ServiceProcess;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;

namespace turisticky_zavod.Forms
{
    public partial class NFCScanning : Form
    {
        private readonly NFCReaderPCSC Reader;
        //private readonly NFCReaderSerial ReaderSerial = new();

        public event EventHandler<Runner> OnRunnerNotInDB;

        private readonly Database database;

        private readonly Image nfcOn = Resources.nfc_on;
        private readonly Image nfcOff = Resources.nfc_off;

        public NFCScanning()
        {
            InitializeComponent();

            database = Database.Instance;

            try
            {
                Reader = new NFCReaderPCSC();

                if (!Reader.Connect())
                {
                    pictureBox_nfcIcon.Image = nfcOff;
                    readerStatusTextVar.Text = "Nenalezena";

                    Log("Reader not found", "Nfc reader");
                }
                else
                {
                    pictureBox_nfcIcon.Image = nfcOn;
                    readerStatusTextVar.Text = "Připravena";
                    Reader.OnCardDetected += OnTagDiscovered;

                    Log("Reader ready", "Nfc reader");
                }
                Reader.OnReaderDisconnected += (_, _) =>
                {
                    Invoke(() =>
                    {
                        pictureBox_nfcIcon.Image = nfcOff;
                        readerStatusTextVar.Text = "Odpojena";

                        Log("Reader disconnected", "Nfc reader");
                    });
                };
                Reader.OnReaderReconnected += (_, _) =>
                {
                    Reader.OnCardDetected += OnTagDiscovered;
                    pictureBox_nfcIcon.Invoke(() =>
                    {
                        pictureBox_nfcIcon.Image = nfcOn;
                        readerStatusTextVar.Text = "Připojena";

                        Log("Reader reconnected", "Nfc reader");
                    });
                };
            }
            catch (PCSC.Exceptions.NoServiceException)
            {
                Log("Reader drivers not found", "Nfc reader");

                if (MessageBox.Show($"Nepodařila se spustit služba pro komunikaci s chytrými čtečkami. Chcete ji nyní nainstalovat?",
                    "Chyba", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    try
                    {
                        var setupProcess = Process.Start($"{Directory.GetCurrentDirectory()}/PCSC_Drivers/Setup.exe");
                        setupProcess.WaitForExit();

                        var scardService = new ServiceController("SCardSvr");
                        if (scardService.Status != ServiceControllerStatus.Running)
                        {
                            MessageBox.Show("Není spuštěna služba pro komunikaci s chytrými čtečkami. " +
                                "Zkuste vypnout aplikaci, přepojit čtečku a znovu spustit aplikaci.",
                                "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nastala neočekávaná chyba při instalaci a spouštění služby",
                            "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Close();
            }

            //if (ReaderSerial.Connect())
            //    button_scanSerialPort.Enabled = true;

            //ReaderSerial.OnReaderReconnected += (_, _) => Invoke(() => button_scanSerialPort.Enabled = true);
        }

        private void OnTagDiscovered(object? sender, CardStatusEventArgs args)
        {
            if (!NFCReaderPCSC.CheckTagCompatibility(args.Atr))
            {
                MessageBox.Show("Nepodporovaný typ čipu",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var timer = Stopwatch.StartNew();

            try
            {
                var runner = Reader.ReadRunnerFromTag();
                timer.Stop();
                SaveRunner(runner);
                toolStripStatusLabel.Text = $"Běžec č. {runner.StartNumber} úspěšně načten";
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

        private void SaveRunner(Runner runner)
        {
            Invoke(() =>
            {
                var dbRunner = database.Runner.Where(r => r.StartNumber == runner.StartNumber).FirstOrDefault();

                if (dbRunner == default)
                    OnRunnerNotInDB?.Invoke(null, runner);
                else
                {
                    dbRunner.StartTime ??= runner.StartTime;
                    dbRunner.FinishTime ??= runner.FinishTime;
                    foreach (var ci in runner.CheckpointInfo)
                    {
                        if (!dbRunner.CheckpointInfo.Any(c => c.Checkpoint.ID == ci.Checkpoint.ID))
                        {
                            dbRunner.CheckpointInfo.Add(ci);
                        }
                    }
                    database.Runner.Update(dbRunner);
                    database.SaveChanges();
                }
            });
        }

        //private void Button_ScanSerialPort_Click(object sender, EventArgs e)
        //{
        //    var timer = Stopwatch.StartNew();

        //    try
        //    {
        //        var runner = ReaderSerial.ReadRunner();
        //        timer.Stop();
        //        SaveRunner(runner);
        //        toolStripStatusLabel.Text = $"Běžec č. {runner.StartNumber} úspěšně načten [{timer.ElapsedMilliseconds}ms]";
        //    }
        //    catch (NFCException ex)
        //    {
        //        toolStripStatusLabel.Text = ex.Message;
        //    }
        //    catch
        //    {
        //        toolStripStatusLabel.Text = $"Nastala neočekávaná chyba, zkuste to prosím znovu";
        //    }
        //}

        private void NFCScanning_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;

            Reader?.Dispose();
            //ReaderSerial?.Dispose();
        }

        private void Log(string message, string type)
        {
            database.Log.Add(new Log
            {
                Message = message,
                Type = type
            });
            database.SaveChanges();
        }
    }
}
