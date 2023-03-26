using PCSC.Monitoring;
using System.Diagnostics;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;

namespace turisticky_zavod.Forms
{
    public partial class NFCScanning : Form
    {
        private readonly NFCReaderPCSC Reader = new();
        private NFCReaderSerial ReaderSerial = new();

        public event EventHandler<Runner> OnRunnerNotInDB;

        private readonly Database database;

        private readonly Image nfcOn = Image.FromFile("../../../Resources/nfc_icon.png");
        private readonly Image nfcOff = Image.FromFile("../../../Resources/nfc_off_icon.png");

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
                Reader.OnReaderDisconnected += (_, _) => Invoke(() =>
                {
                    pictureBox_nfcIcon.Image = nfcOff;
                    readerStatusTextVar.Text = "Odpojena";
                });
                Reader.OnReaderReconnected += (_, _) =>
                {
                    Reader.OnCardDetected += OnTagDiscovered;
                    Invoke(() =>
                    {
                        pictureBox_nfcIcon.Image = nfcOn;
                        readerStatusTextVar.Text = "Připojena";
                    });
                };
            }
            catch (Exception e)
            {
                MessageBox.Show($"Nepodařila se spustit služba pro komunikaci s chytrými čtečkami. Podrobnosti:\n\n{e}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (ReaderSerial.Connect())
                button_scanSerialPort.Enabled = true;

            ReaderSerial.OnReaderReconnected += (_, _) => Invoke(() => button_scanSerialPort.Enabled = true);
        }

        private void OnTagDiscovered(object? sender, CardStatusEventArgs args)
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
                // TODO
                // var runner = Reader.ReadRunnerFromTag(checkBox_eraseTag.Checked);
                timer.Stop();
                SaveRunner(runner);
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

        private void SaveRunner(Runner runner)
        {
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
                SaveRunner(runner);
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
