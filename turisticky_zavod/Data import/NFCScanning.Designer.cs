﻿namespace turisticky_zavod.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NFCScanning));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            readerStatusText = new Label();
            readerStatusTextVar = new Label();
            pictureBox_nfcIcon = new PictureBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_nfcIcon).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 229);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(299, 22);
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
            // pictureBox_nfcIcon
            // 
            pictureBox_nfcIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox_nfcIcon.Location = new Point(96, 75);
            pictureBox_nfcIcon.Name = "pictureBox_nfcIcon";
            pictureBox_nfcIcon.Size = new Size(105, 100);
            pictureBox_nfcIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_nfcIcon.TabIndex = 5;
            pictureBox_nfcIcon.TabStop = false;
            // 
            // NFCScanning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 251);
            Controls.Add(pictureBox_nfcIcon);
            Controls.Add(readerStatusTextVar);
            Controls.Add(readerStatusText);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(315, 290);
            Name = "NFCScanning";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Načítání dat z NFC čipů";
            FormClosing += NFCScanning_FormClosing;
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
        private PictureBox pictureBox_nfcIcon;
    }
}