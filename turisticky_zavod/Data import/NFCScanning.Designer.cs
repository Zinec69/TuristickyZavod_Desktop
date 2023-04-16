namespace turisticky_zavod.Forms
{
    partial class NFCScanning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            readerStatusText = new Label();
            readerStatusTextVar = new Label();
            button_scanSerialPort = new Button();
            pictureBox_nfcIcon = new PictureBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_nfcIcon).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 219);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(284, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // readerStatusText
            // 
            readerStatusText.AutoSize = true;
            readerStatusText.Location = new Point(15, 15);
            readerStatusText.Name = "readerStatusText";
            readerStatusText.Size = new Size(69, 15);
            readerStatusText.TabIndex = 1;
            readerStatusText.Text = "Stav čtečky:";
            // 
            // readerStatusTextVar
            // 
            readerStatusTextVar.AutoSize = true;
            readerStatusTextVar.Location = new Point(90, 15);
            readerStatusTextVar.Name = "readerStatusTextVar";
            readerStatusTextVar.Size = new Size(0, 15);
            readerStatusTextVar.TabIndex = 2;
            // 
            // button_scanSerialPort
            // 
            button_scanSerialPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_scanSerialPort.Enabled = false;
            button_scanSerialPort.Location = new Point(162, 12);
            button_scanSerialPort.Name = "button_scanSerialPort";
            button_scanSerialPort.Size = new Size(101, 38);
            button_scanSerialPort.TabIndex = 3;
            button_scanSerialPort.Text = "Přečíst ze sériového portu";
            button_scanSerialPort.UseVisualStyleBackColor = true;
            button_scanSerialPort.Click += Button_ScanSerialPort_Click;
            // 
            // pictureBox_nfcIcon
            // 
            pictureBox_nfcIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox_nfcIcon.Location = new Point(90, 69);
            pictureBox_nfcIcon.Name = "pictureBox_nfcIcon";
            pictureBox_nfcIcon.Size = new Size(100, 100);
            pictureBox_nfcIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_nfcIcon.TabIndex = 5;
            pictureBox_nfcIcon.TabStop = false;
            // 
            // NFCScanning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 241);
            Controls.Add(pictureBox_nfcIcon);
            Controls.Add(button_scanSerialPort);
            Controls.Add(readerStatusTextVar);
            Controls.Add(readerStatusText);
            Controls.Add(statusStrip1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(300, 280);
            Name = "NFCScanning";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Načítání dat z NFC čipů";
            FormClosed += NFCScanning_FormClosed;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_nfcIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label readerStatusText;
        private Label readerStatusTextVar;
        private Button button_scanSerialPort;
        private PictureBox pictureBox_nfcIcon;
    }
}