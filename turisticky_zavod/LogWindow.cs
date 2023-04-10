using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();

            listBox_log.DataSource = Database.Instance.Log.Local.ToBindingList();
            Database.Instance.Log.Local.CollectionChanged += (_, _) => Invoke(() => listBox_log.TopIndex = listBox_log.Items.Count - 1);
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
