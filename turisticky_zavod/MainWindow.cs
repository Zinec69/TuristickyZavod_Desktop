using System.ComponentModel;
using turisticky_zavod.Data;
using Microsoft.EntityFrameworkCore;
using Forms;

namespace turisticky_zavod.Forms
{
    public partial class MainWindow : Form
    {
        private readonly Database database = Database.Instance;

        public MainWindow()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView1, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            toolStripStatusLabel1.Text = "Naèítání databáze";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;

            new Thread(new ThreadStart(() =>
            {
                database.Database.EnsureDeleted();
                database.Database.EnsureCreated();

                Invoke(() =>
                {
                    toolStripProgressBar1.Value += 20;
                    database.Runner.Load();
                    toolStripProgressBar1.Value += 20;
                    database.Partner.Load();
                    toolStripProgressBar1.Value += 20;
                    database.AgeCategory.Load();
                    toolStripProgressBar1.Value += 20;
                    database.Checkpoint.Load();
                    toolStripProgressBar1.Value += 20;
                    database.Referee.Load();

                    dataGridView1.DataSource = database.Runner.Local.ToBindingList();
                });

                Thread.Sleep(500);

                Invoke(() =>
                {
                    toolStripStatusLabel1.Text = string.Empty;
                    toolStripProgressBar1.Visible = false;
                    toolStripProgressBar1.Value = 0;
                });
            })).Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            database.Dispose();
        }

        private async void AddRunnersCSV(string filepath)
        {
            try
            {
                var runners = FileHelper.LoadFromCSV(filepath);

                if (runners.Find(r => r.RunnerID != null) == null)
                {
                    var prompt = MessageBox.Show("Tato data nemají vyplnìna startovní èísla, chcete je pøiøadit automaticky?", "Pøiøadit startovní èísla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (prompt == DialogResult.Yes)
                    {
                        var ids = database.Runner.Local.Where(r => r.RunnerID.HasValue);
                        int i = ids.Any() ? ids.Max(r => r.RunnerID!.Value) : 0;
                        foreach (Runner runner in runners)
                        {
                            runner.RunnerID = ++i;
                        }
                    }
                }
                await database.Runner.AddRangeAsync(runners);
                database.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Nepodaøilo se naèíst data z CSV souboru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRunnersJSON(string filepath)
        {
            try
            {
                var runners = FileHelper.LoadFromJSON(filepath);

                var jsonPickerWindow = new JsonPicker(runners);
                if (jsonPickerWindow.ShowDialog() == DialogResult.OK)
                {
                    var updatedRunners = new List<Runner>();
                    foreach (Runner runner in runners)
                    {
                        var current = database.Runner.Where(r => r.RunnerID == runner.RunnerID).FirstOrDefault();
                        if (current != default)
                        {
                            current.Disqualified = runner.Disqualified;
                            current.FinishTime = runner.FinishTime;
                            current.StartTime = runner.StartTime;
                            foreach (var ci in runner.CheckpointInfo)
                            {
                                if (current.CheckpointInfo.FirstOrDefault(c => c.Checkpoint.CheckpointID == ci.Checkpoint.CheckpointID, null) == null)
                                    current.CheckpointInfo.Add(ci);
                            }
                            updatedRunners.Add(current);
                            continue;
                        }
                    }
                    database.Runner.UpdateRange(updatedRunners);
                    database.SaveChanges();
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
        {
            new AgeCategoriesEditor().ShowDialog();
        }
    }
}
