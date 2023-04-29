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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            menuStrip1 = new MenuStrip();
            souborToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_close = new ToolStripMenuItem();
            toolStripMenuItem_reset = new ToolStripMenuItem();
            toolStripMenuItem_save = new ToolStripMenuItem();
            toolStripMenuItem_saveAs = new ToolStripMenuItem();
            toolStripMenuItem_import = new ToolStripMenuItem();
            toolStripMenuItem_fileImport = new ToolStripMenuItem();
            toolStripMenuItem_nfcImport = new ToolStripMenuItem();
            toolStripMenuItem_edit = new ToolStripMenuItem();
            toolStripMenuItem_ageCategories = new ToolStripMenuItem();
            nápovědaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_about = new ToolStripMenuItem();
            toolStripMenuItem_debug = new ToolStripMenuItem();
            toolStripMenuItem_log = new ToolStripMenuItem();
            dataGridView_runners = new DataGridView();
            runnerBindingSource = new BindingSource(components);
            groupBox_runnersList = new GroupBox();
            groupBox_edit = new GroupBox();
            dateTimePicker_birthdate_partner = new DateTimePicker();
            label_birthdate_partner = new Label();
            label_gender_partner = new Label();
            comboBox_gender_partner = new ComboBox();
            label_gender = new Label();
            comboBox_gender = new ComboBox();
            dateTimePicker_birthdate = new DateTimePicker();
            label_ageCategory = new Label();
            comboBox_ageCategory = new ComboBox();
            label_duo = new Label();
            label_name_partner = new Label();
            textBox_name_partner = new TextBox();
            label_team = new Label();
            comboBox_team = new ComboBox();
            label_birthdate = new Label();
            label_name = new Label();
            textBox_name = new TextBox();
            label_startNumber = new Label();
            textBox_startNumber = new TextBox();
            button_save = new Button();
            errorProvider = new ErrorProvider(components);
            maskedTextBox_penalty = new MaskedTextBox();
            maskedTextBox_timeWaited = new MaskedTextBox();
            comboBox_checkpoints_checkpointInfo = new ComboBox();
            tabControl = new TabControl();
            tabPage_start = new TabPage();
            tabPage_results = new TabPage();
            groupBox1 = new GroupBox();
            textBox_startNumber_checkpointInfo = new TextBox();
            button_add_checkpointInfo = new Button();
            checkBox_disqualified_checkpointInfo = new CheckBox();
            label_penalty = new Label();
            label_timeWaited = new Label();
            label_checkpoints_checkpointInfo = new Label();
            label_ageCategory_checkpointInfo = new Label();
            textBox_ageCategory_checkpointInfo = new TextBox();
            label_team_checkpointInfo = new Label();
            textBox_team_checkpointInfo = new TextBox();
            label_name_checkpointInfo = new Label();
            textBox_name_checkpointInfo = new TextBox();
            label_startNumber_checkpointInfo = new Label();
            groupBox_runners_results = new GroupBox();
            dataGridView_runners_results = new DataGridView();
            startNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            teamDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            partnerFirstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partnerLastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disqualifiedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            startTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            finishTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            finalRunTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalWaitTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalPenaltyTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBox_checkpoints = new GroupBox();
            dataGridView_runnerCheckpoints = new DataGridView();
            checkpointDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            CheckpointRefereeName = new DataGridViewTextBoxColumn();
            timeWaitedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            penaltyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disqualifiedDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            checkpointRunnerInfoBindingSource = new BindingSource(components);
            groupBox_filter = new GroupBox();
            checkBox_filter_category = new CheckBox();
            checkBox_filter_team = new CheckBox();
            label_category_filter = new Label();
            label_team_filter = new Label();
            comboBox_filter_category = new ComboBox();
            comboBox_filter_team = new ComboBox();
            StartNumber = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Birthdate = new DataGridViewTextBoxColumn();
            Team = new DataGridViewTextBoxColumn();
            AgeCategory = new DataGridViewTextBoxColumn();
            PartnerFirstName = new DataGridViewTextBoxColumn();
            PartnerLastName = new DataGridViewTextBoxColumn();
            PartnerBirthdate = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_runners).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            groupBox_runnersList.SuspendLayout();
            groupBox_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            tabControl.SuspendLayout();
            tabPage_start.SuspendLayout();
            tabPage_results.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox_runners_results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_runners_results).BeginInit();
            groupBox_checkpoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_runnerCheckpoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkpointRunnerInfoBindingSource).BeginInit();
            groupBox_filter.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 689);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1095, 22);
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
            menuStrip1.Size = new Size(1095, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            souborToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_close, toolStripMenuItem_reset, toolStripMenuItem_save, toolStripMenuItem_saveAs, toolStripMenuItem_import });
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
            // toolStripMenuItem_reset
            // 
            toolStripMenuItem_reset.Name = "toolStripMenuItem_reset";
            toolStripMenuItem_reset.Size = new Size(129, 22);
            toolStripMenuItem_reset.Text = "Resetovat";
            toolStripMenuItem_reset.ToolTipText = "Vymaže všechna data a uvede aplikaci do původního stavu";
            toolStripMenuItem_reset.Click += ToolStripMenuItem_Reset_Click;
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
            toolStripMenuItem_edit.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_ageCategories });
            toolStripMenuItem_edit.Name = "toolStripMenuItem_edit";
            toolStripMenuItem_edit.Size = new Size(57, 20);
            toolStripMenuItem_edit.Text = "Upravit";
            // 
            // toolStripMenuItem_ageCategories
            // 
            toolStripMenuItem_ageCategories.Name = "toolStripMenuItem_ageCategories";
            toolStripMenuItem_ageCategories.Size = new Size(228, 22);
            toolStripMenuItem_ageCategories.Text = "Věkové kategorie a stanoviště";
            toolStripMenuItem_ageCategories.Click += AgeCategoriesToolStripMenuItem_Click;
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
            toolStripMenuItem_about.Click += AboutToolStripMenuItem_Click;
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
            dataGridView_runners.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_runners.AutoGenerateColumns = false;
            dataGridView_runners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_runners.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_runners.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView_runners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_runners.Columns.AddRange(new DataGridViewColumn[] { StartNumber, FirstName, LastName, Birthdate, Team, AgeCategory, PartnerFirstName, PartnerLastName, PartnerBirthdate });
            dataGridView_runners.DataSource = runnerBindingSource;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView_runners.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView_runners.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView_runners.Location = new Point(6, 22);
            dataGridView_runners.MultiSelect = false;
            dataGridView_runners.Name = "dataGridView_runners";
            dataGridView_runners.ReadOnly = true;
            dataGridView_runners.RowHeadersWidth = 60;
            dataGridView_runners.RowTemplate.Height = 25;
            dataGridView_runners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_runners.Size = new Size(1039, 427);
            dataGridView_runners.TabIndex = 3;
            dataGridView_runners.CurrentCellChanged += DataGridView_Runners_CurrentCellChanged;
            dataGridView_runners.RowsAdded += DataGridView_Runners_RowsAdded;
            dataGridView_runners.UserDeletedRow += DataGridView_Runners_UserDeletedRow;
            dataGridView_runners.UserDeletingRow += DataGridView_Runners_UserDeletingRow;
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
            groupBox_runnersList.Location = new Point(6, 169);
            groupBox_runnersList.Name = "groupBox_runnersList";
            groupBox_runnersList.Size = new Size(1051, 455);
            groupBox_runnersList.TabIndex = 4;
            groupBox_runnersList.TabStop = false;
            groupBox_runnersList.Text = "Seznam běžců";
            // 
            // groupBox_edit
            // 
            groupBox_edit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_edit.Controls.Add(dateTimePicker_birthdate_partner);
            groupBox_edit.Controls.Add(label_birthdate_partner);
            groupBox_edit.Controls.Add(label_gender_partner);
            groupBox_edit.Controls.Add(comboBox_gender_partner);
            groupBox_edit.Controls.Add(label_gender);
            groupBox_edit.Controls.Add(comboBox_gender);
            groupBox_edit.Controls.Add(dateTimePicker_birthdate);
            groupBox_edit.Controls.Add(label_ageCategory);
            groupBox_edit.Controls.Add(comboBox_ageCategory);
            groupBox_edit.Controls.Add(label_duo);
            groupBox_edit.Controls.Add(label_name_partner);
            groupBox_edit.Controls.Add(textBox_name_partner);
            groupBox_edit.Controls.Add(label_team);
            groupBox_edit.Controls.Add(comboBox_team);
            groupBox_edit.Controls.Add(label_birthdate);
            groupBox_edit.Controls.Add(label_name);
            groupBox_edit.Controls.Add(textBox_name);
            groupBox_edit.Controls.Add(label_startNumber);
            groupBox_edit.Controls.Add(textBox_startNumber);
            groupBox_edit.Controls.Add(button_save);
            groupBox_edit.Location = new Point(6, 6);
            groupBox_edit.Name = "groupBox_edit";
            groupBox_edit.Padding = new Padding(20, 22, 20, 22);
            groupBox_edit.Size = new Size(1051, 157);
            groupBox_edit.TabIndex = 7;
            groupBox_edit.TabStop = false;
            groupBox_edit.Text = "Přidat/upravit běžce";
            // 
            // dateTimePicker_birthdate_partner
            // 
            errorProvider.SetIconAlignment(dateTimePicker_birthdate_partner, ErrorIconAlignment.MiddleLeft);
            dateTimePicker_birthdate_partner.Location = new Point(381, 109);
            dateTimePicker_birthdate_partner.Margin = new Padding(3, 3, 16, 3);
            dateTimePicker_birthdate_partner.MaxDate = new DateTime(2023, 4, 19, 0, 0, 0, 0);
            dateTimePicker_birthdate_partner.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateTimePicker_birthdate_partner.Name = "dateTimePicker_birthdate_partner";
            dateTimePicker_birthdate_partner.Size = new Size(174, 23);
            dateTimePicker_birthdate_partner.TabIndex = 29;
            dateTimePicker_birthdate_partner.Value = new DateTime(2000, 1, 1);
            dateTimePicker_birthdate_partner.ValueChanged += DateTimePicker_Birthdate_Partner_ValueChanged;
            // 
            // label_birthdate_partner
            // 
            label_birthdate_partner.AutoSize = true;
            label_birthdate_partner.Location = new Point(381, 91);
            label_birthdate_partner.Name = "label_birthdate_partner";
            label_birthdate_partner.Size = new Size(91, 15);
            label_birthdate_partner.TabIndex = 28;
            label_birthdate_partner.Text = "Datum narození";
            // 
            // label_gender_partner
            // 
            label_gender_partner.AutoSize = true;
            label_gender_partner.Location = new Point(292, 91);
            label_gender_partner.Name = "label_gender_partner";
            label_gender_partner.Size = new Size(46, 15);
            label_gender_partner.TabIndex = 27;
            label_gender_partner.Text = "Pohlaví";
            // 
            // comboBox_gender_partner
            // 
            comboBox_gender_partner.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_gender_partner.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_gender_partner, ErrorIconAlignment.MiddleLeft);
            comboBox_gender_partner.Items.AddRange(new object[] { "Muž", "Žena" });
            comboBox_gender_partner.Location = new Point(292, 109);
            comboBox_gender_partner.Margin = new Padding(3, 3, 16, 3);
            comboBox_gender_partner.Name = "comboBox_gender_partner";
            comboBox_gender_partner.Size = new Size(70, 23);
            comboBox_gender_partner.TabIndex = 26;
            comboBox_gender_partner.SelectedIndexChanged += ComboBox_Gender_Partner_SelectedIndexChanged;
            comboBox_gender_partner.Validating += ComboBox_Gender_Partner_Validating;
            // 
            // label_gender
            // 
            label_gender.AutoSize = true;
            label_gender.Location = new Point(292, 32);
            label_gender.Name = "label_gender";
            label_gender.Size = new Size(51, 15);
            label_gender.TabIndex = 25;
            label_gender.Text = "Pohlaví*";
            // 
            // comboBox_gender
            // 
            comboBox_gender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_gender.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_gender, ErrorIconAlignment.MiddleLeft);
            comboBox_gender.Items.AddRange(new object[] { "Muž", "Žena" });
            comboBox_gender.Location = new Point(292, 50);
            comboBox_gender.Margin = new Padding(3, 3, 16, 3);
            comboBox_gender.Name = "comboBox_gender";
            comboBox_gender.Size = new Size(70, 23);
            comboBox_gender.TabIndex = 24;
            comboBox_gender.SelectedIndexChanged += ComboBox_Gender_SelectedIndexChanged;
            comboBox_gender.Validating += ComboBox_Gender_Validating;
            // 
            // dateTimePicker_birthdate
            // 
            errorProvider.SetIconAlignment(dateTimePicker_birthdate, ErrorIconAlignment.MiddleLeft);
            dateTimePicker_birthdate.Location = new Point(381, 50);
            dateTimePicker_birthdate.Margin = new Padding(3, 3, 16, 3);
            dateTimePicker_birthdate.MaxDate = new DateTime(2023, 4, 19, 0, 0, 0, 0);
            dateTimePicker_birthdate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateTimePicker_birthdate.Name = "dateTimePicker_birthdate";
            dateTimePicker_birthdate.Size = new Size(174, 23);
            dateTimePicker_birthdate.TabIndex = 23;
            dateTimePicker_birthdate.Value = new DateTime(2000, 1, 1);
            dateTimePicker_birthdate.ValueChanged += DateTimePicker_Birthdate_ValueChanged;
            // 
            // label_ageCategory
            // 
            label_ageCategory.AutoSize = true;
            label_ageCategory.Location = new Point(737, 32);
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
            comboBox_ageCategory.Location = new Point(737, 50);
            comboBox_ageCategory.Margin = new Padding(3, 3, 16, 3);
            comboBox_ageCategory.Name = "comboBox_ageCategory";
            comboBox_ageCategory.Size = new Size(148, 23);
            comboBox_ageCategory.TabIndex = 21;
            comboBox_ageCategory.Validating += ComboBox_AgeCategory_Validating;
            // 
            // label_duo
            // 
            label_duo.AutoSize = true;
            label_duo.BackColor = Color.Snow;
            label_duo.Location = new Point(55, 112);
            label_duo.Name = "label_duo";
            label_duo.Size = new Size(49, 15);
            label_duo.TabIndex = 20;
            label_duo.Text = "Dvojice:";
            // 
            // label_name_partner
            // 
            label_name_partner.AutoSize = true;
            label_name_partner.Location = new Point(132, 91);
            label_name_partner.Name = "label_name_partner";
            label_name_partner.Size = new Size(42, 15);
            label_name_partner.TabIndex = 17;
            label_name_partner.Text = "Jméno";
            // 
            // textBox_name_partner
            // 
            errorProvider.SetIconAlignment(textBox_name_partner, ErrorIconAlignment.MiddleLeft);
            textBox_name_partner.Location = new Point(132, 109);
            textBox_name_partner.Margin = new Padding(3, 3, 16, 3);
            textBox_name_partner.Name = "textBox_name_partner";
            textBox_name_partner.Size = new Size(141, 23);
            textBox_name_partner.TabIndex = 16;
            textBox_name_partner.KeyUp += TextBox_Name_Partner_KeyUp;
            textBox_name_partner.Validating += TextBox_Name_Partner_Validating;
            // 
            // label_team
            // 
            label_team.AutoSize = true;
            label_team.Location = new Point(574, 32);
            label_team.Name = "label_team";
            label_team.Size = new Size(41, 15);
            label_team.TabIndex = 15;
            label_team.Text = "Oddíl*";
            // 
            // comboBox_team
            // 
            comboBox_team.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_team, ErrorIconAlignment.MiddleLeft);
            comboBox_team.Location = new Point(574, 50);
            comboBox_team.Margin = new Padding(3, 3, 16, 3);
            comboBox_team.Name = "comboBox_team";
            comboBox_team.Size = new Size(144, 23);
            comboBox_team.TabIndex = 14;
            comboBox_team.Validating += ComboBox_Team_Validating;
            // 
            // label_birthdate
            // 
            label_birthdate.AutoSize = true;
            label_birthdate.Location = new Point(381, 32);
            label_birthdate.Name = "label_birthdate";
            label_birthdate.Size = new Size(96, 15);
            label_birthdate.TabIndex = 13;
            label_birthdate.Text = "Datum narození*";
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(132, 32);
            label_name.Name = "label_name";
            label_name.Size = new Size(47, 15);
            label_name.TabIndex = 11;
            label_name.Text = "Jméno*";
            // 
            // textBox_name
            // 
            errorProvider.SetIconAlignment(textBox_name, ErrorIconAlignment.MiddleLeft);
            textBox_name.Location = new Point(132, 50);
            textBox_name.Margin = new Padding(3, 3, 16, 3);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(141, 23);
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
            textBox_startNumber.Size = new Size(90, 23);
            textBox_startNumber.TabIndex = 8;
            textBox_startNumber.KeyDown += TextBox_StartNumber_KeyDown;
            textBox_startNumber.Validating += TextBox_StartNumber_Validating;
            // 
            // button_save
            // 
            button_save.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button_save.Location = new Point(930, 63);
            button_save.Margin = new Padding(0);
            button_save.Name = "button_save";
            button_save.Size = new Size(100, 42);
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
            // maskedTextBox_penalty
            // 
            errorProvider.SetIconAlignment(maskedTextBox_penalty, ErrorIconAlignment.MiddleLeft);
            maskedTextBox_penalty.Location = new Point(997, 46);
            maskedTextBox_penalty.Margin = new Padding(3, 3, 16, 3);
            maskedTextBox_penalty.Mask = "00:00";
            maskedTextBox_penalty.Name = "maskedTextBox_penalty";
            maskedTextBox_penalty.Size = new Size(71, 23);
            maskedTextBox_penalty.TabIndex = 13;
            maskedTextBox_penalty.Text = "0000";
            maskedTextBox_penalty.ValidatingType = typeof(int);
            // 
            // maskedTextBox_timeWaited
            // 
            errorProvider.SetIconAlignment(maskedTextBox_timeWaited, ErrorIconAlignment.MiddleLeft);
            maskedTextBox_timeWaited.Location = new Point(907, 46);
            maskedTextBox_timeWaited.Margin = new Padding(3, 3, 16, 3);
            maskedTextBox_timeWaited.Mask = "00:00";
            maskedTextBox_timeWaited.Name = "maskedTextBox_timeWaited";
            maskedTextBox_timeWaited.Size = new Size(71, 23);
            maskedTextBox_timeWaited.TabIndex = 11;
            maskedTextBox_timeWaited.Text = "0000";
            maskedTextBox_timeWaited.ValidatingType = typeof(int);
            // 
            // comboBox_checkpoints_checkpointInfo
            // 
            comboBox_checkpoints_checkpointInfo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_checkpoints_checkpointInfo.FormattingEnabled = true;
            errorProvider.SetIconAlignment(comboBox_checkpoints_checkpointInfo, ErrorIconAlignment.MiddleLeft);
            comboBox_checkpoints_checkpointInfo.Location = new Point(706, 47);
            comboBox_checkpoints_checkpointInfo.Margin = new Padding(3, 3, 16, 3);
            comboBox_checkpoints_checkpointInfo.Name = "comboBox_checkpoints_checkpointInfo";
            comboBox_checkpoints_checkpointInfo.Size = new Size(182, 23);
            comboBox_checkpoints_checkpointInfo.TabIndex = 8;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPage_start);
            tabControl.Controls.Add(tabPage_results);
            tabControl.Location = new Point(12, 27);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1071, 659);
            tabControl.TabIndex = 8;
            tabControl.Selected += Tab_Selected;
            // 
            // tabPage_start
            // 
            tabPage_start.Controls.Add(groupBox_edit);
            tabPage_start.Controls.Add(groupBox_runnersList);
            tabPage_start.Location = new Point(4, 24);
            tabPage_start.Name = "tabPage_start";
            tabPage_start.Padding = new Padding(3);
            tabPage_start.Size = new Size(1063, 631);
            tabPage_start.TabIndex = 0;
            tabPage_start.Text = "Startovní listina";
            tabPage_start.UseVisualStyleBackColor = true;
            // 
            // tabPage_results
            // 
            tabPage_results.Controls.Add(groupBox1);
            tabPage_results.Controls.Add(groupBox_runners_results);
            tabPage_results.Controls.Add(groupBox_checkpoints);
            tabPage_results.Controls.Add(groupBox_filter);
            tabPage_results.Location = new Point(4, 24);
            tabPage_results.Name = "tabPage_results";
            tabPage_results.Padding = new Padding(3);
            tabPage_results.Size = new Size(1063, 631);
            tabPage_results.TabIndex = 1;
            tabPage_results.Text = "Výsledková listina";
            tabPage_results.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox_startNumber_checkpointInfo);
            groupBox1.Controls.Add(button_add_checkpointInfo);
            groupBox1.Controls.Add(checkBox_disqualified_checkpointInfo);
            groupBox1.Controls.Add(label_penalty);
            groupBox1.Controls.Add(maskedTextBox_penalty);
            groupBox1.Controls.Add(label_timeWaited);
            groupBox1.Controls.Add(maskedTextBox_timeWaited);
            groupBox1.Controls.Add(label_checkpoints_checkpointInfo);
            groupBox1.Controls.Add(comboBox_checkpoints_checkpointInfo);
            groupBox1.Controls.Add(label_ageCategory_checkpointInfo);
            groupBox1.Controls.Add(textBox_ageCategory_checkpointInfo);
            groupBox1.Controls.Add(label_team_checkpointInfo);
            groupBox1.Controls.Add(textBox_team_checkpointInfo);
            groupBox1.Controls.Add(label_name_checkpointInfo);
            groupBox1.Controls.Add(textBox_name_checkpointInfo);
            groupBox1.Controls.Add(label_startNumber_checkpointInfo);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1051, 97);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Přidat záznam stanoviště";
            // 
            // textBox_startNumber_checkpointInfo
            // 
            textBox_startNumber_checkpointInfo.Enabled = false;
            textBox_startNumber_checkpointInfo.Location = new Point(30, 47);
            textBox_startNumber_checkpointInfo.Margin = new Padding(3, 3, 16, 3);
            textBox_startNumber_checkpointInfo.Name = "textBox_startNumber_checkpointInfo";
            textBox_startNumber_checkpointInfo.Size = new Size(104, 23);
            textBox_startNumber_checkpointInfo.TabIndex = 17;
            // 
            // button_add_checkpointInfo
            // 
            button_add_checkpointInfo.Location = new Point(1294, 31);
            button_add_checkpointInfo.Name = "button_add_checkpointInfo";
            button_add_checkpointInfo.Size = new Size(123, 41);
            button_add_checkpointInfo.TabIndex = 16;
            button_add_checkpointInfo.Text = "Přidat";
            button_add_checkpointInfo.UseVisualStyleBackColor = true;
            button_add_checkpointInfo.Click += Button_CheckpointInfo_Add_Click;
            // 
            // checkBox_disqualified_checkpointInfo
            // 
            checkBox_disqualified_checkpointInfo.AutoSize = true;
            checkBox_disqualified_checkpointInfo.Location = new Point(1100, 49);
            checkBox_disqualified_checkpointInfo.Name = "checkBox_disqualified_checkpointInfo";
            checkBox_disqualified_checkpointInfo.Size = new Size(116, 19);
            checkBox_disqualified_checkpointInfo.TabIndex = 15;
            checkBox_disqualified_checkpointInfo.Text = "Diskvalifikován/a";
            checkBox_disqualified_checkpointInfo.UseVisualStyleBackColor = true;
            // 
            // label_penalty
            // 
            label_penalty.AutoSize = true;
            label_penalty.Location = new Point(997, 28);
            label_penalty.Name = "label_penalty";
            label_penalty.Size = new Size(64, 15);
            label_penalty.TabIndex = 14;
            label_penalty.Text = "Trestný čas";
            // 
            // label_timeWaited
            // 
            label_timeWaited.AutoSize = true;
            label_timeWaited.Location = new Point(907, 28);
            label_timeWaited.Name = "label_timeWaited";
            label_timeWaited.Size = new Size(46, 15);
            label_timeWaited.TabIndex = 12;
            label_timeWaited.Text = "Zdržení";
            // 
            // label_checkpoints_checkpointInfo
            // 
            label_checkpoints_checkpointInfo.AutoSize = true;
            label_checkpoints_checkpointInfo.Location = new Point(706, 29);
            label_checkpoints_checkpointInfo.Name = "label_checkpoints_checkpointInfo";
            label_checkpoints_checkpointInfo.Size = new Size(61, 15);
            label_checkpoints_checkpointInfo.TabIndex = 9;
            label_checkpoints_checkpointInfo.Text = "Stanoviště";
            // 
            // label_ageCategory_checkpointInfo
            // 
            label_ageCategory_checkpointInfo.AutoSize = true;
            label_ageCategory_checkpointInfo.Location = new Point(547, 29);
            label_ageCategory_checkpointInfo.Name = "label_ageCategory_checkpointInfo";
            label_ageCategory_checkpointInfo.Size = new Size(96, 15);
            label_ageCategory_checkpointInfo.TabIndex = 7;
            label_ageCategory_checkpointInfo.Text = "Věková kategorie";
            // 
            // textBox_ageCategory_checkpointInfo
            // 
            textBox_ageCategory_checkpointInfo.Enabled = false;
            textBox_ageCategory_checkpointInfo.Location = new Point(547, 47);
            textBox_ageCategory_checkpointInfo.Margin = new Padding(3, 3, 16, 3);
            textBox_ageCategory_checkpointInfo.Name = "textBox_ageCategory_checkpointInfo";
            textBox_ageCategory_checkpointInfo.Size = new Size(140, 23);
            textBox_ageCategory_checkpointInfo.TabIndex = 6;
            // 
            // label_team_checkpointInfo
            // 
            label_team_checkpointInfo.AutoSize = true;
            label_team_checkpointInfo.Location = new Point(394, 29);
            label_team_checkpointInfo.Name = "label_team_checkpointInfo";
            label_team_checkpointInfo.Size = new Size(36, 15);
            label_team_checkpointInfo.TabIndex = 5;
            label_team_checkpointInfo.Text = "Oddíl";
            // 
            // textBox_team_checkpointInfo
            // 
            textBox_team_checkpointInfo.Enabled = false;
            textBox_team_checkpointInfo.Location = new Point(394, 47);
            textBox_team_checkpointInfo.Margin = new Padding(3, 3, 16, 3);
            textBox_team_checkpointInfo.Name = "textBox_team_checkpointInfo";
            textBox_team_checkpointInfo.Size = new Size(134, 23);
            textBox_team_checkpointInfo.TabIndex = 4;
            // 
            // label_name_checkpointInfo
            // 
            label_name_checkpointInfo.AutoSize = true;
            label_name_checkpointInfo.Location = new Point(153, 29);
            label_name_checkpointInfo.Name = "label_name_checkpointInfo";
            label_name_checkpointInfo.Size = new Size(42, 15);
            label_name_checkpointInfo.TabIndex = 3;
            label_name_checkpointInfo.Text = "Jméno";
            // 
            // textBox_name_checkpointInfo
            // 
            textBox_name_checkpointInfo.Enabled = false;
            textBox_name_checkpointInfo.Location = new Point(153, 47);
            textBox_name_checkpointInfo.Margin = new Padding(3, 3, 16, 3);
            textBox_name_checkpointInfo.Name = "textBox_name_checkpointInfo";
            textBox_name_checkpointInfo.Size = new Size(222, 23);
            textBox_name_checkpointInfo.TabIndex = 2;
            // 
            // label_startNumber_checkpointInfo
            // 
            label_startNumber_checkpointInfo.AutoSize = true;
            label_startNumber_checkpointInfo.Location = new Point(30, 29);
            label_startNumber_checkpointInfo.Name = "label_startNumber_checkpointInfo";
            label_startNumber_checkpointInfo.Size = new Size(81, 15);
            label_startNumber_checkpointInfo.TabIndex = 1;
            label_startNumber_checkpointInfo.Text = "Startovní číslo";
            // 
            // groupBox_runners_results
            // 
            groupBox_runners_results.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_runners_results.Controls.Add(dataGridView_runners_results);
            groupBox_runners_results.Location = new Point(6, 308);
            groupBox_runners_results.Name = "groupBox_runners_results";
            groupBox_runners_results.Size = new Size(1051, 311);
            groupBox_runners_results.TabIndex = 2;
            groupBox_runners_results.TabStop = false;
            groupBox_runners_results.Text = "Seznam běžců";
            // 
            // dataGridView_runners_results
            // 
            dataGridView_runners_results.AllowUserToAddRows = false;
            dataGridView_runners_results.AllowUserToDeleteRows = false;
            dataGridView_runners_results.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_runners_results.AutoGenerateColumns = false;
            dataGridView_runners_results.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_runners_results.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_runners_results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_runners_results.Columns.AddRange(new DataGridViewColumn[] { startNumberDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, teamDataGridViewTextBoxColumn, dataGridViewTextBoxColumn1, partnerFirstNameDataGridViewTextBoxColumn, partnerLastNameDataGridViewTextBoxColumn, disqualifiedDataGridViewCheckBoxColumn, startTimeDataGridViewTextBoxColumn, finishTimeDataGridViewTextBoxColumn, finalRunTimeDataGridViewTextBoxColumn, totalWaitTimeDataGridViewTextBoxColumn, totalPenaltyTimeDataGridViewTextBoxColumn });
            dataGridView_runners_results.DataSource = runnerBindingSource;
            dataGridView_runners_results.Location = new Point(6, 22);
            dataGridView_runners_results.MultiSelect = false;
            dataGridView_runners_results.Name = "dataGridView_runners_results";
            dataGridView_runners_results.RowHeadersWidth = 60;
            dataGridView_runners_results.RowTemplate.Height = 25;
            dataGridView_runners_results.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_runners_results.Size = new Size(1039, 277);
            dataGridView_runners_results.TabIndex = 0;
            dataGridView_runners_results.CellEndEdit += DataGridView_Runners_Results_CellEndEdit;
            dataGridView_runners_results.CurrentCellChanged += DataGridView_Runners_Results_CurrentCellChanged;
            dataGridView_runners_results.DataError += DataGridView_Runners_Results_DataError;
            dataGridView_runners_results.RowsAdded += DataGridView_Runners_Results_RowsAdded;
            // 
            // startNumberDataGridViewTextBoxColumn
            // 
            startNumberDataGridViewTextBoxColumn.DataPropertyName = "StartNumber";
            startNumberDataGridViewTextBoxColumn.HeaderText = "Startovní číslo";
            startNumberDataGridViewTextBoxColumn.Name = "startNumberDataGridViewTextBoxColumn";
            startNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "Jméno";
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "Příjmení";
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teamDataGridViewTextBoxColumn
            // 
            teamDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            teamDataGridViewTextBoxColumn.HeaderText = "Oddíl";
            teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            teamDataGridViewTextBoxColumn.ReadOnly = true;
            teamDataGridViewTextBoxColumn.Width = 61;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "AgeCategory";
            dataGridViewCellStyle8.NullValue = "-";
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn1.HeaderText = "Věková kategorie";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 111;
            // 
            // partnerFirstNameDataGridViewTextBoxColumn
            // 
            partnerFirstNameDataGridViewTextBoxColumn.DataPropertyName = "PartnerFirstName";
            partnerFirstNameDataGridViewTextBoxColumn.HeaderText = "Jméno 2";
            partnerFirstNameDataGridViewTextBoxColumn.Name = "partnerFirstNameDataGridViewTextBoxColumn";
            partnerFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partnerLastNameDataGridViewTextBoxColumn
            // 
            partnerLastNameDataGridViewTextBoxColumn.DataPropertyName = "PartnerLastName";
            partnerLastNameDataGridViewTextBoxColumn.HeaderText = "Příjmení 2";
            partnerLastNameDataGridViewTextBoxColumn.Name = "partnerLastNameDataGridViewTextBoxColumn";
            partnerLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // disqualifiedDataGridViewCheckBoxColumn
            // 
            disqualifiedDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            disqualifiedDataGridViewCheckBoxColumn.DataPropertyName = "Disqualified";
            disqualifiedDataGridViewCheckBoxColumn.HeaderText = "Diskvalifikován/a";
            disqualifiedDataGridViewCheckBoxColumn.Name = "disqualifiedDataGridViewCheckBoxColumn";
            disqualifiedDataGridViewCheckBoxColumn.ReadOnly = true;
            disqualifiedDataGridViewCheckBoxColumn.Width = 103;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            dataGridViewCellStyle9.Format = "T";
            dataGridViewCellStyle9.NullValue = "-";
            startTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            startTimeDataGridViewTextBoxColumn.HeaderText = "Start";
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            // 
            // finishTimeDataGridViewTextBoxColumn
            // 
            finishTimeDataGridViewTextBoxColumn.DataPropertyName = "FinishTime";
            dataGridViewCellStyle10.Format = "T";
            dataGridViewCellStyle10.NullValue = "-";
            finishTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            finishTimeDataGridViewTextBoxColumn.HeaderText = "Cíl";
            finishTimeDataGridViewTextBoxColumn.Name = "finishTimeDataGridViewTextBoxColumn";
            // 
            // finalRunTimeDataGridViewTextBoxColumn
            // 
            finalRunTimeDataGridViewTextBoxColumn.DataPropertyName = "FinalRunTime";
            dataGridViewCellStyle11.Format = "T";
            dataGridViewCellStyle11.NullValue = "-";
            finalRunTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            finalRunTimeDataGridViewTextBoxColumn.HeaderText = "Výsledný čas";
            finalRunTimeDataGridViewTextBoxColumn.Name = "finalRunTimeDataGridViewTextBoxColumn";
            finalRunTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalWaitTimeDataGridViewTextBoxColumn
            // 
            totalWaitTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalWaitTime";
            dataGridViewCellStyle12.Format = "T";
            dataGridViewCellStyle12.NullValue = null;
            totalWaitTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            totalWaitTimeDataGridViewTextBoxColumn.HeaderText = "Zdržení";
            totalWaitTimeDataGridViewTextBoxColumn.Name = "totalWaitTimeDataGridViewTextBoxColumn";
            totalWaitTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPenaltyTimeDataGridViewTextBoxColumn
            // 
            totalPenaltyTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalPenaltyTime";
            dataGridViewCellStyle13.Format = "T";
            dataGridViewCellStyle13.NullValue = null;
            totalPenaltyTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            totalPenaltyTimeDataGridViewTextBoxColumn.HeaderText = "Trestný čas";
            totalPenaltyTimeDataGridViewTextBoxColumn.Name = "totalPenaltyTimeDataGridViewTextBoxColumn";
            totalPenaltyTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox_checkpoints
            // 
            groupBox_checkpoints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_checkpoints.Controls.Add(dataGridView_runnerCheckpoints);
            groupBox_checkpoints.Location = new Point(335, 109);
            groupBox_checkpoints.Name = "groupBox_checkpoints";
            groupBox_checkpoints.Size = new Size(722, 193);
            groupBox_checkpoints.TabIndex = 1;
            groupBox_checkpoints.TabStop = false;
            groupBox_checkpoints.Text = "Stanoviště";
            // 
            // dataGridView_runnerCheckpoints
            // 
            dataGridView_runnerCheckpoints.AllowUserToAddRows = false;
            dataGridView_runnerCheckpoints.AllowUserToDeleteRows = false;
            dataGridView_runnerCheckpoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_runnerCheckpoints.AutoGenerateColumns = false;
            dataGridView_runnerCheckpoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_runnerCheckpoints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_runnerCheckpoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_runnerCheckpoints.Columns.AddRange(new DataGridViewColumn[] { checkpointDataGridViewTextBoxColumn, CheckpointRefereeName, timeWaitedDataGridViewTextBoxColumn, penaltyDataGridViewTextBoxColumn, disqualifiedDataGridViewCheckBoxColumn1 });
            dataGridView_runnerCheckpoints.DataSource = checkpointRunnerInfoBindingSource;
            dataGridView_runnerCheckpoints.Location = new Point(6, 22);
            dataGridView_runnerCheckpoints.MultiSelect = false;
            dataGridView_runnerCheckpoints.Name = "dataGridView_runnerCheckpoints";
            dataGridView_runnerCheckpoints.RowHeadersWidth = 50;
            dataGridView_runnerCheckpoints.RowTemplate.Height = 25;
            dataGridView_runnerCheckpoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_runnerCheckpoints.Size = new Size(710, 165);
            dataGridView_runnerCheckpoints.TabIndex = 0;
            dataGridView_runnerCheckpoints.CellBeginEdit += DataGridView_RunnerCheckpoints_CellBeginEdit;
            dataGridView_runnerCheckpoints.CellEndEdit += DataGridView_RunnerCheckpoints_CellEndEdit;
            dataGridView_runnerCheckpoints.DataError += DataGridView_RunnerCheckpoints_DataError;
            dataGridView_runnerCheckpoints.RowsAdded += DataGridView_RunnerCheckpoints_RowsAdded;
            dataGridView_runnerCheckpoints.KeyUp += DataGridView_RunnerCheckpoints_KeyUp;
            // 
            // checkpointDataGridViewTextBoxColumn
            // 
            checkpointDataGridViewTextBoxColumn.DataPropertyName = "Checkpoint";
            checkpointDataGridViewTextBoxColumn.HeaderText = "Název";
            checkpointDataGridViewTextBoxColumn.Name = "checkpointDataGridViewTextBoxColumn";
            checkpointDataGridViewTextBoxColumn.ReadOnly = true;
            checkpointDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            // 
            // CheckpointRefereeName
            // 
            CheckpointRefereeName.DataPropertyName = "CheckpointRefereeName";
            CheckpointRefereeName.HeaderText = "Rozhodčí";
            CheckpointRefereeName.Name = "CheckpointRefereeName";
            CheckpointRefereeName.ReadOnly = true;
            // 
            // timeWaitedDataGridViewTextBoxColumn
            // 
            timeWaitedDataGridViewTextBoxColumn.DataPropertyName = "TimeWaited";
            dataGridViewCellStyle14.Format = "T";
            dataGridViewCellStyle14.NullValue = null;
            timeWaitedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            timeWaitedDataGridViewTextBoxColumn.HeaderText = "Zdržení";
            timeWaitedDataGridViewTextBoxColumn.Name = "timeWaitedDataGridViewTextBoxColumn";
            // 
            // penaltyDataGridViewTextBoxColumn
            // 
            penaltyDataGridViewTextBoxColumn.DataPropertyName = "Penalty";
            dataGridViewCellStyle15.Format = "T";
            dataGridViewCellStyle15.NullValue = null;
            penaltyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            penaltyDataGridViewTextBoxColumn.HeaderText = "Trestný čas";
            penaltyDataGridViewTextBoxColumn.Name = "penaltyDataGridViewTextBoxColumn";
            // 
            // disqualifiedDataGridViewCheckBoxColumn1
            // 
            disqualifiedDataGridViewCheckBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            disqualifiedDataGridViewCheckBoxColumn1.DataPropertyName = "Disqualified";
            disqualifiedDataGridViewCheckBoxColumn1.HeaderText = "Diskvalifikován/a";
            disqualifiedDataGridViewCheckBoxColumn1.Name = "disqualifiedDataGridViewCheckBoxColumn1";
            disqualifiedDataGridViewCheckBoxColumn1.Width = 103;
            // 
            // checkpointRunnerInfoBindingSource
            // 
            checkpointRunnerInfoBindingSource.DataSource = typeof(Data.CheckpointRunnerInfo);
            // 
            // groupBox_filter
            // 
            groupBox_filter.Controls.Add(checkBox_filter_category);
            groupBox_filter.Controls.Add(checkBox_filter_team);
            groupBox_filter.Controls.Add(label_category_filter);
            groupBox_filter.Controls.Add(label_team_filter);
            groupBox_filter.Controls.Add(comboBox_filter_category);
            groupBox_filter.Controls.Add(comboBox_filter_team);
            groupBox_filter.Location = new Point(6, 109);
            groupBox_filter.Name = "groupBox_filter";
            groupBox_filter.Size = new Size(323, 193);
            groupBox_filter.TabIndex = 0;
            groupBox_filter.TabStop = false;
            groupBox_filter.Text = "Filtr";
            // 
            // checkBox_filter_category
            // 
            checkBox_filter_category.AutoSize = true;
            checkBox_filter_category.Location = new Point(267, 114);
            checkBox_filter_category.Name = "checkBox_filter_category";
            checkBox_filter_category.Size = new Size(15, 14);
            checkBox_filter_category.TabIndex = 5;
            checkBox_filter_category.UseVisualStyleBackColor = true;
            checkBox_filter_category.CheckedChanged += CheckBox_Filter_Category_CheckedChanged;
            // 
            // checkBox_filter_team
            // 
            checkBox_filter_team.AutoSize = true;
            checkBox_filter_team.Location = new Point(267, 76);
            checkBox_filter_team.Name = "checkBox_filter_team";
            checkBox_filter_team.Size = new Size(15, 14);
            checkBox_filter_team.TabIndex = 4;
            checkBox_filter_team.UseVisualStyleBackColor = true;
            checkBox_filter_team.CheckedChanged += CheckBox_Filter_Team_CheckedChanged;
            // 
            // label_category_filter
            // 
            label_category_filter.AutoSize = true;
            label_category_filter.Location = new Point(30, 112);
            label_category_filter.Name = "label_category_filter";
            label_category_filter.Size = new Size(96, 15);
            label_category_filter.TabIndex = 3;
            label_category_filter.Text = "Věková kategorie";
            // 
            // label_team_filter
            // 
            label_team_filter.AutoSize = true;
            label_team_filter.Location = new Point(90, 74);
            label_team_filter.Name = "label_team_filter";
            label_team_filter.Size = new Size(36, 15);
            label_team_filter.TabIndex = 2;
            label_team_filter.Text = "Oddíl";
            // 
            // comboBox_filter_category
            // 
            comboBox_filter_category.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_filter_category.Enabled = false;
            comboBox_filter_category.FormattingEnabled = true;
            comboBox_filter_category.Location = new Point(132, 109);
            comboBox_filter_category.Name = "comboBox_filter_category";
            comboBox_filter_category.Size = new Size(121, 23);
            comboBox_filter_category.TabIndex = 1;
            comboBox_filter_category.SelectedIndexChanged += ComboBox_Filter_Category_SelectedIndexChanged;
            // 
            // comboBox_filter_team
            // 
            comboBox_filter_team.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_filter_team.Enabled = false;
            comboBox_filter_team.FormattingEnabled = true;
            comboBox_filter_team.Location = new Point(132, 71);
            comboBox_filter_team.Name = "comboBox_filter_team";
            comboBox_filter_team.Size = new Size(121, 23);
            comboBox_filter_team.TabIndex = 0;
            comboBox_filter_team.SelectedIndexChanged += ComboBox_Filter_Team_SelectedIndexChanged;
            // 
            // StartNumber
            // 
            StartNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            StartNumber.DataPropertyName = "StartNumber";
            StartNumber.HeaderText = "Startovní číslo";
            StartNumber.MinimumWidth = 65;
            StartNumber.Name = "StartNumber";
            StartNumber.ReadOnly = true;
            StartNumber.Width = 106;
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
            // Birthdate
            // 
            Birthdate.DataPropertyName = "Birthdate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = "-";
            Birthdate.DefaultCellStyle = dataGridViewCellStyle1;
            Birthdate.HeaderText = "Datum narození";
            Birthdate.Name = "Birthdate";
            Birthdate.ReadOnly = true;
            // 
            // Team
            // 
            Team.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Team.DataPropertyName = "Team";
            dataGridViewCellStyle2.NullValue = "-";
            Team.DefaultCellStyle = dataGridViewCellStyle2;
            Team.HeaderText = "Oddíl";
            Team.Name = "Team";
            Team.ReadOnly = true;
            Team.Width = 61;
            // 
            // AgeCategory
            // 
            AgeCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            AgeCategory.DataPropertyName = "AgeCategory";
            dataGridViewCellStyle3.NullValue = "-";
            AgeCategory.DefaultCellStyle = dataGridViewCellStyle3;
            AgeCategory.HeaderText = "Věková kategorie";
            AgeCategory.Name = "AgeCategory";
            AgeCategory.ReadOnly = true;
            AgeCategory.Width = 111;
            // 
            // PartnerFirstName
            // 
            PartnerFirstName.DataPropertyName = "PartnerFirstName";
            dataGridViewCellStyle4.NullValue = "-";
            PartnerFirstName.DefaultCellStyle = dataGridViewCellStyle4;
            PartnerFirstName.HeaderText = "Jméno 2";
            PartnerFirstName.Name = "PartnerFirstName";
            PartnerFirstName.ReadOnly = true;
            // 
            // PartnerLastName
            // 
            PartnerLastName.DataPropertyName = "PartnerLastName";
            dataGridViewCellStyle5.NullValue = "-";
            PartnerLastName.DefaultCellStyle = dataGridViewCellStyle5;
            PartnerLastName.HeaderText = "Příjmení 2";
            PartnerLastName.Name = "PartnerLastName";
            PartnerLastName.ReadOnly = true;
            // 
            // PartnerBirthdate
            // 
            PartnerBirthdate.DataPropertyName = "PartnerBirthdate";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = "-";
            PartnerBirthdate.DefaultCellStyle = dataGridViewCellStyle6;
            PartnerBirthdate.HeaderText = "Datum narození 2";
            PartnerBirthdate.Name = "PartnerBirthdate";
            PartnerBirthdate.ReadOnly = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1095, 711);
            Controls.Add(tabControl);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1111, 750);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Turistický závod";
            FormClosing += MainWindow_FormClosing;
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
            tabControl.ResumeLayout(false);
            tabPage_start.ResumeLayout(false);
            tabPage_results.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_runners_results.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_runners_results).EndInit();
            groupBox_checkpoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_runnerCheckpoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkpointRunnerInfoBindingSource).EndInit();
            groupBox_filter.ResumeLayout(false);
            groupBox_filter.PerformLayout();
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
        private ToolStripMenuItem toolStripMenuItem_saveAs;
        private GroupBox groupBox_edit;
        private Button button_save;
        private Label label_team;
        private ComboBox comboBox_team;
        private Label label_birthdate;
        private Label label_name;
        private TextBox textBox_name;
        private Label label_startNumber;
        private TextBox textBox_startNumber;
        private Label label_duo;
        private Label label_name_partner;
        private TextBox textBox_name_partner;
        private Label label_ageCategory;
        private ComboBox comboBox_ageCategory;
        private ErrorProvider errorProvider;
        private TabControl tabControl;
        private TabPage tabPage_start;
        private TabPage tabPage_results;
        private GroupBox groupBox_runners_results;
        private GroupBox groupBox_checkpoints;
        private GroupBox groupBox_filter;
        private DataGridView dataGridView_runners_results;
        private Label label_category_filter;
        private Label label_team_filter;
        private ComboBox comboBox_filter_category;
        private ComboBox comboBox_filter_team;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private CheckBox checkBox_filter_category;
        private CheckBox checkBox_filter_team;
        private DataGridView dataGridView_runnerCheckpoints;
        private BindingSource checkpointRunnerInfoBindingSource;
        private DateTimePicker dateTimePicker_birthdate;
        private DateTimePicker dateTimePicker_birthdate_partner;
        private Label label_birthdate_partner;
        private Label label_gender_partner;
        private ComboBox comboBox_gender_partner;
        private Label label_gender;
        private ComboBox comboBox_gender;
        private DataGridViewTextBoxColumn startNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn partnerFirstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn partnerLastNameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn disqualifiedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finishTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finalRunTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalWaitTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPenaltyTimeDataGridViewTextBoxColumn;
        private ToolStripMenuItem toolStripMenuItem_reset;
        private GroupBox groupBox1;
        private Label label_team_checkpointInfo;
        private TextBox textBox_team_checkpointInfo;
        private Label label_name_checkpointInfo;
        private TextBox textBox_name_checkpointInfo;
        private Label label_startNumber_checkpointInfo;
        private DataGridViewTextBoxColumn checkpointDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CheckpointRefereeName;
        private DataGridViewTextBoxColumn timeWaitedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn penaltyDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn disqualifiedDataGridViewCheckBoxColumn1;
        private Label label_checkpoints_checkpointInfo;
        private ComboBox comboBox_checkpoints_checkpointInfo;
        private Label label_ageCategory_checkpointInfo;
        private TextBox textBox_ageCategory_checkpointInfo;
        private Button button_add_checkpointInfo;
        private CheckBox checkBox_disqualified_checkpointInfo;
        private Label label_penalty;
        private MaskedTextBox maskedTextBox_penalty;
        private Label label_timeWaited;
        private MaskedTextBox maskedTextBox_timeWaited;
        private TextBox textBox_startNumber_checkpointInfo;
        private DataGridViewTextBoxColumn StartNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Birthdate;
        private DataGridViewTextBoxColumn Team;
        private DataGridViewTextBoxColumn AgeCategory;
        private DataGridViewTextBoxColumn PartnerFirstName;
        private DataGridViewTextBoxColumn PartnerLastName;
        private DataGridViewTextBoxColumn PartnerBirthdate;
    }
}