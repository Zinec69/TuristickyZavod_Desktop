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
            toolStripMenuItem_fileImport = new ToolStripMenuItem();
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
            dataGridView_runners = new DataGridView();
            runnerBindingSource = new BindingSource(components);
            groupBox_runnersList = new GroupBox();
            groupBox_edit = new GroupBox();
            label_ageCategory = new Label();
            comboBox_ageCategory = new ComboBox();
            label_duo = new Label();
            label_birthYear_partner = new Label();
            textBox_birthYear_partner = new TextBox();
            label_name_partner = new Label();
            textBox_name_partner = new TextBox();
            label_team = new Label();
            comboBox_team = new ComboBox();
            label_birthYear = new Label();
            textBox_birthYear = new TextBox();
            label_name = new Label();
            textBox_name = new TextBox();
            label_startNumber = new Label();
            textBox_startNumber = new TextBox();
            button_save = new Button();
            errorProvider = new ErrorProvider(components);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView_runners).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            groupBox_runnersList.SuspendLayout();
            groupBox_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 648);
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
            toolStripMenuItem_import.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_fileImport, toolStripMenuItem_nfcImport });
            toolStripMenuItem_import.Name = "toolStripMenuItem_import";
            toolStripMenuItem_import.Size = new Size(129, 22);
            toolStripMenuItem_import.Text = "Načíst";
            // 
            // toolStripMenuItem_fileImport
            // 
            toolStripMenuItem_fileImport.Name = "toolStripMenuItem_fileImport";
            toolStripMenuItem_fileImport.Size = new Size(122, 22);
            toolStripMenuItem_fileImport.Text = "Soubor";
            toolStripMenuItem_fileImport.Click += FileImportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem_nfcImport
            // 
            toolStripMenuItem_nfcImport.Name = "toolStripMenuItem_nfcImport";
            toolStripMenuItem_nfcImport.Size = new Size(122, 22);
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
            // dataGridView_runners
            // 
            dataGridView_runners.AllowDrop = true;
            dataGridView_runners.AllowUserToAddRows = false;
            dataGridView_runners.AllowUserToDeleteRows = false;
            dataGridView_runners.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_runners.AutoGenerateColumns = false;
            dataGridView_runners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_runners.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_runners.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView_runners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_runners.Columns.AddRange(new DataGridViewColumn[] { StartNumber, FirstName, LastName, BirthYear, Team, AgeCategory, PartnerFirstName, PartnerLastName, PartnerBirthYear });
            dataGridView_runners.DataSource = runnerBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView_runners.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView_runners.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView_runners.Location = new Point(6, 22);
            dataGridView_runners.MultiSelect = false;
            dataGridView_runners.Name = "dataGridView_runners";
            dataGridView_runners.RowHeadersWidth = 60;
            dataGridView_runners.RowTemplate.Height = 25;
            dataGridView_runners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_runners.Size = new Size(1128, 482);
            dataGridView_runners.TabIndex = 3;
            dataGridView_runners.CurrentCellChanged += DataGridView_Runners_CurrentCellChanged;
            dataGridView_runners.RowsAdded += DataGridView_Runners_RowsAdded;
            dataGridView_runners.DragDrop += DataGridView_Runners_DragDrop;
            dataGridView_runners.DragEnter += DataGridView_Runners_DragEnter;
            dataGridView_runners.KeyDown += DataGridView_Runners_KeyDown;
            // 
            // runnerBindingSource
            // 
            runnerBindingSource.DataSource = typeof(Data.Runner);
            // 
            // groupBox_runnersList
            // 
            groupBox_runnersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_runnersList.Controls.Add(dataGridView_runners);
            groupBox_runnersList.Location = new Point(12, 135);
            groupBox_runnersList.Name = "groupBox_runnersList";
            groupBox_runnersList.Size = new Size(1140, 510);
            groupBox_runnersList.TabIndex = 4;
            groupBox_runnersList.TabStop = false;
            groupBox_runnersList.Text = "Seznam běžců";
            // 
            // groupBox_edit
            // 
            groupBox_edit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_edit.Controls.Add(label_ageCategory);
            groupBox_edit.Controls.Add(comboBox_ageCategory);
            groupBox_edit.Controls.Add(label_duo);
            groupBox_edit.Controls.Add(label_birthYear_partner);
            groupBox_edit.Controls.Add(textBox_birthYear_partner);
            groupBox_edit.Controls.Add(label_name_partner);
            groupBox_edit.Controls.Add(textBox_name_partner);
            groupBox_edit.Controls.Add(label_team);
            groupBox_edit.Controls.Add(comboBox_team);
            groupBox_edit.Controls.Add(label_birthYear);
            groupBox_edit.Controls.Add(textBox_birthYear);
            groupBox_edit.Controls.Add(label_name);
            groupBox_edit.Controls.Add(textBox_name);
            groupBox_edit.Controls.Add(label_startNumber);
            groupBox_edit.Controls.Add(textBox_startNumber);
            groupBox_edit.Controls.Add(button_save);
            groupBox_edit.Location = new Point(12, 27);
            groupBox_edit.Name = "groupBox_edit";
            groupBox_edit.Padding = new Padding(20, 22, 20, 22);
            groupBox_edit.Size = new Size(1140, 102);
            groupBox_edit.TabIndex = 7;
            groupBox_edit.TabStop = false;
            groupBox_edit.Text = "Přidat/upravit běžce";
            // 
            // label_ageCategory
            // 
            label_ageCategory.AutoSize = true;
            label_ageCategory.Location = new Point(564, 32);
            label_ageCategory.Name = "label_ageCategory";
            label_ageCategory.Size = new Size(101, 15);
            label_ageCategory.TabIndex = 22;
            label_ageCategory.Text = "Věková kategorie*";
            // 
            // comboBox_ageCategory
            // 
            comboBox_ageCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ageCategory.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_ageCategory, ErrorIconAlignment.MiddleLeft);
            comboBox_ageCategory.Location = new Point(564, 50);
            comboBox_ageCategory.Margin = new Padding(3, 3, 16, 3);
            comboBox_ageCategory.Name = "comboBox_ageCategory";
            comboBox_ageCategory.Size = new Size(156, 23);
            comboBox_ageCategory.TabIndex = 21;
            comboBox_ageCategory.Validating += ComboBox_AgeCategory_Validating;
            // 
            // label_duo
            // 
            label_duo.AutoSize = true;
            label_duo.Location = new Point(749, 0);
            label_duo.Name = "label_duo";
            label_duo.Size = new Size(46, 15);
            label_duo.TabIndex = 20;
            label_duo.Text = "Dvojice";
            // 
            // label_birthYear_partner
            // 
            label_birthYear_partner.AutoSize = true;
            label_birthYear_partner.Location = new Point(922, 32);
            label_birthYear_partner.Name = "label_birthYear_partner";
            label_birthYear_partner.Size = new Size(43, 15);
            label_birthYear_partner.TabIndex = 19;
            label_birthYear_partner.Text = "Ročník";
            // 
            // textBox_birthYear_partner
            // 
            errorProvider.SetIconAlignment(textBox_birthYear_partner, ErrorIconAlignment.MiddleLeft);
            textBox_birthYear_partner.Location = new Point(922, 50);
            textBox_birthYear_partner.Margin = new Padding(3, 3, 20, 3);
            textBox_birthYear_partner.Name = "textBox_birthYear_partner";
            textBox_birthYear_partner.Size = new Size(60, 23);
            textBox_birthYear_partner.TabIndex = 18;
            textBox_birthYear_partner.KeyDown += TextBox_BirthYear_Partner_KeyDown;
            textBox_birthYear_partner.Validating += TextBox_BirthYear_Partner_Validating;
            // 
            // label_name_partner
            // 
            label_name_partner.AutoSize = true;
            label_name_partner.Location = new Point(753, 32);
            label_name_partner.Name = "label_name_partner";
            label_name_partner.Size = new Size(42, 15);
            label_name_partner.TabIndex = 17;
            label_name_partner.Text = "Jméno";
            // 
            // textBox_name_partner
            // 
            errorProvider.SetIconAlignment(textBox_name_partner, ErrorIconAlignment.MiddleLeft);
            textBox_name_partner.Location = new Point(753, 50);
            textBox_name_partner.Margin = new Padding(3, 3, 16, 3);
            textBox_name_partner.Name = "textBox_name_partner";
            textBox_name_partner.Size = new Size(150, 23);
            textBox_name_partner.TabIndex = 16;
            textBox_name_partner.KeyUp += TextBox_Name_Partner_KeyUp;
            textBox_name_partner.Validating += TextBox_Name_Partner_Validating;
            // 
            // label_team
            // 
            label_team.AutoSize = true;
            label_team.Location = new Point(389, 32);
            label_team.Name = "label_team";
            label_team.Size = new Size(41, 15);
            label_team.TabIndex = 15;
            label_team.Text = "Oddíl*";
            // 
            // comboBox_team
            // 
            comboBox_team.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_team, ErrorIconAlignment.MiddleLeft);
            comboBox_team.Location = new Point(389, 50);
            comboBox_team.Margin = new Padding(3, 3, 16, 3);
            comboBox_team.Name = "comboBox_team";
            comboBox_team.Size = new Size(156, 23);
            comboBox_team.TabIndex = 14;
            comboBox_team.Validating += ComboBox_Team_Validating;
            // 
            // label_birthYear
            // 
            label_birthYear.AutoSize = true;
            label_birthYear.Location = new Point(310, 32);
            label_birthYear.Name = "label_birthYear";
            label_birthYear.Size = new Size(48, 15);
            label_birthYear.TabIndex = 13;
            label_birthYear.Text = "Ročník*";
            // 
            // textBox_birthYear
            // 
            errorProvider.SetIconAlignment(textBox_birthYear, ErrorIconAlignment.MiddleLeft);
            textBox_birthYear.Location = new Point(310, 50);
            textBox_birthYear.Margin = new Padding(3, 3, 16, 3);
            textBox_birthYear.Name = "textBox_birthYear";
            textBox_birthYear.Size = new Size(60, 23);
            textBox_birthYear.TabIndex = 12;
            textBox_birthYear.KeyDown += TextBox_BirthYear_KeyDown;
            textBox_birthYear.KeyUp += TextBox_BirthYear_KeyUp;
            textBox_birthYear.Validating += TextBox_BirthYear_Validating;
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(141, 32);
            label_name.Name = "label_name";
            label_name.Size = new Size(47, 15);
            label_name.TabIndex = 11;
            label_name.Text = "Jméno*";
            // 
            // textBox_name
            // 
            errorProvider.SetIconAlignment(textBox_name, ErrorIconAlignment.MiddleLeft);
            textBox_name.Location = new Point(141, 50);
            textBox_name.Margin = new Padding(3, 3, 16, 3);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(150, 23);
            textBox_name.TabIndex = 10;
            textBox_name.Validating += TextBox_Name_Validating;
            // 
            // label_startNumber
            // 
            label_startNumber.AutoSize = true;
            label_startNumber.Location = new Point(23, 32);
            label_startNumber.Name = "label_startNumber";
            label_startNumber.Size = new Size(81, 15);
            label_startNumber.TabIndex = 9;
            label_startNumber.Text = "Startovní číslo";
            // 
            // textBox_startNumber
            // 
            errorProvider.SetIconAlignment(textBox_startNumber, ErrorIconAlignment.MiddleLeft);
            textBox_startNumber.Location = new Point(23, 50);
            textBox_startNumber.Margin = new Padding(3, 3, 16, 3);
            textBox_startNumber.Name = "textBox_startNumber";
            textBox_startNumber.Size = new Size(99, 23);
            textBox_startNumber.TabIndex = 8;
            textBox_startNumber.KeyDown += TextBox_StartNumber_KeyDown;
            // 
            // button_save
            // 
            button_save.Location = new Point(1030, 40);
            button_save.Margin = new Padding(0);
            button_save.Name = "button_save";
            button_save.Size = new Size(90, 33);
            button_save.TabIndex = 7;
            button_save.Text = "Přidat";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += Button_Save_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
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
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1164, 670);
            Controls.Add(groupBox_edit);
            Controls.Add(groupBox_runnersList);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1180, 300);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Turistický závod";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_runners).EndInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).EndInit();
            groupBox_runnersList.ResumeLayout(false);
            groupBox_edit.ResumeLayout(false);
            groupBox_edit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
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
        private DataGridView dataGridView_runners;
        private GroupBox groupBox_runnersList;
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
        private ToolStripMenuItem toolStripMenuItem_fileImport;
        private ToolStripMenuItem toolStripMenuItem_nfcImport;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem_saveAs;
        private GroupBox groupBox_edit;
        private Button button_save;
        private Label label_team;
        private ComboBox comboBox_team;
        private Label label_birthYear;
        private TextBox textBox_birthYear;
        private Label label_name;
        private TextBox textBox_name;
        private Label label_startNumber;
        private TextBox textBox_startNumber;
        private Label label_duo;
        private Label label_birthYear_partner;
        private TextBox textBox_birthYear_partner;
        private Label label_name_partner;
        private TextBox textBox_name_partner;
        private Label label_ageCategory;
        private ComboBox comboBox_ageCategory;
        private ErrorProvider errorProvider;
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