namespace turisticky_zavod.Forms
{
    partial class AgeCategoriesEditor
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ageCategoryBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageMinDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageMaxDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            duoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textBox_color = new TextBox();
            label5 = new Label();
            checkBox_duo = new CheckBox();
            label4 = new Label();
            textBox_ageMax = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox_ageMin = new TextBox();
            textBox_code = new TextBox();
            label1 = new Label();
            textBox_name = new TextBox();
            button_add = new Button();
            label6 = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // ageCategoryBindingSource
            // 
            ageCategoryBindingSource.DataSource = typeof(Data.AgeCategory);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, ageMinDataGridViewTextBoxColumn, ageMaxDataGridViewTextBoxColumn, colorDataGridViewTextBoxColumn, duoDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = ageCategoryBindingSource;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(718, 330);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Název";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 64;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            codeDataGridViewTextBoxColumn.HeaderText = "Zkratka";
            codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ageMinDataGridViewTextBoxColumn
            // 
            ageMinDataGridViewTextBoxColumn.DataPropertyName = "AgeMin";
            dataGridViewCellStyle1.NullValue = "∞";
            ageMinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            ageMinDataGridViewTextBoxColumn.HeaderText = "Věk od";
            ageMinDataGridViewTextBoxColumn.Name = "ageMinDataGridViewTextBoxColumn";
            ageMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ageMaxDataGridViewTextBoxColumn
            // 
            ageMaxDataGridViewTextBoxColumn.DataPropertyName = "AgeMax";
            dataGridViewCellStyle2.NullValue = "∞";
            ageMaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            ageMaxDataGridViewTextBoxColumn.HeaderText = "Věk do";
            ageMaxDataGridViewTextBoxColumn.Name = "ageMaxDataGridViewTextBoxColumn";
            ageMaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            colorDataGridViewTextBoxColumn.HeaderText = "Barva";
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            colorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // duoDataGridViewCheckBoxColumn
            // 
            duoDataGridViewCheckBoxColumn.DataPropertyName = "Duo";
            duoDataGridViewCheckBoxColumn.HeaderText = "Dvojice";
            duoDataGridViewCheckBoxColumn.Name = "duoDataGridViewCheckBoxColumn";
            duoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(730, 358);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Všechny věkové kategorie";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBox_color);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(checkBox_duo);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox_ageMax);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox_ageMin);
            groupBox2.Controls.Add(textBox_code);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox_name);
            groupBox2.Controls.Add(button_add);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(730, 93);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Přidat novou kategorii";
            // 
            // textBox_color
            // 
            errorProvider.SetIconAlignment(textBox_color, ErrorIconAlignment.MiddleLeft);
            textBox_color.Location = new Point(444, 46);
            textBox_color.Name = "textBox_color";
            textBox_color.Size = new Size(68, 23);
            textBox_color.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(444, 28);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 16;
            label5.Text = "Barva";
            // 
            // checkBox_duo
            // 
            checkBox_duo.AutoSize = true;
            checkBox_duo.Location = new Point(531, 42);
            checkBox_duo.Name = "checkBox_duo";
            checkBox_duo.Size = new Size(65, 19);
            checkBox_duo.TabIndex = 5;
            checkBox_duo.Text = "Dvojice";
            checkBox_duo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(375, 28);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 13;
            label4.Text = "Věk do";
            // 
            // textBox_ageMax
            // 
            errorProvider.SetIconAlignment(textBox_ageMax, ErrorIconAlignment.MiddleLeft);
            textBox_ageMax.Location = new Point(375, 46);
            textBox_ageMax.Name = "textBox_ageMax";
            textBox_ageMax.Size = new Size(54, 23);
            textBox_ageMax.TabIndex = 3;
            textBox_ageMax.KeyDown += textBox_ageMax_KeyDown;
            textBox_ageMax.Validating += textBox_ageMax_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 28);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 11;
            label3.Text = "Věk od*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 28);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Zkratka*";
            // 
            // textBox_ageMin
            // 
            errorProvider.SetIconAlignment(textBox_ageMin, ErrorIconAlignment.MiddleLeft);
            textBox_ageMin.Location = new Point(306, 46);
            textBox_ageMin.Name = "textBox_ageMin";
            textBox_ageMin.Size = new Size(54, 23);
            textBox_ageMin.TabIndex = 2;
            textBox_ageMin.KeyDown += textBox_ageMin_KeyDown;
            textBox_ageMin.Validating += textBox_ageMin_Validating;
            // 
            // textBox_code
            // 
            errorProvider.SetIconAlignment(textBox_code, ErrorIconAlignment.MiddleLeft);
            textBox_code.Location = new Point(198, 46);
            textBox_code.Name = "textBox_code";
            textBox_code.Size = new Size(93, 23);
            textBox_code.TabIndex = 1;
            textBox_code.Validating += textBox_code_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Název*";
            // 
            // textBox_name
            // 
            errorProvider.SetIconAlignment(textBox_name, ErrorIconAlignment.MiddleLeft);
            textBox_name.Location = new Point(30, 46);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(152, 23);
            textBox_name.TabIndex = 0;
            textBox_name.Validating += textBox_name_Validating;
            // 
            // button_add
            // 
            button_add.Location = new Point(622, 34);
            button_add.Name = "button_add";
            button_add.Size = new Size(90, 33);
            button_add.TabIndex = 6;
            button_add.Text = "Přidat";
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(18, 472);
            label6.Name = "label6";
            label6.Size = new Size(236, 15);
            label6.TabIndex = 10;
            label6.Text = "Odstranit kategorie můžete klávesou Delete";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // AgeCategoriesEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(754, 496);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(770, 300);
            Name = "AgeCategoriesEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nastavení věkových kategorií";
            Load += AgeCategoriesEditor_Load;
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource ageCategoryBindingSource;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox textBox_code;
        private Label label1;
        private TextBox textBox_name;
        private Button button_add;
        private Label label5;
        private CheckBox checkBox_duo;
        private Label label4;
        private TextBox textBox_ageMax;
        private Label label3;
        private TextBox textBox_ageMin;
        private Label label6;
        private TextBox textBox_color;
        private ErrorProvider errorProvider;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMaxDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn duoDataGridViewCheckBoxColumn;
    }
}