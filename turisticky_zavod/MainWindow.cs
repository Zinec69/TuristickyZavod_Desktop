using System.ComponentModel;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using Microsoft.EntityFrameworkCore;
using Windows.Devices.WiFiDirect;
using System.Diagnostics;
using Windows.Devices.Enumeration;
using Forms;
using System.Text.Json;

namespace turisticky_zavod.Forms
{
    public partial class MainWindow : Form
    {
        private readonly Database database = Database.Instance;
        private readonly LogWindow logWindow = LogWindow.Instance;

        public MainWindow()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView1, true);

            InitDatabase();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            logWindow.Show(); // TODO
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (HandleClosing())
            {
                base.OnClosing(e);

                database.Dispose();
                StopAdvertisement();
            }
            else
                e.Cancel = true;
        }

        private void InitDatabase()
        {
            toolStripStatusLabel1.Text = "Na��t�n� datab�ze";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;

            new Thread(new ThreadStart(() =>
            {
                var timer = Stopwatch.StartNew();

                try
                {
                    // TODO
                    database.Database.EnsureDeleted();
                    Log("[DATABASE] Deleting database");
                    database.Database.EnsureCreated();
                    Log("[DATABASE] Loading/creating database");

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
                        toolStripProgressBar1.Value += 5;
                        database.Team.Load();
                        toolStripProgressBar1.Value += 10;
                        database.CheckpointAgeCategoryParticipation.Load();
                        toolStripProgressBar1.Value += 5;

                        dataGridView1.DataSource = database.Runner.Local.ToBindingList();
                    });

                    timer.Stop();
                    Log($"[DATABASE] Done loading database in {timer.ElapsedMilliseconds}ms");

                    Thread.Sleep(500);

                    Invoke(() =>
                    {
                        toolStripStatusLabel1.Text = string.Empty;
                        toolStripProgressBar1.Visible = false;
                        toolStripProgressBar1.Value = 0;
                    });
                }
                catch (ObjectDisposedException ex) { }
                catch (InvalidOperationException ex) { }
            })).Start();
        }

        private void AddRunnersCSV(string filepath)
        {
            try
            {
                var timer = Stopwatch.StartNew();

                var runners = FileHelper.LoadFromCSV(filepath);

                if (runners.Find(r => r.StartNumber != null) == null)
                {
                    if (MessageBox.Show("Tato data nemaj� vypln�na startovn� ��sla, chcete je p�i�adit automaticky?",
                        "P�i�adit startovn� ��sla", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                        ) == DialogResult.Yes)
                    {
                        var ids = database.Runner.Local.Where(r => r.StartNumber.HasValue);
                        int i = ids.Any() ? ids.Max(r => r.StartNumber!.Value) : 0;
                        foreach (Runner runner in database.ChangeTracker.Entries<Runner>().Select(x => x.Entity))
                        {
                            runner.StartNumber = ++i;
                        }
                        dataGridView1.Refresh();
                    }
                }

                database.SaveChanges();

                timer.Stop();
                Log($"[FILES] Csv loaded and saved to database in {timer.ElapsedMilliseconds}ms");
            }
            catch (Exception e)
            {
                Log($"[FILES] Failed loading csv: {e.Message}");
                MessageBox.Show("Nepoda�ilo se na��st data z CSV souboru",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRunnersJSON(string filepath)
        {
            var timer = Stopwatch.StartNew();

            var runners = FileHelper.LoadRunnersFromJSON(filepath);

            var jsonPickerWindow = new JsonPicker(runners);
            if (jsonPickerWindow.ShowDialog() == DialogResult.OK)
            {
                var updatedRunners = new List<Runner>();
                foreach (Runner runner in runners)
                {
                    var current = database.Runner.Local.Where(r => r.StartNumber == runner.StartNumber).FirstOrDefault();
                    if (current != default)
                    {
                        current.Disqualified = runner.Disqualified;
                        current.FinishTime = runner.FinishTime;
                        current.StartTime = runner.StartTime;
                        foreach (var ci in runner.CheckpointInfo)
                        {
                            if (!current.CheckpointInfo.Any(c => c.Checkpoint.ID == ci.Checkpoint.ID))
                                current.CheckpointInfo.Add(ci);
                        }
                        updatedRunners.Add(current);
                        continue;
                    }
                }

                database.Runner.UpdateRange(updatedRunners);

                database.SaveChanges();

                timer.Stop();
                Log($"[FILES] Json loaded and saved to database in {timer.ElapsedMilliseconds}ms");
            }
        }

        private void OnNFCScanned(object? sender, Runner runner)
        {
            if (MessageBox.Show("Tento b�ec nen� v seznamu, chcete jej i p�esto p�idat? Nebude m�t vypln�na v�echna data.",
                "B�ec bez z�znamu", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                database.Runner.Add(runner);
                database.SaveChanges();
            }
        }

        private bool HandleClosing()
        {
            if (!database.IsSaved)
            {
                return MessageBox.Show("Chcete svou pr�ci p�ed ukon�en�m ulo�it?",
                    "Ulo�it p�ed ukon�en�m", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                    ) switch
                {
                    DialogResult.Yes => HandleSaving(),
                    DialogResult.No => true,
                    DialogResult.Cancel => false,
                    _ => false,
                };
            }
            else
            {
                if (MessageBox.Show("Opravdu chcete aplikaci ukon�it?",
                    "Ukon�it aplikaci", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
        }

        private bool HandleSaving(bool forceNewFile = false)
        {
            string? filePath = null;

            if (database.SavedFilePath == null || forceNewFile)
            {
                var fileDialog = new SaveFileDialog()
                {
                    Filter = "Soubory JSON (*.json)|*.json|Soubory Excelu (*.xlsx)|*.xlsx",
                    FileName = $"TZ_{DateTime.Now:yyyy-MM-dd}.json",
                    ValidateNames = true,
                    AddExtension = true
                };
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    filePath = fileDialog.FileName;
                else
                    return false;
            }

            try
            {
                database.SaveToFile(filePath);

                Log("[FILES] Database successfully saved to file");
                toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} Soubor �sp�n� ulo�en";

                return true;
            }
            catch (Exception e)
            {
                Log($"[FILES] Saving database to file failed: {e.Message}");
                toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} Ukl�d�n� souboru se nepoda�ilo";

                return false;
            }
        }

        private void DetermineJsonLoadingWay(string filePath)
        {
            try
            {
                AddRunnersJSON(filePath);
            }
            catch (JsonException)
            {
                if (MessageBox.Show("Opravdu chcete na��st tento soubor? P�ijdete o ve�ker� proveden� zm�ny",
                    "Na��st soubor", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    Database.LoadFromJson(filePath);
                }
            }
            catch (Exception e)
            {
                Log($"[FILES] Failed loading json: {e.Message}");
                MessageBox.Show("Nepoda�ilo se na��st data z JSON souboru",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region WiFi Direct stuff

        WiFiDirectAdvertisementPublisher? _publisher = null;
        WiFiDirectConnectionListener? _listener = null;

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

        private async void OnConnectionRequested(WiFiDirectConnectionListener sender,
                            WiFiDirectConnectionRequestedEventArgs connectionEventArgs)
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

            if (!request.DeviceInformation.Pairing.IsPaired)
            {
                var pairResult = await customPairing.PairAsync(devicePairingKinds, DevicePairingProtectionLevel.Default, connectionParams);
                Log($"[WIFI DIRECT] Pairing status: {pairResult.Status}");
                Log($"[WIFI DIRECT] Protection level: {pairResult.ProtectionLevelUsed}");
            }
            else
                Log("[WIFI DIRECT] Device is already paired");
        }

        private void OnStatusChanged(WiFiDirectAdvertisementPublisher sender,
                        WiFiDirectAdvertisementPublisherStatusChangedEventArgs args)
        {
            Log($"[WIFI DIRECT] Wifi status changed: {args.Status}");
            if (args.Status == WiFiDirectAdvertisementPublisherStatus.Aborted)
            {
                Log($"[WIFI DIRECT]   Error: {args.Error}");
                if (args.Error == WiFiDirectError.Success)
                    _publisher?.Start();
                else
                    MessageBox.Show("N�co se nepoda�ilo, zkuste to pros�m znovu",
                        "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void HandlePairing(DevicePairingRequestedEventArgs args, MainWindow window)
        {
            using var deferral = args.GetDeferral();

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

        #endregion


        #region ToolStripMenu events

        private void CSVImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Soubory CSV (*.csv)|*.csv",
                Multiselect = false
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
                AddRunnersCSV(fileDialog.FileName);
        }

        private void JSONImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Soubory JSON (*.json)|*.json",
                Multiselect = false
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
                DetermineJsonLoadingWay(fileDialog.FileName);
        }

        private void NFCImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nfcWindow = new NFCScanning();

            if (!nfcWindow.IsDisposed)
            {
                nfcWindow.OnRunnerNotInDB += OnNFCScanned;
                nfcWindow.ShowDialog();
            }
        }

        private void AgeCategoriesToolStripMenuItem_Click(object sender, EventArgs e) => new AgeCategoriesEditor().ShowDialog();

        private void TestWifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAdvertisement();
            StartAdvertisement();
        }

        private void TestQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var qrCodes = QRHelper.GetQRImages(database.Runner.ToList());
            new QR(qrCodes[0]).ShowDialog();
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e) => logWindow.Show();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => HandleSaving();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => HandleSaving(forceNewFile: true);

        #endregion


        #region DataGridView events

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
            }
        }

        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
                //row.HeaderCell.Value = ((BindingList<Runner>)dataGridView1.DataSource)[row.Index].ID.ToString();
            }
        }

        private void DataGridView_DragEnter(object sender, DragEventArgs e)
        {
            Activate();

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                var filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                switch (filepath.Split('.').Last().ToLower())
                {
                    case "json":
                        if (MessageBox.Show("Chcete na��st data z JSON souboru?",
                            "Na��st data", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            ) == DialogResult.Yes)
                            DetermineJsonLoadingWay(filepath);
                        break;

                    case "csv":
                        if (MessageBox.Show("Chcete na��st data z CSV souboru?",
                            "Na��st data", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            ) == DialogResult.Yes)
                            AddRunnersCSV(filepath);
                        break;

                    default:
                        MessageBox.Show("Nepodporovan� typ souboru",
                            "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                        break;
                }
            }
        }

        #endregion


        public void Log(string text)
        {
            if (!logWindow.IsDisposed)
                logWindow.Log(text);
        }
    }
}
