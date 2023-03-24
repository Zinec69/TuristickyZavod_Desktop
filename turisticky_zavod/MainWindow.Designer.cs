namespace turisticky_zavod.Forms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            dataGridView1 = new DataGridView();
            runnerBindingSource = new BindingSource(components);
            runnersGroupBox = new GroupBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem_dataImport = new ToolStripMenuItem();
            toolStripMenuItem_csv = new ToolStripMenuItem();
            toolStripMenuItem_json = new ToolStripMenuItem();
            toolStripMenuItem_nfc = new ToolStripMenuItem();
            toolStripMenuItem_settings = new ToolStripMenuItem();
            toolStripMenuItem_ageCategories = new ToolStripMenuItem();
            runnerIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            BirthYear = new DataGridViewTextBoxColumn();
            PartnerFirstName = new DataGridViewTextBoxColumn();
            PartnerLastName = new DataGridViewTextBoxColumn();
            PartnerBirthYear = new DataGridViewTextBoxColumn();
            teamDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            AgeCategory = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            runnersGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1164, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            toolStripProgressBar1.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { runnerIDDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, BirthYear, PartnerFirstName, PartnerLastName, PartnerBirthYear, teamDataGridViewTextBoxColumn, AgeCategory });
            dataGridView1.DataSource = runnerBindingSource;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1128, 472);
            dataGridView1.TabIndex = 3;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            // 
            // runnerBindingSource
            // 
            runnerBindingSource.DataSource = typeof(Data.Runner);
            // 
            // runnersGroupBox
            // 
            runnersGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            runnersGroupBox.Controls.Add(dataGridView1);
            runnersGroupBox.Location = new Point(12, 36);
            runnersGroupBox.Name = "runnersGroupBox";
            runnersGroupBox.Size = new Size(1140, 500);
            runnersGroupBox.TabIndex = 4;
            runnersGroupBox.TabStop = false;
            runnersGroupBox.Text = "Seznam běžců";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_dataImport, toolStripMenuItem_settings });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1164, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_dataImport
            // 
            toolStripMenuItem_dataImport.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_csv, toolStripMenuItem_json, toolStripMenuItem_nfc });
            toolStripMenuItem_dataImport.Name = "toolStripMenuItem_dataImport";
            toolStripMenuItem_dataImport.Size = new Size(75, 20);
            toolStripMenuItem_dataImport.Text = "Import dat";
            // 
            // toolStripMenuItem_csv
            // 
            toolStripMenuItem_csv.Name = "toolStripMenuItem_csv";
            toolStripMenuItem_csv.Size = new Size(102, 22);
            toolStripMenuItem_csv.Text = "CSV";
            toolStripMenuItem_csv.Click += CSVToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_json
            // 
            toolStripMenuItem_json.Name = "toolStripMenuItem_json";
            toolStripMenuItem_json.Size = new Size(102, 22);
            toolStripMenuItem_json.Text = "JSON";
            toolStripMenuItem_json.Click += JSONToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_nfc
            // 
            toolStripMenuItem_nfc.Name = "toolStripMenuItem_nfc";
            toolStripMenuItem_nfc.Size = new Size(102, 22);
            toolStripMenuItem_nfc.Text = "NFC";
            toolStripMenuItem_nfc.Click += NFCToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_settings
            // 
            toolStripMenuItem_settings.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_ageCategories });
            toolStripMenuItem_settings.Name = "toolStripMenuItem_settings";
            toolStripMenuItem_settings.Size = new Size(71, 20);
            toolStripMenuItem_settings.Text = "Nastavení";
            // 
            // toolStripMenuItem_ageCategories
            // 
            toolStripMenuItem_ageCategories.Name = "toolStripMenuItem_ageCategories";
            toolStripMenuItem_ageCategories.Size = new Size(163, 22);
            toolStripMenuItem_ageCategories.Text = "Věkové kategorie";
            // 
            // runnerIDDataGridViewTextBoxColumn
            // 
            runnerIDDataGridViewTextBoxColumn.DataPropertyName = "RunnerID";
            runnerIDDataGridViewTextBoxColumn.HeaderText = "Startovní číslo";
            runnerIDDataGridViewTextBoxColumn.Name = "runnerIDDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "Jméno";
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "Příjmení";
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // BirthYear
            // 
            BirthYear.DataPropertyName = "BirthYear";
            dataGridViewCellStyle1.NullValue = "-";
            BirthYear.DefaultCellStyle = dataGridViewCellStyle1;
            BirthYear.HeaderText = "Ročník";
            BirthYear.Name = "BirthYear";
            // 
            // PartnerFirstName
            // 
            PartnerFirstName.DataPropertyName = "PartnerFirstName";
            PartnerFirstName.HeaderText = "Jméno 2";
            PartnerFirstName.Name = "PartnerFirstName";
            PartnerFirstName.ReadOnly = true;
            // 
            // PartnerLastName
            // 
            PartnerLastName.DataPropertyName = "PartnerLastName";
            PartnerLastName.HeaderText = "Příjmení 2";
            PartnerLastName.Name = "PartnerLastName";
            PartnerLastName.ReadOnly = true;
            // 
            // PartnerBirthYear
            // 
            PartnerBirthYear.DataPropertyName = "PartnerBirthYear";
            dataGridViewCellStyle2.NullValue = "-";
            PartnerBirthYear.DefaultCellStyle = dataGridViewCellStyle2;
            PartnerBirthYear.HeaderText = "Ročník 2";
            PartnerBirthYear.Name = "PartnerBirthYear";
            PartnerBirthYear.ReadOnly = true;
            // 
            // teamDataGridViewTextBoxColumn
            // 
            teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            teamDataGridViewTextBoxColumn.HeaderText = "Oddíl";
            teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            // 
            // AgeCategory
            // 
            AgeCategory.DataPropertyName = "AgeCategory";
            dataGridViewCellStyle3.NullValue = "-";
            AgeCategory.DefaultCellStyle = dataGridViewCellStyle3;
            AgeCategory.HeaderText = "Věková kategorie";
            AgeCategory.Name = "AgeCategory";
            AgeCategory.ReadOnly = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 561);
            Controls.Add(runnersGroupBox);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1180, 215);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Turistický závod";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).EndInit();
            runnersGroupBox.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridView dataGridView1;
        private GroupBox runnersGroupBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem_dataImport;
        private ToolStripMenuItem toolStripMenuItem_csv;
        private ToolStripMenuItem toolStripMenuItem_json;
        private ToolStripMenuItem toolStripMenuItem_nfc;
        private BindingSource runnerBindingSource;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem toolStripMenuItem_settings;
        private ToolStripMenuItem toolStripMenuItem_ageCategories;
        private DataGridViewTextBoxColumn runnerIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn BirthYear;
        private DataGridViewTextBoxColumn PartnerFirstName;
        private DataGridViewTextBoxColumn PartnerLastName;
        private DataGridViewTextBoxColumn PartnerBirthYear;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AgeCategory;
    }
}