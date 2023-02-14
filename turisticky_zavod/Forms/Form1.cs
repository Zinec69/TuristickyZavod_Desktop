using turisticky_zavod.Data;
using System.ComponentModel;

namespace turisticky_zavod
{
    public partial class Form1 : Form
    {
        //private NFCReaderSerial reader = new();
        //private NFCReaderPCSC Reader = new();
        private BindingList<Runner> Runners = new();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Runners;
            //Reader.AddOnCardInserted(OnTagDiscovered);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Soubory CSV (*.csv)|*.csv",
                Multiselect = false
            };
            fileDialog.FileOk += (sender, args) => AddRunners(CsvHelper.LoadRunners(fileDialog.FileName));
            fileDialog.ShowDialog();
        }

        //private void OnTagDiscovered(object sender, CardStatusEventArgs args)
        //{
        //    if (args.Atr.Length < 15 || args.Atr[13] != 0x00 || !(args.Atr[14] == 0x01 || args.Atr[14] == 0x02))
        //    {
        //        MessageBox.Show("Nepodporovaný typ èipu");
        //        return;
        //    }

        //    try
        //    {
        //        var timer = Stopwatch.StartNew();

        //        var runner = Reader.ReadRunnerFromTag();

        //        timer.Stop();
        //        toolStripStatusLabel1.Text = $"Tag read in: {timer.ElapsedMilliseconds}ms";

        //        dataGridView1.Invoke(() => Runners.Add(runner));
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show($"Error: {e.Message}");
        //    }
        //}

        private void AddRunners(List<Runner> runners)
        {
            foreach (Runner runner in runners)
            {
                Runners.Add(runner);
            }
        }
    }
}
