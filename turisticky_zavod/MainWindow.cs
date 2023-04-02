using System.ComponentModel;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using Microsoft.EntityFrameworkCore;
using Windows.Devices.WiFiDirect;
using System.Diagnostics;
using System.Collections.Concurrent;
using Windows.Networking.Sockets;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Forms;
using Windows.Storage.Streams;
using Windows.Devices.WiFiDirect.Services;
using Windows.Security.Cryptography;
using System.Security.Policy;
using Windows.Security.Credentials;
using System.Text;

namespace turisticky_zavod.Forms
{
    public partial class MainWindow : Form
    {
        private readonly Database database = Database.Instance;
        private readonly LogWindow logWindow = new();

        public MainWindow()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView1, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitDatabase();
            // TODO
            logWindow.Show();

            int? lmao = 5;
            var xd = lmao ?? -1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            database.Dispose();
            StopAdvertisement();
        }

        private void InitDatabase()
        {
            toolStripStatusLabel1.Text = "Naèítání databáze";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;

            new Thread(new ThreadStart(() =>
            {
                var timer = Stopwatch.StartNew();

                try
                {
                    database.Database.EnsureDeleted();
                    Log("[DATABASE] Deleting database");
                    database.Database.EnsureCreated();
                    Log("[DATABASE] Loading/creating database");

                    if (!this.IsDisposed)
                    {
                        Invoke(() =>
                        {
                            toolStripProgressBar1.Value += 20;
                            database.Runner.Load();
                            toolStripProgressBar1.Value += 20;
                            database.Partner.Load();
                            toolStripProgressBar1.Value += 10;
                            database.AgeCategory.Load();
                            toolStripProgressBar1.Value += 15;
                            database.Checkpoint.Load();
                            toolStripProgressBar1.Value += 15;
                            database.Referee.Load();
                            toolStripProgressBar1.Value += 10;
                            database.Team.Load();
                            toolStripProgressBar1.Value += 10;

                            dataGridView1.DataSource = database.Runner.Local.ToBindingList();
                        });
                    }

                    timer.Stop();
                    Log($"[DATABASE] Done loading database in {timer.ElapsedMilliseconds}ms");

                    Thread.Sleep(500);

                    if (!this.IsDisposed)
                    {
                        Invoke(() =>
                        {
                            toolStripStatusLabel1.Text = string.Empty;
                            toolStripProgressBar1.Visible = false;
                            toolStripProgressBar1.Value = 0;
                        });
                    }
                }
                catch (ObjectDisposedException ex) { }
                catch (InvalidOperationException ex) { }
            })).Start();
        }

        private async void AddRunnersCSV(string filepath)
        {
            try
            {
                var timer = Stopwatch.StartNew();

                var runners = FileHelper.LoadFromCSV(filepath);

                if (runners.Find(r => r.StartNumber != null) == null)
                {
                    var prompt = MessageBox.Show("Tato data nemají vyplnìna startovní èísla, chcete je pøiøadit automaticky?", "Pøiøadit startovní èísla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (prompt == DialogResult.Yes)
                    {
                        var ids = database.Runner.Local.Where(r => r.StartNumber.HasValue);
                        int i = ids.Any() ? ids.Max(r => r.StartNumber!.Value) : 0;
                        foreach (Runner runner in runners)
                        {
                            runner.StartNumber = ++i;
                        }
                    }
                }

                timer.Stop();
                Log($"[FILES] Loaded from csv in {timer.ElapsedMilliseconds}ms");
                timer.Restart();

                await database.Runner.AddRangeAsync(runners);

                timer.Stop();
                Log($"[FILES] Added to database in {timer.ElapsedMilliseconds}ms");
                timer.Restart();

                await database.SaveChangesAsync();

                timer.Stop();
                Log($"[FILES] Saved in database in {timer.ElapsedMilliseconds}ms");
            }
            catch
            {
                MessageBox.Show("Nepodaøilo se naèíst data z CSV souboru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AddRunnersJSON(string filepath)
        {
            try
            {
                var timer = Stopwatch.StartNew();

                var runners = FileHelper.LoadFromJSON(filepath);

                var jsonPickerWindow = new JsonPicker(runners);
                if (jsonPickerWindow.ShowDialog() == DialogResult.OK)
                {
                    var updatedRunners = new List<Runner>();
                    foreach (Runner runner in runners)
                    {
                        var current = database.Runner.Where(r => r.StartNumber == runner.StartNumber).FirstOrDefault();
                        if (current != default)
                        {
                            current.Disqualified = runner.Disqualified;
                            current.FinishTime = runner.FinishTime;
                            current.StartTime = runner.StartTime;
                            foreach (var ci in runner.CheckpointInfo)
                            {
                                if (current.CheckpointInfo.FirstOrDefault(c => c.Checkpoint.ID == ci.Checkpoint.ID, null) == null)
                                    current.CheckpointInfo.Add(ci);
                            }
                            updatedRunners.Add(current);
                            continue;
                        }
                    }

                    timer.Stop();
                    Log($"[FILES] Loaded from json in {timer.ElapsedMilliseconds}ms");
                    timer.Restart();

                    database.Runner.UpdateRange(updatedRunners);

                    timer.Stop();
                    Log($"[FILES] Updated database in {timer.ElapsedMilliseconds}ms");
                    timer.Restart();

                    await database.SaveChangesAsync();

                    timer.Stop();
                    Log($"[FILES] Saved in database in {timer.ElapsedMilliseconds}ms");
                }
            }
            catch
            {
                MessageBox.Show("Nepodaøilo se naèíst data z JSON souboru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnNFCScanned(object? sender, Runner runner)
        {
            var dialog = MessageBox.Show("Tento bìžec není v seznamu, chcete jej i pøesto pøidat? Nebude mít vyplnìna všechna data.", "Varování", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                database.Runner.Add(runner);
                database.SaveChanges();
            }
        }

        private void CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Soubory CSV (*.csv)|*.csv",
                Multiselect = false
            };
            fileDialog.FileOk += (_, _) => AddRunnersCSV(fileDialog.FileName);
            fileDialog.ShowDialog();
        }

        private void JSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Soubory JSON (*.json)|*.json",
                Multiselect = false
            };
            fileDialog.FileOk += (_, _) => AddRunnersJSON(fileDialog.FileName);
            fileDialog.ShowDialog();
        }

        private void NFCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nfcWindow = new NFCScanning();

            if (!nfcWindow.IsDisposed)
            {
                nfcWindow.OnRunnerNotInDB += OnNFCScanned;
                nfcWindow.ShowDialog();
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            Activate();

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                var filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                switch (filepath.Split('.').Last().ToLower())
                {
                    case "json":
                        var dialog = MessageBox.Show("Chcete naèíst data z JSON souboru?", "Naèíst data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                            AddRunnersJSON(filepath);
                        break;

                    case "csv":
                        dialog = MessageBox.Show("Chcete naèíst data z CSV souboru?", "Naèíst data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                            AddRunnersCSV(filepath);
                        break;

                    default:
                        MessageBox.Show("Nepodporovaný typ souboru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void toolStripMenuItem_ageCategories_Click(object sender, EventArgs e)
            => new AgeCategoriesEditor().ShowDialog();

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
                //row.HeaderCell.Value = ((BindingList<Runner>)dataGridView1.DataSource)[row.Index].ID.ToString();
            }
        }

        WiFiDirectAdvertisementPublisher? _publisher = null;
        WiFiDirectConnectionListener? _listener = null;

        private void toolStripMenuItem_test_Click(object sender, EventArgs e)
        {
            StopAdvertisement();
            StartAdvertisement();
        }

        private void StartAdvertisement()
        {
            _listener ??= new();
            _listener.ConnectionRequested += OnConnectionRequested;

            _publisher ??= new();
            _publisher.StatusChanged += OnStatusChanged;
            _publisher.Advertisement.IsAutonomousGroupOwnerEnabled = true;
            _publisher.Advertisement.ListenStateDiscoverability = WiFiDirectAdvertisementListenStateDiscoverability.Normal;

            _publisher.Start();
        }

        private void StopAdvertisement()
        {
            if (_publisher != null)
            {
                if (_publisher.Status == WiFiDirectAdvertisementPublisherStatus.Started)
                    _publisher.Stop();
                _publisher.StatusChanged -= OnStatusChanged;
                _publisher = null;
            }
            if (_listener != null)
            {
                _listener.ConnectionRequested -= OnConnectionRequested;
                _listener = null;
            }
        }

        private async void OnConnectionRequested(WiFiDirectConnectionListener sender, WiFiDirectConnectionRequestedEventArgs connectionEventArgs)
        {
            var request = connectionEventArgs.GetConnectionRequest();
            Log($"[WIFI DIRECT] New Wifi connection request:");
            Log($"[WIFI DIRECT]   Device name: {request.DeviceInformation.Name}");
            Log($"[WIFI DIRECT]   Device kind: {request.DeviceInformation.Kind}");

            var connectionParams = new WiFiDirectConnectionParameters();
            var devicePairingKinds = DevicePairingKinds.None;

            // If specific configuration methods were added, then use them.
            if (_publisher?.Advertisement.SupportedConfigurationMethods.Count > 0)
            {
                foreach (var configMethod in _publisher.Advertisement.SupportedConfigurationMethods)
                {
                    connectionParams.PreferenceOrderedConfigurationMethods.Add(configMethod);
                    devicePairingKinds |= WiFiDirectConnectionParameters.GetDevicePairingKinds(configMethod);
                }
            }
            else
            {
                // If specific configuration methods were not added, then we'll use these pairing kinds.
                devicePairingKinds = DevicePairingKinds.ConfirmOnly | DevicePairingKinds.DisplayPin | DevicePairingKinds.ProvidePin;
            }

            var customPairing = request.DeviceInformation.Pairing.Custom;
            customPairing.PairingRequested += (_, args) => HandlePairing(args, this);

            Log($"[WIFI DIRECT] Is paired already: {(request.DeviceInformation.Pairing.IsPaired ? "Yes" : "No")}");
            var pairResult = await customPairing.PairAsync(devicePairingKinds, DevicePairingProtectionLevel.Default, connectionParams);
            Log($"[WIFI DIRECT] Pairing status: {pairResult.Status}");
            Log($"[WIFI DIRECT] Protection level: {pairResult.ProtectionLevelUsed}");
        }

        private void OnStatusChanged(WiFiDirectAdvertisementPublisher sender, WiFiDirectAdvertisementPublisherStatusChangedEventArgs args)
        {
            Log($"[WIFI DIRECT] Wifi status changed: {args.Status}");
            if (args.Status == WiFiDirectAdvertisementPublisherStatus.Aborted)
            {
                Log($"[WIFI DIRECT]   Error: {args.Error}");
                if (args.Error == WiFiDirectError.Success)
                    _publisher?.Start();
                else
                    MessageBox.Show("Nìco se nepodaøilo, zkuste to prosím znovu", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void HandlePairing(DevicePairingRequestedEventArgs args, MainWindow window)
        {
            using (Deferral deferral = args.GetDeferral())
            {
                window.Log($"[WIFI DIRECT] Pairing kind: {args.PairingKind}");
                window.Log($"[WIFI DIRECT] PIN: {args.Pin}");
                switch (args.PairingKind)
                {
                    case DevicePairingKinds.DisplayPin:
                        var pinDialog = new PINDialog(args.Pin);
                        if (pinDialog.ShowDialog() == DialogResult.OK)
                        {
                            args.Accept();
                            window.Log("[WIFI DIRECT] Pairing accepted");
                        }
                        else
                        {
                            window.Log("[WIFI DIRECT] Pairing canceled by user");
                        }
                        break;

                    case DevicePairingKinds.ConfirmOnly:
                        args.Accept();
                        window.Log("[WIFI DIRECT] Pairing accepted");
                        break;

                    case DevicePairingKinds.ProvidePin:
                        pinDialog = new PINDialog();
                        if (pinDialog.ShowDialog() == DialogResult.OK)
                        {
                            string pin = pinDialog.GetPin();
                            if (!string.IsNullOrEmpty(pin))
                            {
                                args.Accept(pin);
                                window.Log("[WIFI DIRECT] Pairing accepted");
                            }
                            else
                            {
                                window.Log("[WIFI DIRECT] Wrong pin entered");
                            }
                        }
                        else
                        {
                            window.Log("[WIFI DIRECT] Pairing canceled by user");
                        }
                        break;
                }
            }
        }

        public void Log(string text)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    Invoke(() =>
                    {
                        logWindow.ListBox.Items.Add(text);
                        logWindow.ListBox.Update();
                    });
                }
            }
            catch (ObjectDisposedException ex) { }
        }

        private void testQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var qrCodes = QRHelper.GetQRImages(database.Runner.ToList());
            new QR(qrCodes[0]).ShowDialog();
        }

        private void logToolStripMenuItem1_Click(object sender, EventArgs e)
            => logWindow.Show();
    }
}
