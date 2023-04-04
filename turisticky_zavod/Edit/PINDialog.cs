
namespace Forms
{
    public partial class PINDialog : Form
    {
        private string PinEntered { get; set; } = "";

        public PINDialog()
        {
            InitializeComponent();
        }

        public PINDialog(string pin)
        {
            InitializeComponent();

            textBox_pin.Text = pin;
            textBox_pin.Enabled = false;
            Text = "Zadejte zobrazený PIN v telefonu";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                PinEntered = textBox_pin.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public string GetPin()
        {
            Dispose();
            return PinEntered;
        }

        private void textBox_pin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox_pin.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "PIN je povinná položka");
            }
        }

        private void textBox_pin_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private static bool HandleNumberOnlyField(KeyEventArgs e)
            => !((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || (e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right);
    }
}
