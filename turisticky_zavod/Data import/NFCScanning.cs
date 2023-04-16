using Forms.Properties;
using PCSC.Monitoring;
using System.Diagnostics;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;

namespace turisticky_zavod.Forms
{
    public partial class NFCScanning : Form
    {
        private readonly NFCReaderPCSC Reader = new();
        private readonly NFCReaderSerial ReaderSerial = new();

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
                if (!Reader.Connect())
                {
                    pictureBox_nfcIcon.Image = nfcOff;
                    readerStatusTextVar.Text = "Nenalezena";
                }
                else
                {
                    pictureBox_nfcIcon.Image = nfcOn;
                    readerStatusTextVar.Text = "Připravena";
                    Reader.OnCardDetected += OnTagDiscovered;
                }
                Reader.OnReaderDisconnected += (_, _) =>
                {
                    Invoke(() =>
                    {
                        pictureBox_nfcIcon.Image = nfcOff;
                        readerStatusTextVar.Text = "Odpojena";
                    });
                };
                Reader.OnReaderReconnected += (_, _) =>
                {
                    Reader.OnCardDetected += OnTagDiscovered;
                    pictureBox_nfcIcon.Invoke(() =>
                    {
                        pictureBox_nfcIcon.Image = nfcOn;
                        readerStatusTextVar.Text = "Připojena";
                    });
                };
            }
            catch (Exception e)
            {
                MessageBox.Show($"Nepodařila se spustit služba pro komunikaci s chytrými čtečkami. Podrobnosti:\n\n{e}",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            // TODO
            if (ReaderSerial.Connect())
                button_scanSerialPort.Enabled = true;

            ReaderSerial.OnReaderReconnected += (_, _) => Invoke(() => button_scanSerialPort.Enabled = true);
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
                toolStripStatusLabel.Text = $"Běžec č. {runner.StartNumber} úspěšně načten [{timer.ElapsedMilliseconds}ms]"; // TODO odebrat ms

                DialogResult = DialogResult.OK;
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
                    dbRunner.Disqualified = runner.Disqualified;
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

        private void NFCScanning_FormClosed(object sender, EventArgs e)
        {
            Reader?.Dispose();
            ReaderSerial?.Dispose();
        }

        private void Button_ScanSerialPort_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            try
            {
                var runner = ReaderSerial.ReadRunner();
                timer.Stop();
                SaveRunner(runner);
                toolStripStatusLabel.Text = $"Běžec č. {runner.StartNumber} úspěšně načten [{timer.ElapsedMilliseconds}ms]";
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
