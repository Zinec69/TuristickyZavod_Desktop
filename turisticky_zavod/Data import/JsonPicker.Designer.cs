namespace turisticky_zavod.Forms
{
    partial class JsonPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonPicker));
            dataGridView1 = new DataGridView();
            StartNumber = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            teamDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            FinishTime = new DataGridViewTextBoxColumn();
            disqualifiedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            runnerBindingSource = new BindingSource(components);
            button_cancel = new Button();
            button_save = new Button();
            groupBox1 = new GroupBox();
            label_title = new Label();
            label_hint = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StartNumber, FirstName, LastName, teamDataGridViewTextBoxColumn, StartTime, FinishTime, disqualifiedDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = runnerBindingSource;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(8, 22);
            dataGridView1.Margin = new Padding(5, 2, 5, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(780, 311);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            // 
            // StartNumber
            // 
            StartNumber.DataPropertyName = "StartNumber";
            StartNumber.HeaderText = "Startovní číslo";
            StartNumber.Name = "StartNumber";
            StartNumber.ReadOnly = true;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "Jméno";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "Příjmení";
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            // 
            // teamDataGridViewTextBoxColumn
            // 
            teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            teamDataGridViewTextBoxColumn.HeaderText = "Oddíl";
            teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            teamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StartTime
            // 
            StartTime.DataPropertyName = "StartTime";
            dataGridViewCellStyle1.Format = "T";
            dataGridViewCellStyle1.NullValue = "-";
            StartTime.DefaultCellStyle = dataGridViewCellStyle1;
            StartTime.HeaderText = "Čas startu";
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            // 
            // FinishTime
            // 
            FinishTime.DataPropertyName = "FinishTime";
            dataGridViewCellStyle2.Format = "T";
            dataGridViewCellStyle2.NullValue = "-";
            FinishTime.DefaultCellStyle = dataGridViewCellStyle2;
            FinishTime.HeaderText = "Čas konce";
            FinishTime.Name = "FinishTime";
            FinishTime.ReadOnly = true;
            // 
            // disqualifiedDataGridViewCheckBoxColumn
            // 
            disqualifiedDataGridViewCheckBoxColumn.DataPropertyName = "Disqualified";
            disqualifiedDataGridViewCheckBoxColumn.HeaderText = "Diskvalifikován/a";
            disqualifiedDataGridViewCheckBoxColumn.Name = "disqualifiedDataGridViewCheckBoxColumn";
            disqualifiedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // runnerBindingSource
            // 
            runnerBindingSource.DataSource = typeof(Data.Runner);
            // 
            // button_cancel
            // 
            button_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_cancel.Location = new Point(709, 419);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(88, 30);
            button_cancel.TabIndex = 2;
            button_cancel.Text = "Zrušit";
            button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            button_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_save.Location = new Point(615, 419);
            button_save.Name = "button_save";
            button_save.Size = new Size(88, 30);
            button_save.TabIndex = 1;
            button_save.Text = "Uložit";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(9, 68);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(796, 341);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seznam běžců";
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label_title.Location = new Point(12, 9);
            label_title.Name = "label_title";
            label_title.Size = new Size(284, 25);
            label_title.TabIndex = 4;
            label_title.Text = "Zvolte běžce, které chcete přidat";
            // 
            // label_hint
            // 
            label_hint.AutoSize = true;
            label_hint.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label_hint.Location = new Point(15, 37);
            label_hint.Name = "label_hint";
            label_hint.Size = new Size(506, 15);
            label_hint.TabIndex = 5;
            label_hint.Text = "(Více řádků zvolíte kliknutím se zmáčknutou klávesou ctrl, popř. kliknutím a tažením přes řádky)";
            // 
            // JsonPicker
            // 
            AcceptButton = button_save;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_cancel;
            ClientSize = new Size(814, 461);
            Controls.Add(label_hint);
            Controls.Add(label_title);
            Controls.Add(groupBox1);
            Controls.Add(button_save);
            Controls.Add(button_cancel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(830, 240);
            Name = "JsonPicker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Načíst z Jsonu";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button_cancel;
        private Button button_save;
        private GroupBox groupBox1;
        private BindingSource runnerBindingSource;
        private DataGridViewTextBoxColumn runnerIDDataGridViewTextBoxColumn;
        private Label label_title;
        private Label label_hint;
        private DataGridViewTextBoxColumn StartNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn FinishTime;
        private DataGridViewCheckBoxColumn disqualifiedDataGridViewCheckBoxColumn;
    }
}