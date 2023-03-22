using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Forms
{
    public partial class MainWindow : Form
    {
        private bool[] Orders = new bool[8] { false, true, true, true, false, true, true, true };

        private BindingList<Runner> Runners = new();

        private Database database;

        public MainWindow()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView1, true);
            //dataGridView1.DataSource = Runners;

            database = Database.Instance;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            new Thread(new ThreadStart(() =>
            {
                // Uncomment the line below to start fresh with a new database.
                // this.dbContext.Database.EnsureDeleted();
                database.Database.EnsureCreated();

                dataGridView1.Invoke(() =>
                {
                    database.Runners.Load();
                    database.AgeCategories.Load();
                    database.Checkpoints.Load();

                    dataGridView1.DataSource = database.Runners.Local.ToBindingList();
                });
            })).Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            database.Dispose();
        }

        private void AddRunners(List<Runner> runners)
        {
            if (runners.Find(r => r.RunnerID != null) == null)
            {
                var prompt = MessageBox.Show("Tato data nemají vyplnìna startovní èísla, chcete je pøiøadit automaticky?", "Pøiøadit startovní èísla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (prompt == DialogResult.Yes)
                {
                    int i = 1;
                    foreach (Runner runner in runners)
                    {
                        runner.RunnerID = i++;
                    }
                }
            }
            //foreach (Runner runner in runners)
            //{
            //    Runners.Add(runner);
            //}
            database.Runners.AddRange(runners);
        }

        private void AddRunnersJSON(List<Runner> runners)
        {
            var jsonPickerWindow = new JsonPicker(runners);
            if (jsonPickerWindow.ShowDialog() == DialogResult.OK)
            {
                foreach (Runner runner in runners)
                {
                    var current = Runners.FirstOrDefault(r => r!.RunnerID == runner.RunnerID, null);
                    if (current != null)
                    {
                        current.Disqualified = runner.Disqualified;
                        current.FinishTime = runner.FinishTime;
                        current.StartTime = runner.StartTime;
                        foreach (var ci in runner.CheckpointInfo)
                        {
                            if (current.CheckpointInfo.FirstOrDefault(c => c.Checkpoint.CheckpointID == ci.Checkpoint.CheckpointID, null) == null)
                            {
                                current.CheckpointInfo.Add(ci);
                                break;
                            }
                        }
                        continue;
                    }
                }
            }
        }

        private void OnNFCScanned(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Runner newRunner = (Runner)e.NewItems![0]!;
            var currentRunner = Runners.FirstOrDefault(r => r!.RunnerID == newRunner.RunnerID, null);

            if (currentRunner != null)
            {
                currentRunner.StartTime = newRunner.StartTime;
                currentRunner.FinishTime = newRunner.FinishTime;
                currentRunner.Disqualified = newRunner.Disqualified;
                foreach (var ci in newRunner.CheckpointInfo)
                {
                    if (currentRunner.CheckpointInfo.FirstOrDefault(c => c.Checkpoint.CheckpointID == ci.Checkpoint.CheckpointID, null) == null)
                    {
                        currentRunner.CheckpointInfo.Add(ci);
                        break;
                    }
                }
                dataGridView1.Invoke(() => Runners[Runners.IndexOf(currentRunner)] = currentRunner);
            }
            else
            {
                var dialog = MessageBox.Show("Tento bìžec není v seznamu, chcete jej i pøesto pøidat?", "Varování", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    dataGridView1.Invoke(() => Runners.Add(newRunner));
                }
            }
        }

        private void CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Soubory CSV (*.csv)|*.csv",
                Multiselect = false
            };
            fileDialog.FileOk += (_, _) => AddRunners(FileHelper.LoadFromCSV(fileDialog.FileName));
            fileDialog.ShowDialog();
        }

        private void JSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Soubory JSON (*.json)|*.json",
                Multiselect = false
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
                AddRunnersJSON(FileHelper.LoadFromJSON(fileDialog.FileName));
        }

        private void NFCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nfcWindow = new NFCScanning();

            if (!nfcWindow.IsDisposed)
            {
                nfcWindow.SubscribeToNewRunners(OnNFCScanned);
                nfcWindow.ShowDialog();
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    Runners = new BindingList<Runner>((Orders[0] ? Runners.OrderBy(r => r.RunnerID) : Runners.OrderByDescending(r => r.RunnerID)).ToList());
                    Orders[0] = !Orders[0];
                    break;
                case 1:
                    Runners = new BindingList<Runner>((Orders[1] ? Runners.OrderBy(r => r.FirstName) : Runners.OrderByDescending(r => r.FirstName)).ToList());
                    Orders[1] = !Orders[1];
                    break;
                case 2:
                    Runners = new BindingList<Runner>((Orders[2] ? Runners.OrderBy(r => r.LastName) : Runners.OrderByDescending(r => r.LastName)).ToList());
                    Orders[2] = !Orders[2];
                    break;
                case 3:
                    Runners = new BindingList<Runner>((Orders[3] ? Runners.OrderBy(r => r.Team) : Runners.OrderByDescending(r => r.Team)).ToList());
                    Orders[3] = !Orders[3];
                    break;
                case 4:
                    Runners = new BindingList<Runner>((Orders[4] ? Runners.OrderBy(r => r.BirthYear) : Runners.OrderByDescending(r => r.BirthYear)).ToList());
                    Orders[4] = !Orders[4];
                    break;
                case 5:
                    Runners = new BindingList<Runner>((Orders[5] ? Runners.OrderBy(r => r.StartTime) : Runners.OrderByDescending(r => r.StartTime)).ToList());
                    Orders[5] = !Orders[5];
                    break;
                case 6:
                    Runners = new BindingList<Runner>((Orders[6] ? Runners.OrderBy(r => r.FinishTime) : Runners.OrderByDescending(r => r.FinishTime)).ToList());
                    Orders[6] = !Orders[6];
                    break;
                case 7:
                    Runners = new BindingList<Runner>((Orders[7] ? Runners.OrderBy(r => r.Disqualified) : Runners.OrderByDescending(r => r.Disqualified)).ToList());
                    Orders[7] = !Orders[7];
                    break;
            }
            dataGridView1.DataSource = Runners;
        }
    }
}
