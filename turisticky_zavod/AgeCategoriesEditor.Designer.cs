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
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(718, 330);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Název";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 64;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            codeDataGridViewTextBoxColumn.HeaderText = "Zkratka";
            codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // ageMinDataGridViewTextBoxColumn
            // 
            ageMinDataGridViewTextBoxColumn.DataPropertyName = "AgeMin";
            ageMinDataGridViewTextBoxColumn.HeaderText = "Věk od";
            ageMinDataGridViewTextBoxColumn.Name = "ageMinDataGridViewTextBoxColumn";
            // 
            // ageMaxDataGridViewTextBoxColumn
            // 
            ageMaxDataGridViewTextBoxColumn.DataPropertyName = "AgeMax";
            dataGridViewCellStyle1.NullValue = "∞";
            ageMaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            ageMaxDataGridViewTextBoxColumn.HeaderText = "Věk do";
            ageMaxDataGridViewTextBoxColumn.Name = "ageMaxDataGridViewTextBoxColumn";
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            colorDataGridViewTextBoxColumn.HeaderText = "Barva";
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            // 
            // duoDataGridViewCheckBoxColumn
            // 
            duoDataGridViewCheckBoxColumn.DataPropertyName = "Duo";
            duoDataGridViewCheckBoxColumn.HeaderText = "Dvojice";
            duoDataGridViewCheckBoxColumn.Name = "duoDataGridViewCheckBoxColumn";
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
            textBox_color.Location = new Point(426, 46);
            textBox_color.Name = "textBox_color";
            textBox_color.Size = new Size(68, 23);
            textBox_color.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(426, 28);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 16;
            label5.Text = "Barva";
            // 
            // checkBox_duo
            // 
            checkBox_duo.AutoSize = true;
            checkBox_duo.Location = new Point(525, 42);
            checkBox_duo.Name = "checkBox_duo";
            checkBox_duo.Size = new Size(65, 19);
            checkBox_duo.TabIndex = 5;
            checkBox_duo.Text = "Dvojice";
            checkBox_duo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 28);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 13;
            label4.Text = "Věk do";
            // 
            // textBox_ageMax
            // 
            textBox_ageMax.Location = new Point(357, 46);
            textBox_ageMax.Name = "textBox_ageMax";
            textBox_ageMax.Size = new Size(54, 23);
            textBox_ageMax.TabIndex = 3;
            textBox_ageMax.KeyDown += textBox_ageMax_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(288, 28);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 11;
            label3.Text = "Věk od";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 28);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Zkratka*";
            // 
            // textBox_ageMin
            // 
            textBox_ageMin.Location = new Point(288, 46);
            textBox_ageMin.Name = "textBox_ageMin";
            textBox_ageMin.Size = new Size(54, 23);
            textBox_ageMin.TabIndex = 2;
            textBox_ageMin.KeyDown += textBox_ageMin_KeyDown;
            // 
            // textBox_code
            // 
            textBox_code.Location = new Point(180, 46);
            textBox_code.Name = "textBox_code";
            textBox_code.Size = new Size(93, 23);
            textBox_code.TabIndex = 1;
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
            textBox_name.Location = new Point(30, 46);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(135, 23);
            textBox_name.TabIndex = 0;
            // 
            // button_add
            // 
            button_add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            label6.Size = new Size(223, 15);
            label6.TabIndex = 10;
            label6.Text = "Upravit kategorie můžete přímo v tabulce";
            // 
            // AgeCategoriesEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMaxDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn duoDataGridViewCheckBoxColumn;
        private TextBox textBox_color;
    }
}