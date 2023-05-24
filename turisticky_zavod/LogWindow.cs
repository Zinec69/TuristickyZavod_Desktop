using turisticky_zavod.Logic;

namespace turisticky_zavod.Forms
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();

            listBox_log.DataSource = Database.Instance.Log.Local.ToBindingList();
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void LogWindow_Shown(object sender, EventArgs e)
        {
            Database.Instance.Log.Local.CollectionChanged += (_, _) => Invoke(() => listBox_log.TopIndex = listBox_log.Items.Count - 1);
        }
    }
}
