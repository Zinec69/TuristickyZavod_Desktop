namespace turisticky_zavod.Forms
{
    public partial class QR : Form
    {
        private readonly Bitmap image;

        public QR(Bitmap image)
        {
            InitializeComponent();

            this.MaximumSize = new Size(2560, 1390);

            this.image = image;
            var size = image.Size;
            size.Height += 25;
            this.Size = size;
        }

        private void QR_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }
    }
}
