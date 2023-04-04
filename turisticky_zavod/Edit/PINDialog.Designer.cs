namespace Forms
{
    partial class PINDialog
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
            components = new System.ComponentModel.Container();
            textBox_pin = new TextBox();
            button_ok = new Button();
            label1 = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // textBox_pin
            // 
            textBox_pin.Anchor = AnchorStyles.Bottom;
            textBox_pin.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_pin.Location = new Point(59, 80);
            textBox_pin.Name = "textBox_pin";
            textBox_pin.Size = new Size(124, 27);
            textBox_pin.TabIndex = 0;
            textBox_pin.KeyDown += textBox_pin_KeyDown;
            textBox_pin.Validating += textBox_pin_Validating;
            // 
            // button_ok
            // 
            button_ok.Anchor = AnchorStyles.Bottom;
            button_ok.Location = new Point(83, 133);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(75, 28);
            button_ok.TabIndex = 1;
            button_ok.Text = "Ok";
            button_ok.UseVisualStyleBackColor = true;
            button_ok.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(59, 58);
            label1.Name = "label1";
            label1.Size = new Size(31, 19);
            label1.TabIndex = 2;
            label1.Text = "PIN";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // PINDialog
            // 
            AcceptButton = button_ok;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 201);
            Controls.Add(label1);
            Controls.Add(button_ok);
            Controls.Add(textBox_pin);
            MaximizeBox = false;
            MaximumSize = new Size(255, 240);
            MinimizeBox = false;
            MinimumSize = new Size(255, 240);
            Name = "PINDialog";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zadejte PIN z mobilní aplikace";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_pin;
        private Button button_ok;
        private Label label1;
        private ErrorProvider errorProvider;
    }
}