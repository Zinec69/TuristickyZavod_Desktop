namespace turisticky_zavod.Forms
{
    partial class LogWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWindow));
            listBox_log = new ListBox();
            SuspendLayout();
            // 
            // listBox_log
            // 
            listBox_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_log.FormattingEnabled = true;
            listBox_log.ItemHeight = 15;
            listBox_log.Location = new Point(9, 9);
            listBox_log.Margin = new Padding(0);
            listBox_log.Name = "listBox_log";
            listBox_log.SelectionMode = SelectionMode.None;
            listBox_log.Size = new Size(441, 544);
            listBox_log.TabIndex = 8;
            // 
            // LogWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 561);
            Controls.Add(listBox_log);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogWindow";
            Text = "Log";
            FormClosing += Log_FormClosing;
            Shown += LogWindow_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox_log;
    }
}