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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            menuStrip1 = new MenuStrip();
            souborToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_close = new ToolStripMenuItem();
            toolStripMenuItem_save = new ToolStripMenuItem();
            toolStripMenuItem_saveAs = new ToolStripMenuItem();
            toolStripMenuItem_import = new ToolStripMenuItem();
            toolStripMenuItem_csvImport = new ToolStripMenuItem();
            toolStripMenuItem_jsonImport = new ToolStripMenuItem();
            toolStripMenuItem_nfcImport = new ToolStripMenuItem();
            toolStripMenuItem_edit = new ToolStripMenuItem();
            toolStripMenuItem_ageCategories = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem_test = new ToolStripMenuItem();
            toolStripMenuItem_testQR = new ToolStripMenuItem();
            nápovědaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_about = new ToolStripMenuItem();
            toolStripMenuItem_debug = new ToolStripMenuItem();
            toolStripMenuItem_log = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            runnerBindingSource = new BindingSource(components);
            runnersGroupBox = new GroupBox();
            StartNumber = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            BirthYear = new DataGridViewTextBoxColumn();
            Team = new DataGridViewTextBoxColumn();
            AgeCategory = new DataGridViewTextBoxColumn();
            PartnerFirstName = new DataGridViewTextBoxColumn();
            PartnerLastName = new DataGridViewTextBoxColumn();
            PartnerBirthYear = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            runnersGroupBox.SuspendLayout();
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
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.MenuBar;
            menuStrip1.Items.AddRange(new ToolStripItem[] { souborToolStripMenuItem, toolStripMenuItem_edit, nápovědaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1164, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            souborToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_close, toolStripMenuItem_save, toolStripMenuItem_saveAs, toolStripMenuItem_import });
            souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            souborToolStripMenuItem.Size = new Size(57, 20);
            souborToolStripMenuItem.Text = "Soubor";
            // 
            // toolStripMenuItem_close
            // 
            toolStripMenuItem_close.Name = "toolStripMenuItem_close";
            toolStripMenuItem_close.Size = new Size(129, 22);
            toolStripMenuItem_close.Text = "Zavřít";
            toolStripMenuItem_close.Click += CloseToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_save
            // 
            toolStripMenuItem_save.Name = "toolStripMenuItem_save";
            toolStripMenuItem_save.Size = new Size(129, 22);
            toolStripMenuItem_save.Text = "Uložit";
            toolStripMenuItem_save.Click += SaveToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_saveAs
            // 
            toolStripMenuItem_saveAs.Name = "toolStripMenuItem_saveAs";
            toolStripMenuItem_saveAs.Size = new Size(129, 22);
            toolStripMenuItem_saveAs.Text = "Uložit jako";
            toolStripMenuItem_saveAs.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_import
            // 
            toolStripMenuItem_import.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_csvImport, toolStripMenuItem_jsonImport, toolStripMenuItem_nfcImport });
            toolStripMenuItem_import.Name = "toolStripMenuItem_import";
            toolStripMenuItem_import.Size = new Size(129, 22);
            toolStripMenuItem_import.Text = "Načíst";
            // 
            // toolStripMenuItem_csvImport
            // 
            toolStripMenuItem_csvImport.Name = "toolStripMenuItem_csvImport";
            toolStripMenuItem_csvImport.Size = new Size(182, 22);
            toolStripMenuItem_csvImport.Text = "CSV (data závodu)";
            toolStripMenuItem_csvImport.Click += CSVImportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_jsonImport
            // 
            toolStripMenuItem_jsonImport.Name = "toolStripMenuItem_jsonImport";
            toolStripMenuItem_jsonImport.Size = new Size(182, 22);
            toolStripMenuItem_jsonImport.Text = "JSON (data aplikace)";
            toolStripMenuItem_jsonImport.Click += JSONImportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_nfcImport
            // 
            toolStripMenuItem_nfcImport.Name = "toolStripMenuItem_nfcImport";
            toolStripMenuItem_nfcImport.Size = new Size(182, 22);
            toolStripMenuItem_nfcImport.Text = "NFC čipy";
            toolStripMenuItem_nfcImport.Click += NFCImportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_edit
            // 
            toolStripMenuItem_edit.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_ageCategories, toolStripSeparator1, toolStripMenuItem_test, toolStripMenuItem_testQR });
            toolStripMenuItem_edit.Name = "toolStripMenuItem_edit";
            toolStripMenuItem_edit.Size = new Size(57, 20);
            toolStripMenuItem_edit.Text = "Upravit";
            // 
            // toolStripMenuItem_ageCategories
            // 
            toolStripMenuItem_ageCategories.Name = "toolStripMenuItem_ageCategories";
            toolStripMenuItem_ageCategories.Size = new Size(163, 22);
            toolStripMenuItem_ageCategories.Text = "Věkové kategorie";
            toolStripMenuItem_ageCategories.Click += AgeCategoriesToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(160, 6);
            // 
            // toolStripMenuItem_test
            // 
            toolStripMenuItem_test.Name = "toolStripMenuItem_test";
            toolStripMenuItem_test.Size = new Size(163, 22);
            toolStripMenuItem_test.Text = "Test Wifi";
            toolStripMenuItem_test.Click += TestWifiToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_testQR
            // 
            toolStripMenuItem_testQR.Name = "toolStripMenuItem_testQR";
            toolStripMenuItem_testQR.Size = new Size(163, 22);
            toolStripMenuItem_testQR.Text = "Test QR";
            toolStripMenuItem_testQR.Click += TestQRToolStripMenuItem_Click;
            // 
            // nápovědaToolStripMenuItem
            // 
            nápovědaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_about, toolStripMenuItem_debug });
            nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            nápovědaToolStripMenuItem.Size = new Size(73, 20);
            nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // toolStripMenuItem_about
            // 
            toolStripMenuItem_about.Name = "toolStripMenuItem_about";
            toolStripMenuItem_about.Size = new Size(126, 22);
            toolStripMenuItem_about.Text = "O aplikaci";
            // 
            // toolStripMenuItem_debug
            // 
            toolStripMenuItem_debug.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_log });
            toolStripMenuItem_debug.Name = "toolStripMenuItem_debug";
            toolStripMenuItem_debug.Size = new Size(126, 22);
            toolStripMenuItem_debug.Text = "Ladění";
            // 
            // toolStripMenuItem_log
            // 
            toolStripMenuItem_log.Name = "toolStripMenuItem_log";
            toolStripMenuItem_log.Size = new Size(94, 22);
            toolStripMenuItem_log.Text = "Log";
            toolStripMenuItem_log.Click += LogToolStripMenuItem_Click;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StartNumber, FirstName, LastName, BirthYear, Team, AgeCategory, PartnerFirstName, PartnerLastName, PartnerBirthYear });
            dataGridView1.DataSource = runnerBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 60;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1128, 472);
            dataGridView1.TabIndex = 3;
            dataGridView1.RowsAdded += DataGridView_RowsAdded;
            dataGridView1.DragDrop += DataGridView_DragDrop;
            dataGridView1.DragEnter += DataGridView_DragEnter;
            dataGridView1.KeyDown += DataGridView_KeyDown;
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
            // StartNumber
            // 
            StartNumber.DataPropertyName = "StartNumber";
            StartNumber.HeaderText = "Startovní číslo";
            StartNumber.Name = "StartNumber";
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "Jméno";
            FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "Příjmení";
            LastName.Name = "LastName";
            // 
            // BirthYear
            // 
            BirthYear.DataPropertyName = "BirthYear";
            dataGridViewCellStyle1.NullValue = "-";
            BirthYear.DefaultCellStyle = dataGridViewCellStyle1;
            BirthYear.HeaderText = "Ročník";
            BirthYear.Name = "BirthYear";
            // 
            // Team
            // 
            Team.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Team.DataPropertyName = "Team";
            Team.HeaderText = "Oddíl";
            Team.Name = "Team";
            Team.Width = 61;
            // 
            // AgeCategory
            // 
            AgeCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            AgeCategory.DataPropertyName = "AgeCategory";
            dataGridViewCellStyle2.NullValue = "-";
            AgeCategory.DefaultCellStyle = dataGridViewCellStyle2;
            AgeCategory.HeaderText = "Věková kategorie";
            AgeCategory.Name = "AgeCategory";
            AgeCategory.ReadOnly = true;
            AgeCategory.Width = 111;
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
            PartnerBirthYear.HeaderText = "Ročník 2";
            PartnerBirthYear.Name = "PartnerBirthYear";
            PartnerBirthYear.ReadOnly = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1164, 561);
            Controls.Add(runnersGroupBox);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1180, 215);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Turistický závod";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).EndInit();
            runnersGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem toolStripMenuItem_edit;
        private ToolStripMenuItem toolStripMenuItem_ageCategories;
        private DataGridView dataGridView1;
        private GroupBox runnersGroupBox;
        private ToolStripMenuItem toolStripMenuItem_test;
        private ToolStripMenuItem toolStripMenuItem_testQR;
        private ToolStripMenuItem nápovědaToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_about;
        private ToolStripMenuItem toolStripMenuItem_debug;
        private ToolStripMenuItem toolStripMenuItem_log;
        private BindingSource runnerBindingSource;
        private ToolStripMenuItem souborToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_close;
        private ToolStripMenuItem toolStripMenuItem_save;
        private ToolStripMenuItem toolStripMenuItem_import;
        private ToolStripMenuItem toolStripMenuItem_csvImport;
        private ToolStripMenuItem toolStripMenuItem_jsonImport;
        private ToolStripMenuItem toolStripMenuItem_nfcImport;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem_saveAs;
        private DataGridViewTextBoxColumn StartNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn BirthYear;
        private DataGridViewTextBoxColumn Team;
        private DataGridViewTextBoxColumn AgeCategory;
        private DataGridViewTextBoxColumn PartnerFirstName;
        private DataGridViewTextBoxColumn PartnerLastName;
        private DataGridViewTextBoxColumn PartnerBirthYear;
    }
}