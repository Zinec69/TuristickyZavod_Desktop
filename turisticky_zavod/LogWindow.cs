
namespace Forms
{
    public partial class LogWindow : Form
    {
        private static readonly object _lock = new();
        private static LogWindow instance = null;
        public static LogWindow Instance
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new LogWindow();

                    return instance;
                }
            }
        }

        private ListBox ListBox { get; }

        private LogWindow()
        {
            InitializeComponent();

            ListBox = listBox_log;
        }

        public void Log(string message)
        {
            Invoke(() =>
            {
                ListBox.Items.Add($"{DateTime.Now:HH:mm:ss} {message}");
                ListBox.Update();
            });
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
