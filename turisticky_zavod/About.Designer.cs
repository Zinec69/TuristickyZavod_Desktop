namespace Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            pictureBox_logo = new PictureBox();
            label_name = new Label();
            label1 = new Label();
            label2 = new Label();
            button_ok = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox_logo.Image = Properties.Resources.icon_rounded;
            pictureBox_logo.Location = new Point(12, 12);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(400, 141);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 0;
            pictureBox_logo.TabStop = false;
            // 
            // label_name
            // 
            label_name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_name.AutoSize = true;
            label_name.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label_name.Location = new Point(121, 166);
            label_name.Name = "label_name";
            label_name.Size = new Size(180, 30);
            label_name.TabIndex = 1;
            label_name.Text = "Turistický závod";
            label_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(175, 201);
            label1.Name = "label1";
            label1.Size = new Size(68, 19);
            label1.TabIndex = 2;
            label1.Text = "Verze: 1.0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(138, 224);
            label2.Name = "label2";
            label2.Size = new Size(145, 19);
            label2.TabIndex = 3;
            label2.Text = "Autor: Jakub Ostružka";
            // 
            // button_ok
            // 
            button_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_ok.Location = new Point(168, 333);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(87, 36);
            button_ok.TabIndex = 4;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_ok;
            ClientSize = new Size(424, 381);
            Controls.Add(button_ok);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_name);
            Controls.Add(pictureBox_logo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(440, 420);
            MinimizeBox = false;
            MinimumSize = new Size(440, 420);
            Name = "About";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "O aplikaci";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_logo;
        private Label label_name;
        private Label label1;
        private Label label2;
        private Button button_ok;
    }
}