using PCSC.Monitoring;
using System.Diagnostics;
using turisticky_zavod.Data;
using System.ComponentModel;
using turisticky_zavod.Domain;

namespace turisticky_zavod
{
    public partial class Form1 : Form
    {
        //private NFCReaderSerial reader = new();
        private NFCReaderPCSC Reader = new();
        private BindingList<Runner> Runners = new();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Runners;
            Reader.AddOnCardInserted(OnTagDiscovered);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void OnTagDiscovered(object sender, CardStatusEventArgs args)
        {
            try
            {
                var timer = Stopwatch.StartNew();

                var runner = Reader.ReadRunnerFromTag();

                timer.Stop();
                toolStripStatusLabel1.Text = $"Tag read in: {timer.ElapsedMilliseconds}ms";

                dataGridView1.Invoke(() => Runners.Add(runner));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }
    }
}
