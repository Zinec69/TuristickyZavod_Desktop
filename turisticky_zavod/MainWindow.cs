using System.ComponentModel;
using turisticky_zavod.Logic;
using Microsoft.EntityFrameworkCore;
using Windows.Devices.WiFiDirect;
using System.Diagnostics;
using Windows.Devices.Enumeration;
using Forms;
using System.Text.Json;
using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
{
    public partial class MainWindow : Form
    {
        private readonly Database database = Database.Instance;
        private LogWindow logWindow;

        public MainWindow()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView_runners, true);
            Program.SetDoubleBuffer(dataGridView_runners_results, true);
            Program.SetDoubleBuffer(dataGridView_runnerCheckpoints, true);

            InitDatabase();
        }
        
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HandleClosing())
            {
                e.Cancel = false;
                base.OnClosing(e);

                database.Dispose();
                StopAdvertisement();
            }
            else
                e.Cancel = true;
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
                    //database.Database.EnsureDeleted();
                    database.Database.EnsureCreated();

                    var res = BeginInvoke(async () =>
                    {
                        await database.CheckpointRunnerInfo.LoadAsync();
                        toolStripProgressBar1.Value += 20;
                        await database.Runner.LoadAsync();
                        toolStripProgressBar1.Value += 20;
                        await database.Partner.LoadAsync();
                        toolStripProgressBar1.Value += 10;
                        await database.AgeCategory.LoadAsync();
                        toolStripProgressBar1.Value += 15;
                        await database.Checkpoint.LoadAsync();
                        toolStripProgressBar1.Value += 15;
                        await database.Referee.LoadAsync();
                        toolStripProgressBar1.Value += 5;
                        await database.Team.LoadAsync();
                        toolStripProgressBar1.Value += 5;
                        await database.CheckpointAgeCategoryParticipation.LoadAsync();
                        toolStripProgressBar1.Value += 10;
                        await database.Log.LoadAsync();

                        logWindow = new LogWindow();
                        comboBox_team.DataSource = database.Team.Local.ToBindingList();
                        comboBox_ageCategory.DataSource = database.AgeCategory.Local.ToBindingList();
                    });

                    while (!res.IsCompleted) { };

                    dataGridView_runners.BeginInvoke(() =>
                        dataGridView_runners.DataSource = database.Runner.Local.ToBindingList());

                    timer.Stop();
                    Log($"Database loaded in {timer.ElapsedMilliseconds}ms", "Database");

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

        private async void AddRunnersCSV(string filepath)
        {
            try
            {
                var timer = Stopwatch.StartNew();

                var runners = await FileHelper.LoadFromCSV(filepath);

                if (runners.Find(r => r.StartNumber != null) == null)
                {
                    if (MessageBox.Show("Tato data nemají vyplnìna startovní èísla, chcete je pøiøadit automaticky?",
                        "Pøiøadit startovní èísla", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                        ) == DialogResult.Yes)
                    {
                        var ids = database.Runner.Local.Where(r => r.StartNumber.HasValue);
                        int i = ids.Any() ? ids.Max(r => r.StartNumber!.Value) : 0;
                        foreach (var runner in runners)
                        {
                            runner.StartNumber = ++i;
                        }
                    }
                }

                toolStripStatusLabel1.Text = "Naèítání ze souboru";
                toolStripProgressBar1.Value = 40;
                toolStripProgressBar1.Visible = true;

                dataGridView_runners.DataSource = null;
                dataGridView_runners_results.DataSource = null;

                new Thread(new ThreadStart(async () =>
                {
                    await database.Runner.AddRangeAsync(runners);
                    await database.SaveChangesAsync();

                    dataGridView_runners.BeginInvoke(() => dataGridView_runners.DataSource = database.Runner.Local.ToBindingList());

                    Invoke(() =>
                    {
                        toolStripStatusLabel1.Text = "Soubor úspìšnì naèten";
                        toolStripProgressBar1.Value = 100;
                    });

                    Thread.Sleep(1000);

                    Invoke(() =>
                    {
                        toolStripStatusLabel1.Text = string.Empty;
                        toolStripProgressBar1.Visible = false;
                        toolStripProgressBar1.Value = 0;
                    });
                })).Start();

                timer.Stop();
                Log($"Csv loaded and saved to database in {timer.ElapsedMilliseconds}ms", "Files");
            }
            catch (CsvException e)
            {
                Log($"Failed loading csv: {e.Message}", "Files");
                MessageBox.Show(e.Message,
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                Log($"Failed loading csv: {e.Message}", "Files");
                MessageBox.Show("Nepodaøilo se naèíst data z CSV souboru",
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
                Log($"Json loaded and saved to database in {timer.ElapsedMilliseconds}ms", "Files");
            }
        }

        private void OnNFCScanned(object? sender, Runner runner)
        {
            if (MessageBox.Show("Tento bìžec není v seznamu, chcete jej i pøesto pøidat? Nebude mít vyplnìna všechna data.",
                "Bìžec bez záznamu", MessageBoxButtons.YesNo, MessageBoxIcon.Question
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
                return MessageBox.Show("Chcete svou práci pøed ukonèením uložit?",
                    "Uložit pøed ukonèením", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
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
                if (MessageBox.Show("Opravdu chcete aplikaci ukonèit?",
                    "Ukonèit aplikaci", MessageBoxButtons.YesNo, MessageBoxIcon.Question
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

                Log("Database successfully saved to file", "Files");
                toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} Soubor úspìšnì uložen";

                return true;
            }
            catch (Exception e)
            {
                Log($"Saving database to file failed: {e.Message}", "Files");
                toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss} Ukládání souboru se nepodaøilo";

                return false;
            }
        }

        private async void DetermineJsonLoadingWay(string filePath)
        {
            try
            {
                AddRunnersJSON(filePath);
            }
            catch (JsonException)
            {
                if (MessageBox.Show("Opravdu chcete naèíst tento soubor? Pøijdete o veškeré provedené zmìny",
                    "Naèíst soubor", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    using var transaction = await database.Database.BeginTransactionAsync();

                    try
                    {
                        toolStripStatusLabel1.Text = "Naèítání ze souboru";
                        toolStripProgressBar1.Value = 40;
                        toolStripProgressBar1.Visible = true;

                        dataGridView_runners.DataSource = null;
                        dataGridView_runners_results.DataSource = null;

                        new Thread(new ThreadStart(() =>
                        {
                            Database.LoadFromJson(filePath);

                            Invoke(() =>
                            {
                                dataGridView_runners.DataSource = database.Runner.Local.ToBindingList();

                                toolStripStatusLabel1.Text = "Soubor úspìšnì naèten";
                                toolStripProgressBar1.Value = 100;
                            });

                            Thread.Sleep(1000);

                            Invoke(() =>
                            {
                                toolStripStatusLabel1.Text = string.Empty;
                                toolStripProgressBar1.Visible = false;
                                toolStripProgressBar1.Value = 0;
                            });
                        }
                        )).Start();

                        await transaction.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync();

                        Log($"Failed loading json: {e.Message}", "Files");
                        MessageBox.Show("Nepodaøilo se naèíst data z JSON souboru",
                            "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Failed loading json: {e.Message}", "Files");
                MessageBox.Show("Nepodaøilo se naèíst data z JSON souboru",
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
            Log($"New Wifi connection request:", "Wifi Direct");
            Log($"  Device name: {request.DeviceInformation.Name}", "Wifi Direct");
            Log($"  Device kind: {request.DeviceInformation.Kind}", "Wifi Direct");

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
                Log($"Pairing status: {pairResult.Status}", "Wifi Direct");
                Log($"Protection level: {pairResult.ProtectionLevelUsed}", "Wifi Direct");
            }
            else
                Log("Device is already paired", "Wifi Direct");
        }

        private void OnStatusChanged(WiFiDirectAdvertisementPublisher sender,
                        WiFiDirectAdvertisementPublisherStatusChangedEventArgs args)
        {
            Log($"Wifi status changed: {args.Status}", "Wifi Direct");
            if (args.Status == WiFiDirectAdvertisementPublisherStatus.Aborted)
            {
                Log($"  Error: {args.Error}", "Wifi Direct");
                if (args.Error == WiFiDirectError.Success)
                    _publisher?.Start();
                else
                    MessageBox.Show("Nìco se nepodaøilo, zkuste to prosím znovu",
                        "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void HandlePairing(DevicePairingRequestedEventArgs args, MainWindow window)
        {
            using var deferral = args.GetDeferral();

            window.Log($"Pairing kind: {args.PairingKind}", "Wifi Direct");
            window.Log($"PIN: {args.Pin}", "Wifi Direct");
            switch (args.PairingKind)
            {
                case DevicePairingKinds.DisplayPin:
                    var pinDialog = new PINDialog(args.Pin);
                    if (pinDialog.ShowDialog() == DialogResult.OK)
                    {
                        args.Accept();
                        window.Log("Pairing accepted", "Wifi Direct");
                    }
                    else
                    {
                        window.Log("Pairing canceled by user", "Wifi Direct");
                    }
                    break;

                case DevicePairingKinds.ConfirmOnly:
                    args.Accept();
                    window.Log("Pairing accepted", "Wifi Direct");
                    break;

                case DevicePairingKinds.ProvidePin:
                    pinDialog = new PINDialog();
                    if (pinDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pin = pinDialog.GetPin();
                        if (!string.IsNullOrEmpty(pin))
                        {
                            args.Accept(pin);
                            window.Log("Pairing accepted", "Wifi Direct");
                        }
                        else
                        {
                            window.Log("Wrong pin entered", "Wifi Direct");
                        }
                    }
                    else
                    {
                        window.Log("Pairing canceled by user", "Wifi Direct");
                    }
                    break;
            }
        }

        #endregion

        #region ToolStripMenu events

        private void FileImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Soubory CSV nebo JSON (*.csv, *.json)|*.csv;*.json",
                Multiselect = false
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName[(fileDialog.FileName.LastIndexOf('.') + 1)..].ToLower() == "json")
                    DetermineJsonLoadingWay(fileDialog.FileName);
                else
                    AddRunnersCSV(fileDialog.FileName);
            }
        }

        private void NFCImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nfcWindow = new NFCScanning();

            if (!nfcWindow.IsDisposed)
            {
                nfcWindow.OnRunnerNotInDB += OnNFCScanned;

                if (nfcWindow.ShowDialog() == DialogResult.OK)
                {
                    dataGridView_runners.Refresh();
                    dataGridView_runners_results.Refresh();
                }
            }
        }

        private void AgeCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AgeCategoriesEditor().ShowDialog();
            dataGridView_runners.Refresh();
        }

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

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => new About().ShowDialog();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => HandleSaving();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => HandleSaving(forceNewFile: true);

        private void ToolStripMenuItem_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete vymazat všechna data a uvést aplikaci do pùvodního stavu? Tento krok nelze vrátit",
                "Resetovat aplikaci", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                database.ChangeTracker.Clear();
                database.Database.EnsureDeleted();

                Application.Restart();
                Environment.Exit(0);
            }
        }

        #endregion

        #region Button Start events

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var ids = database.Runner.Local.Where(r => r.StartNumber.HasValue);

                var edit = button_save.Text == "Upravit";

                var startNumber = !string.IsNullOrEmpty(textBox_startNumber.Text)
                                   ? int.Parse(textBox_startNumber.Text)
                                   : (ids.Any() ? ids.Max(r => r.StartNumber!.Value) + 1 : 1);
                var name = textBox_name.Text.Trim();
                var birthdate = dateTimePicker_birthdate.Value;
                var gender = comboBox_gender.SelectedIndex == 1 ? Gender.FEMALE : Gender.MALE;
                var team = (Team)comboBox_team.SelectedItem ?? new Team() { Name = comboBox_team.Text };
                var ageCategory = (AgeCategory)comboBox_ageCategory.SelectedItem;
                var partnerName = textBox_name_partner.Text.Trim();

                if (!edit && database.Runner.Local.Any(x => x.StartNumber.HasValue && x.StartNumber.Value == startNumber))
                {
                    MessageBox.Show($"Bìžec se startovním èíslem {startNumber} již existuje",
                        "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var runner = edit ? (Runner)dataGridView_runners.CurrentRow.DataBoundItem : new Runner();

                runner.StartNumber = startNumber;
                runner.Name = name;
                runner.Birthdate = birthdate;
                runner.Team = team;
                runner.AgeCategory = ageCategory;

                if (!string.IsNullOrEmpty(partnerName))
                {
                    var partnerBirthdate = dateTimePicker_birthdate_partner.Value;

                    if (runner.Partner != null)
                    {
                        runner.Partner.Name = partnerName;
                        runner.Partner.Birthdate = partnerBirthdate;
                    }
                    else
                    {
                        runner.Partner = new Partner()
                        {
                            Name = partnerName,
                            Birthdate = partnerBirthdate
                        };
                    }
                }
                else
                    runner.Partner = null;

                if (edit)
                    database.Runner.Update(runner);
                else
                    database.Runner.Add(runner);

                database.SaveChanges();

                ClearInputs_Start();
                dataGridView_runners.Refresh();
            }
        }

        #endregion

        #region Button RunnerCheckpoints events

        private void Button_CheckpointInfo_Add_Click(object sender, EventArgs e)
        {
            if (Validate_CheckpointInfo_Inputs() && dataGridView_runners_results.CurrentCell != null)
            {
                var timeWaited = TimeSpan.Parse($"00:{maskedTextBox_timeWaited.Text}");
                var penalty = TimeSpan.Parse($"00:{maskedTextBox_penalty.Text}");
                var disqualified = checkBox_disqualified_checkpointInfo.Checked;

                var runner = (Runner)dataGridView_runners_results.CurrentRow.DataBoundItem;

                var checkpoint = (Checkpoint)comboBox_checkpoints_checkpointInfo.SelectedItem;

                runner.CheckpointInfo.Add(new CheckpointRunnerInfo()
                {
                    TimeWaited = timeWaited,
                    Penalty = penalty,
                    Disqualified = disqualified,
                    CheckpointID = checkpoint.ID
                });

                database.Runner.Update(runner);
                database.SaveChanges();

                comboBox_checkpoints_checkpointInfo.DataSource = database.Checkpoint.Local.Except(runner.CheckpointInfo.Select(x => x.Checkpoint))
                                                                                          .Where(
                                                                                               x => x.ID != 1
                                                                                               && (runner.AgeCategory == null
                                                                                                    || database.CheckpointAgeCategoryParticipation.Local
                                                                                                          .First(y => y.CheckpointID == x.ID
                                                                                                                   && y.AgeCategoryID == runner.AgeCategoryID)
                                                                                                          .IsParticipating)
                                                                                           ).ToList();
                maskedTextBox_timeWaited.Text = "0000";
                maskedTextBox_penalty.Text = "0000";
                checkBox_disqualified_checkpointInfo.Checked = false;

                dataGridView_runnerCheckpoints.DataSource = runner.CheckpointInfo.Where(x => x.CheckpointID != 1).ToList();
                dataGridView_runners_results.Refresh();
            }
        }

        private bool Validate_CheckpointInfo_Inputs()
        {
            var validated = true;

            if (!TimeSpan.TryParse($"00:{maskedTextBox_timeWaited.Text}", out _))
            {
                validated = false;
                errorProvider.SetError(maskedTextBox_timeWaited, "Zdržný èas je ve špatném formátu");
            }
            else
                errorProvider.SetError(maskedTextBox_timeWaited, string.Empty);

            if (!TimeSpan.TryParse($"00:{maskedTextBox_penalty.Text}", out _))
            {
                validated = false;
                errorProvider.SetError(maskedTextBox_penalty, "Trestný èas je ve špatném formátu");
            }
            else
                errorProvider.SetError(maskedTextBox_penalty, string.Empty);

            if (comboBox_checkpoints_checkpointInfo.SelectedIndex < 0)
            {
                validated = false;
                errorProvider.SetError(comboBox_checkpoints_checkpointInfo, "Stanovištì je povinné");
            }
            else
                errorProvider.SetError(comboBox_checkpoints_checkpointInfo, string.Empty);

            return validated;
        }

        #endregion

        #region DataGridView Start events

        private void DataGridView_Runners_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView_runners.CurrentRow != null)
            {
                var runner = (Runner)dataGridView_runners.CurrentRow.DataBoundItem;

                textBox_startNumber.Text = runner.StartNumber?.ToString() ?? string.Empty;
                textBox_name.Text = runner.Name;
                dateTimePicker_birthdate.Value = runner.Birthdate ?? new DateTime(2000, 1, 1);
                comboBox_team.SelectedItem = runner.Team;
                comboBox_ageCategory.SelectedItem = runner.AgeCategory;
                comboBox_gender.SelectedIndex = runner.Gender == Gender.MALE ? 0 : 1;

                textBox_name_partner.Text = runner.Partner?.Name ?? string.Empty;
                dateTimePicker_birthdate_partner.Value = runner.Partner?.Birthdate ?? new DateTime(2000, 1, 1);
                comboBox_gender_partner.SelectedIndex = runner.Partner != null ? (runner.Partner!.Gender == Gender.MALE ? 0 : 1) : -1;

                button_save.Text = "Upravit";
            }
        }

        private void DataGridView_Runners_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView_runners.ClearSelection();
                dataGridView_runners.CurrentCell = null;
                ClearInputs_Start();
                ClearAllErrors();
            }
        }

        private void DataGridView_Runners_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_runners.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
            ClearInputs_Start();
        }

        private void DataGridView_Runners_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Opravdu chcete vymazat záznam tohoto bìžce? Tento krok nelze vrátit zpìt",
                "Vymazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;
        }

        private void DataGridView_Runners_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            database.SaveChanges();
        }

        private void DataGridView_Runners_DragEnter(object sender, DragEventArgs e)
        {
            Activate();

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DataGridView_Runners_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                var filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                switch (filepath[(filepath.LastIndexOf('.') + 1)..].ToLower())
                {
                    case "json":
                        if (MessageBox.Show("Chcete naèíst data z JSON souboru?",
                            "Naèíst data", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            ) == DialogResult.Yes)
                            DetermineJsonLoadingWay(filepath);
                        break;

                    case "csv":
                        if (MessageBox.Show("Chcete naèíst data z CSV souboru?",
                            "Naèíst data", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            ) == DialogResult.Yes)
                            AddRunnersCSV(filepath);
                        break;

                    default:
                        MessageBox.Show("Nepodporovaný typ souboru",
                            "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                        break;
                }
            }
        }

        #endregion

        #region DataGridView Results events

        private void DataGridView_Runners_Results_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_runners_results.Rows)
            {
                var placement = ((IList<Runner>)dataGridView_runners_results.DataSource)[row.Index].GetPlacement(database.Runner.Local);
                row.HeaderCell.Value = placement?.ToString() ?? "-";
            }
            ClearInputs_Start();
        }

        private void DataGridView_Runners_Results_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView_runners_results.CurrentCell != null)
            {
                var runner = (Runner)dataGridView_runners_results.CurrentRow.DataBoundItem;

                textBox_startNumber_checkpointInfo.Text = runner.StartNumber.ToString();

                textBox_name_checkpointInfo.Text = runner.Name;
                if (runner.Partner != null)
                    textBox_name_checkpointInfo.Text += $", {runner.Partner.Name}";

                textBox_team_checkpointInfo.Text = runner.Team.Name;
                textBox_ageCategory_checkpointInfo.Text = runner.AgeCategory?.Name ?? "-";

                comboBox_checkpoints_checkpointInfo.DataSource = database.Checkpoint.Local.Except(runner.CheckpointInfo.Select(x => x.Checkpoint))
                                                                                          .Where(
                                                                                               x => x.ID != 1
                                                                                               && (runner.AgeCategory == null
                                                                                                    || database.CheckpointAgeCategoryParticipation.Local
                                                                                                          .First(y => y.CheckpointID == x.ID
                                                                                                                   && y.AgeCategoryID == runner.AgeCategoryID)
                                                                                                          .IsParticipating)
                                                                                           ).ToList();

                checkBox_disqualified_checkpointInfo.Checked = false;

                dataGridView_runnerCheckpoints.DataSource = runner.CheckpointInfo.Where(x => x.CheckpointID != 1).ToList();
            }
            else
                dataGridView_runnerCheckpoints.DataSource = null;
        }

        private void DataGridView_Runners_Results_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            database.SaveChanges();

            dataGridView_runners_results.Refresh();
        }

        private void DataGridView_Runners_Results_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("Zadaná hodnota je ve špatném formátu",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DataGridView RunnerCheckpoints events

        private void DataGridView_RunnerCheckpoints_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Cancel = true;

                var checkpointInfo = (CheckpointRunnerInfo)dataGridView_runnerCheckpoints.Rows[e.RowIndex].DataBoundItem;

                if (!checkpointInfo.Checkpoint.Disqualifiable)
                {
                    MessageBox.Show("V tomto stanovišti nelze diskvalifikovat",
                        "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    checkpointInfo.Disqualified = !checkpointInfo.Disqualified;
                    database.CheckpointRunnerInfo.Update(checkpointInfo);

                    database.SaveChanges();

                    foreach (DataGridViewRow row in dataGridView_runners_results.Rows)
                    {
                        var placement = ((IList<Runner>)dataGridView_runners_results.DataSource)[row.Index].GetPlacement(database.Runner.Local);
                        row.HeaderCell.Value = placement?.ToString() ?? "-";
                    }

                    dataGridView_runners_results.Refresh();
                }
            }
            else
            {
                if (!TimeSpan.TryParse(dataGridView_runnerCheckpoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _))
                {
                    e.Cancel = true;

                    MessageBox.Show("Zadaná hodnota je ve špatném formátu",
                        "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_RunnerCheckpoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            database.SaveChanges();

            dataGridView_runners_results.Refresh();
        }

        private void DataGridView_RunnerCheckpoints_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_runnerCheckpoints.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void DataGridView_RunnerCheckpoints_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && MessageBox.Show("Opravdu chcete vymazat záznam tohoto stanovištì pro tohoto bìžce? Tento krok nelze vrátit zpìt",
                "Vymazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var runner = (Runner)dataGridView_runners_results.CurrentRow.DataBoundItem;
                var checkpointInfo = (CheckpointRunnerInfo)dataGridView_runnerCheckpoints.CurrentRow.DataBoundItem;

                runner.CheckpointInfo.Remove(checkpointInfo);

                database.Runner.Update(runner);
                database.SaveChanges();

                dataGridView_runners_results.Refresh();
                dataGridView_runnerCheckpoints.DataSource = runner.CheckpointInfo.Where(x => x.CheckpointID != 1).ToList();
            }
        }

        private void DataGridView_RunnerCheckpoints_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("Zadaná hodnota je ve špatném formátu",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region TextBox/ComboBox/DateTimePicker Start events

        private void TextBox_StartNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_startNumber.Text)
                && button_save.Text == "Pøidat"
                && database.Runner.Any(x => x.StartNumber == int.Parse(textBox_startNumber.Text)))
            {
                e.Cancel = true;
                errorProvider.SetError((TextBox)sender, "Bìžec s tímto startovním èíslem již existuje");
            }
            else
                errorProvider.SetError((TextBox)sender, string.Empty);
        }

        private void TextBox_Name_Validating(object sender, CancelEventArgs e)
        {
            var name = textBox_name.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                e.Cancel = true;
                errorProvider.SetError((TextBox)sender, "Jméno je povinná položka");
            }
            else if (!name.Contains(' '))
            {
                e.Cancel = true;
                errorProvider.SetError((TextBox)sender, "Vyplòte jméno i pøíjmení, oddìlené mezerou");
            }
            else
            {
                foreach (var ch in name)
                {
                    if (!char.IsLetter(ch) && ch != ' ')
                    {
                        e.Cancel = true;
                        errorProvider.SetError((TextBox)sender, $"Jméno obsahuje nepovolené znaky: {ch}");
                        return;
                    }
                }

                errorProvider.SetError((TextBox)sender, string.Empty);
            }
        }

        private void ComboBox_Team_Validating(object sender, CancelEventArgs e)
        {
            var team = comboBox_team.Text.Trim();

            if (!(!string.IsNullOrEmpty(team) || comboBox_team.SelectedIndex > -1))
            {
                e.Cancel = true;
                errorProvider.SetError((ComboBox)sender, "Oddíl je povinná položka");
            }
            else
            {
                foreach (var ch in team)
                {
                    if (!char.IsLetter(ch) && ch != ' ')
                    {
                        e.Cancel = true;
                        errorProvider.SetError((ComboBox)sender, $"Název oddílu obsahuje nepovolené znaky: {ch}");
                        return;
                    }
                }

                errorProvider.SetError((ComboBox)sender, string.Empty);
            }
        }

        private void ComboBox_AgeCategory_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox_ageCategory.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError((ComboBox)sender, "Vìková kategorie je povinná položka");
            }
            else
                errorProvider.SetError((ComboBox)sender, string.Empty);
        }

        private void TextBox_Name_Partner_Validating(object sender, CancelEventArgs e)
        {
            var name = textBox_name_partner.Text.Trim();

            if (!string.IsNullOrEmpty(name) && name.Split(' ').Length < 2)
            {
                e.Cancel = true;
                errorProvider.SetError((TextBox)sender, "Vyplòte jméno i pøíjmení, oddìlené mezerou");
            }
            else
            {
                foreach (var ch in name)
                {
                    if (!char.IsLetter(ch) && ch != ' ')
                    {
                        e.Cancel = true;
                        errorProvider.SetError((TextBox)sender, $"Jméno obsahuje nepovolené znaky: {ch}");
                        return;
                    }
                }

                errorProvider.SetError((TextBox)sender, string.Empty);
            }
        }

        private void ComboBox_Gender_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox_gender.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError((ComboBox)sender, "Pohlaví je povinná položka");
            }
            else
                errorProvider.SetError((ComboBox)sender, string.Empty);
        }

        private void ComboBox_Gender_Partner_Validating(object sender, CancelEventArgs e)
        {
            var name = textBox_name_partner.Text.Trim();

            if (!string.IsNullOrEmpty(name) && name.Split(' ').Length > 1
                && comboBox_gender_partner.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError((ComboBox)sender, "Pohlaví je povinná položka");
            }
            else
                errorProvider.SetError((ComboBox)sender, string.Empty);
        }

        private void TextBox_StartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_BirthYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_BirthYear_Partner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_Name_Partner_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_name_partner.Text.Length <= 1)
            {
                Set_AgeCategory_ComboBox_Value();
            }
        }

        private void DateTimePicker_Birthdate_ValueChanged(object sender, EventArgs e)
        {
            Set_AgeCategory_ComboBox_Value();
        }

        private void DateTimePicker_Birthdate_Partner_ValueChanged(object sender, EventArgs e)
        {
            Set_AgeCategory_ComboBox_Value();
        }

        private void ComboBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_gender.SelectedIndex > -1)
            {
                Set_AgeCategory_ComboBox_Value();
            }
        }

        private void ComboBox_Gender_Partner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_gender_partner.SelectedIndex > -1)
            {
                Set_AgeCategory_ComboBox_Value();
            }
        }

        private void Set_AgeCategory_ComboBox_Value()
        {
            comboBox_ageCategory.SelectedItem = Data.AgeCategory.TryGetByBirthdate(dateTimePicker_birthdate.Value, database.AgeCategory.Local,
                comboBox_gender.SelectedIndex == 0 ? Gender.MALE : Gender.FEMALE, out AgeCategory? category,
                string.IsNullOrEmpty(textBox_name_partner.Text) ? CategoryType.DEFAULT : CategoryType.DUOS,
                dateTimePicker_birthdate_partner.Value) ? category : null;
        }

        #endregion

        #region CheckBox/ComboBox Results events

        private void CheckBox_Filter_Team_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_filter_team.Checked)
            {
                if (checkBox_filter_category.Checked)
                {
                    checkBox_filter_category.Checked = false;
                    comboBox_filter_category.Enabled = false;
                }
                comboBox_filter_team.Enabled = true;

                var team = (Team)comboBox_filter_team.SelectedItem;
                dataGridView_runners_results.DataSource = database.Runner.Local.Where(x => x.Team.ID == team.ID).ToList();
            }
            else
            {
                comboBox_filter_team.Enabled = false;

                if (!checkBox_filter_category.Checked)
                    dataGridView_runners_results.DataSource = database.Runner.Local.ToBindingList();
            }
        }

        private void CheckBox_Filter_Category_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_filter_category.Checked)
            {
                if (checkBox_filter_team.Checked)
                {
                    checkBox_filter_team.Checked = false;
                    comboBox_filter_team.Enabled = false;
                }
                comboBox_filter_category.Enabled = true;

                var category = (AgeCategory)comboBox_filter_category.SelectedItem;
                dataGridView_runners_results.DataSource = database.Runner.Local.Where(x => x.AgeCategory != null && x.AgeCategory.ID == category.ID).ToList();
            }
            else
            {
                comboBox_filter_category.Enabled = false;

                if (!checkBox_filter_team.Checked)
                    dataGridView_runners_results.DataSource = database.Runner.Local.ToBindingList();
            }
        }

        private void ComboBox_Filter_Team_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_filter_team.Checked)
            {
                var team = (Team)comboBox_filter_team.SelectedItem;
                dataGridView_runners_results.DataSource = database.Runner.Local.Where(x => x.Team.ID == team.ID).ToList();
            }
        }

        private void ComboBox_Filter_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_filter_category.Checked)
            {
                var category = (AgeCategory)comboBox_filter_category.SelectedItem;
                dataGridView_runners_results.DataSource = database.Runner.Local.Where(x => x.AgeCategory != null && x.AgeCategory.ID == category.ID).ToList();
            }
        }

        #endregion

        #region TabControl events

        private void Tab_Selected(object sender, TabControlEventArgs e)
        {
            Size size;

            if (e.TabPageIndex == 0)
            {
                size = new Size(1111, 750);

                MinimumSize = size;
                Size = size;
            }
            else
            {
                size = new Size(1500, 750);

                Size = size;
                MinimumSize = size;

                new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(10);
                    dataGridView_runners_results.BeginInvoke(() => dataGridView_runners_results.DataSource = database.Runner.Local.ToBindingList());
                    comboBox_filter_team.DataSource = database.Team.Local.ToBindingList();
                    comboBox_filter_category.DataSource = database.AgeCategory.Local.ToBindingList();
                }
                )).Start();
            }
        }

        #endregion

        private void ClearInputs_Start()
        {
            textBox_startNumber.Clear();
            textBox_name.Clear();
            dateTimePicker_birthdate.Value = new DateTime(2000, 1, 1);
            comboBox_gender.SelectedIndex = -1;
            comboBox_team.SelectedIndex = -1;
            comboBox_ageCategory.SelectedIndex = -1;
            textBox_name_partner.Clear();
            dateTimePicker_birthdate_partner.Value = new DateTime(2000, 1, 1);
            comboBox_gender_partner.SelectedIndex = -1;

            button_save.Text = "Pøidat";
        }

        private void ClearAllErrors()
        {
            errorProvider.SetError(textBox_name, string.Empty);
            errorProvider.SetError(textBox_name, string.Empty);
            errorProvider.SetError(comboBox_team, string.Empty);
            errorProvider.SetError(comboBox_ageCategory, string.Empty);
            errorProvider.SetError(comboBox_gender, string.Empty);
            errorProvider.SetError(textBox_name_partner, string.Empty);
            errorProvider.SetError(comboBox_gender_partner, string.Empty);
        }

        private static bool HandleNumberOnlyField(KeyEventArgs e)
            => !((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || (e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right);

        public void Log(string message, string type)
        {
            try
            {
                Invoke(() =>
                {
                    database.Log.Add(new Log
                    {
                        Message = message,
                        Type = type
                    });
                    database.SaveChanges();
                });
            }
            catch (ObjectDisposedException) { }
        }
    }
}
