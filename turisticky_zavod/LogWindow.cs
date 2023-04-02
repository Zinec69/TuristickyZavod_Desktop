
namespace Forms
{
    public partial class LogWindow : Form
    {
        public ListBox ListBox { get; }

        public LogWindow()
        {
            InitializeComponent();

            ListBox = listBox_log;
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
