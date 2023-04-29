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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgeCategoriesEditor));
            dataGridView_categories = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            TypeString = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            ageCategoryBindingSource = new BindingSource(components);
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            groupBox_categories = new GroupBox();
            groupBox_edit_category = new GroupBox();
            label_type = new Label();
            comboBox_type = new ComboBox();
            textBox_color = new TextBox();
            label_color = new Label();
            label_ageMax = new Label();
            textBox_ageMax = new TextBox();
            label_ageMin = new Label();
            label_code = new Label();
            textBox_ageMin = new TextBox();
            textBox_code = new TextBox();
            label_name_category = new Label();
            textBox_name_category = new TextBox();
            button_save_category = new Button();
            errorProvider_category = new ErrorProvider(components);
            textBox_name_checkpoint = new TextBox();
            groupBox_checkpoints = new GroupBox();
            dataGridView_checkpoints = new DataGridView();
            Checkpoint = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
            CheckpointDisqualifiable = new DataGridViewCheckBoxColumn();
            checkpointAgeCategoryParticipationBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            groupBox_edit_checkpoint = new GroupBox();
            checkBox_disqualifiable = new CheckBox();
            label_name_checkpoint = new Label();
            button_save_checkpoint = new Button();
            errorProvider_checkpoint = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView_categories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).BeginInit();
            groupBox_categories.SuspendLayout();
            groupBox_edit_category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_category).BeginInit();
            groupBox_checkpoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_checkpoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkpointAgeCategoryParticipationBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox_edit_checkpoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_checkpoint).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_categories
            // 
            dataGridView_categories.AllowUserToAddRows = false;
            dataGridView_categories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_categories.AutoGenerateColumns = false;
            dataGridView_categories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_categories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_categories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_categories.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, TypeString, dataGridViewTextBoxColumn10 });
            dataGridView_categories.DataSource = ageCategoryBindingSource;
            dataGridView_categories.Location = new Point(6, 22);
            dataGridView_categories.MultiSelect = false;
            dataGridView_categories.Name = "dataGridView_categories";
            dataGridView_categories.ReadOnly = true;
            dataGridView_categories.RowHeadersWidth = 50;
            dataGridView_categories.RowTemplate.Height = 25;
            dataGridView_categories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_categories.Size = new Size(775, 327);
            dataGridView_categories.TabIndex = 0;
            dataGridView_categories.CurrentCellChanged += DataGridView_AgeCategories_CurrentCellChanged;
            dataGridView_categories.RowsAdded += DataGridView_AgeCategories_RowsAdded;
            dataGridView_categories.Sorted += DataGridView_AgeCategories_Sorted;
            dataGridView_categories.UserDeletedRow += DataGridView_AgeCategories_UserDeletedRow;
            dataGridView_categories.UserDeletingRow += DataGridView_AgeCategories_UserDeletingRow;
            dataGridView_categories.KeyDown += DataGridView_AgeCategories_KeyDown;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn6.DataPropertyName = "Name";
            dataGridViewTextBoxColumn6.HeaderText = "Název";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 64;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Code";
            dataGridViewTextBoxColumn7.HeaderText = "Zkratka";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "AgeMin";
            dataGridViewTextBoxColumn8.HeaderText = "Věk od";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "AgeMax";
            dataGridViewCellStyle1.NullValue = "∞";
            dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTextBoxColumn9.HeaderText = "Věk do";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // TypeString
            // 
            TypeString.DataPropertyName = "TypeString";
            TypeString.HeaderText = "Typ";
            TypeString.Name = "TypeString";
            TypeString.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "Color";
            dataGridViewTextBoxColumn10.HeaderText = "Barva";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // ageCategoryBindingSource
            // 
            ageCategoryBindingSource.DataSource = typeof(Data.AgeCategory);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // groupBox_categories
            // 
            groupBox_categories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_categories.Controls.Add(dataGridView_categories);
            groupBox_categories.Location = new Point(12, 111);
            groupBox_categories.Name = "groupBox_categories";
            groupBox_categories.Size = new Size(787, 355);
            groupBox_categories.TabIndex = 8;
            groupBox_categories.TabStop = false;
            groupBox_categories.Text = "Věkové kategorie";
            // 
            // groupBox_edit_category
            // 
            groupBox_edit_category.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_edit_category.Controls.Add(label_type);
            groupBox_edit_category.Controls.Add(comboBox_type);
            groupBox_edit_category.Controls.Add(textBox_color);
            groupBox_edit_category.Controls.Add(label_color);
            groupBox_edit_category.Controls.Add(label_ageMax);
            groupBox_edit_category.Controls.Add(textBox_ageMax);
            groupBox_edit_category.Controls.Add(label_ageMin);
            groupBox_edit_category.Controls.Add(label_code);
            groupBox_edit_category.Controls.Add(textBox_ageMin);
            groupBox_edit_category.Controls.Add(textBox_code);
            groupBox_edit_category.Controls.Add(label_name_category);
            groupBox_edit_category.Controls.Add(textBox_name_category);
            groupBox_edit_category.Controls.Add(button_save_category);
            groupBox_edit_category.Location = new Point(12, 12);
            groupBox_edit_category.Name = "groupBox_edit_category";
            groupBox_edit_category.Size = new Size(787, 93);
            groupBox_edit_category.TabIndex = 9;
            groupBox_edit_category.TabStop = false;
            groupBox_edit_category.Text = "Přidat/upravit kategorii";
            // 
            // label_type
            // 
            label_type.AutoSize = true;
            label_type.Location = new Point(536, 26);
            label_type.Name = "label_type";
            label_type.Size = new Size(30, 15);
            label_type.TabIndex = 18;
            label_type.Text = "Typ*";
            // 
            // comboBox_type
            // 
            comboBox_type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type.FormattingEnabled = true;
            errorProvider_category.SetIconAlignment(comboBox_type, ErrorIconAlignment.MiddleLeft);
            comboBox_type.Items.AddRange(new object[] { "Klasický", "Dvojice", "Štafety" });
            comboBox_type.Location = new Point(536, 44);
            comboBox_type.Name = "comboBox_type";
            comboBox_type.Size = new Size(114, 23);
            comboBox_type.TabIndex = 5;
            // 
            // textBox_color
            // 
            errorProvider_category.SetIconAlignment(textBox_color, ErrorIconAlignment.MiddleLeft);
            textBox_color.Location = new Point(449, 44);
            textBox_color.Margin = new Padding(3, 3, 16, 3);
            textBox_color.Name = "textBox_color";
            textBox_color.Size = new Size(68, 23);
            textBox_color.TabIndex = 4;
            textBox_color.KeyPress += TextBox_AgeCategory_Color_KeyPress;
            // 
            // label_color
            // 
            label_color.AutoSize = true;
            label_color.Location = new Point(449, 26);
            label_color.Name = "label_color";
            label_color.Size = new Size(41, 15);
            label_color.TabIndex = 16;
            label_color.Text = "Barva*";
            // 
            // label_ageMax
            // 
            label_ageMax.AutoSize = true;
            label_ageMax.Location = new Point(376, 26);
            label_ageMax.Name = "label_ageMax";
            label_ageMax.Size = new Size(42, 15);
            label_ageMax.TabIndex = 13;
            label_ageMax.Text = "Věk do";
            // 
            // textBox_ageMax
            // 
            errorProvider_category.SetIconAlignment(textBox_ageMax, ErrorIconAlignment.MiddleLeft);
            textBox_ageMax.Location = new Point(376, 44);
            textBox_ageMax.Margin = new Padding(3, 3, 16, 3);
            textBox_ageMax.Name = "textBox_ageMax";
            textBox_ageMax.Size = new Size(54, 23);
            textBox_ageMax.TabIndex = 3;
            textBox_ageMax.KeyDown += TextBox_AgeCategory_AgeMax_KeyDown;
            textBox_ageMax.KeyPress += TextBox_AgeCategory_AgeMax_KeyPress;
            // 
            // label_ageMin
            // 
            label_ageMin.AutoSize = true;
            label_ageMin.Location = new Point(303, 26);
            label_ageMin.Name = "label_ageMin";
            label_ageMin.Size = new Size(47, 15);
            label_ageMin.TabIndex = 11;
            label_ageMin.Text = "Věk od*";
            // 
            // label_code
            // 
            label_code.AutoSize = true;
            label_code.Location = new Point(191, 26);
            label_code.Name = "label_code";
            label_code.Size = new Size(51, 15);
            label_code.TabIndex = 4;
            label_code.Text = "Zkratka*";
            // 
            // textBox_ageMin
            // 
            errorProvider_category.SetIconAlignment(textBox_ageMin, ErrorIconAlignment.MiddleLeft);
            textBox_ageMin.Location = new Point(303, 44);
            textBox_ageMin.Margin = new Padding(3, 3, 16, 3);
            textBox_ageMin.Name = "textBox_ageMin";
            textBox_ageMin.Size = new Size(54, 23);
            textBox_ageMin.TabIndex = 2;
            textBox_ageMin.KeyDown += TextBox_AgeCategory_AgeMin_KeyDown;
            textBox_ageMin.KeyPress += TextBox_AgeCategory_AgeMin_KeyPress;
            // 
            // textBox_code
            // 
            errorProvider_category.SetIconAlignment(textBox_code, ErrorIconAlignment.MiddleLeft);
            textBox_code.Location = new Point(191, 44);
            textBox_code.Margin = new Padding(3, 3, 16, 3);
            textBox_code.Name = "textBox_code";
            textBox_code.Size = new Size(93, 23);
            textBox_code.TabIndex = 1;
            textBox_code.KeyPress += TextBox_AgeCategory_Code_KeyPress;
            // 
            // label_name_category
            // 
            label_name_category.AutoSize = true;
            label_name_category.Location = new Point(20, 26);
            label_name_category.Name = "label_name_category";
            label_name_category.Size = new Size(44, 15);
            label_name_category.TabIndex = 2;
            label_name_category.Text = "Název*";
            // 
            // textBox_name_category
            // 
            errorProvider_category.SetIconAlignment(textBox_name_category, ErrorIconAlignment.MiddleLeft);
            textBox_name_category.Location = new Point(20, 44);
            textBox_name_category.Margin = new Padding(3, 3, 16, 3);
            textBox_name_category.Name = "textBox_name_category";
            textBox_name_category.Size = new Size(152, 23);
            textBox_name_category.TabIndex = 0;
            textBox_name_category.KeyPress += TextBox_AgeCategory_Name_KeyPress;
            // 
            // button_save_category
            // 
            button_save_category.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_save_category.Location = new Point(683, 34);
            button_save_category.Margin = new Padding(3, 3, 15, 3);
            button_save_category.Name = "button_save_category";
            button_save_category.Size = new Size(86, 33);
            button_save_category.TabIndex = 6;
            button_save_category.Text = "Přidat";
            button_save_category.UseVisualStyleBackColor = true;
            button_save_category.Click += Button_AgeCategory_Save_Click;
            // 
            // errorProvider_category
            // 
            errorProvider_category.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider_category.ContainerControl = this;
            // 
            // textBox_name_checkpoint
            // 
            errorProvider_checkpoint.SetIconAlignment(textBox_name_checkpoint, ErrorIconAlignment.MiddleLeft);
            errorProvider_category.SetIconAlignment(textBox_name_checkpoint, ErrorIconAlignment.MiddleLeft);
            textBox_name_checkpoint.Location = new Point(23, 44);
            textBox_name_checkpoint.Margin = new Padding(3, 3, 16, 3);
            textBox_name_checkpoint.Name = "textBox_name_checkpoint";
            textBox_name_checkpoint.Size = new Size(187, 23);
            textBox_name_checkpoint.TabIndex = 7;
            textBox_name_checkpoint.KeyPress += TextBox_Name_Checkpoint_KeyPress;
            // 
            // groupBox_checkpoints
            // 
            groupBox_checkpoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox_checkpoints.Controls.Add(dataGridView_checkpoints);
            groupBox_checkpoints.Location = new Point(805, 111);
            groupBox_checkpoints.Name = "groupBox_checkpoints";
            groupBox_checkpoints.Size = new Size(467, 355);
            groupBox_checkpoints.TabIndex = 11;
            groupBox_checkpoints.TabStop = false;
            groupBox_checkpoints.Text = "Stanoviště";
            // 
            // dataGridView_checkpoints
            // 
            dataGridView_checkpoints.AllowUserToAddRows = false;
            dataGridView_checkpoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_checkpoints.AutoGenerateColumns = false;
            dataGridView_checkpoints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_checkpoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_checkpoints.Columns.AddRange(new DataGridViewColumn[] { Checkpoint, dataGridViewCheckBoxColumn3, CheckpointDisqualifiable });
            dataGridView_checkpoints.DataSource = checkpointAgeCategoryParticipationBindingSource;
            dataGridView_checkpoints.Location = new Point(6, 22);
            dataGridView_checkpoints.MultiSelect = false;
            dataGridView_checkpoints.Name = "dataGridView_checkpoints";
            dataGridView_checkpoints.RowHeadersWidth = 50;
            dataGridView_checkpoints.RowTemplate.Height = 25;
            dataGridView_checkpoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_checkpoints.Size = new Size(455, 327);
            dataGridView_checkpoints.TabIndex = 0;
            dataGridView_checkpoints.CellBeginEdit += DataGridView_Checkpoints_CellBeginEdit;
            dataGridView_checkpoints.CurrentCellChanged += DataGridView_Checkpoints_CurrentCellChanged;
            dataGridView_checkpoints.RowsAdded += DataGridView_Checkpoints_RowsAdded;
            dataGridView_checkpoints.UserDeletingRow += DataGridView_Checkpoints_UserDeletingRow;
            dataGridView_checkpoints.KeyDown += DataGridView_Checkpoints_KeyDown;
            // 
            // Checkpoint
            // 
            Checkpoint.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Checkpoint.DataPropertyName = "Checkpoint";
            Checkpoint.HeaderText = "Název";
            Checkpoint.Name = "Checkpoint";
            Checkpoint.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            dataGridViewCheckBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCheckBoxColumn3.DataPropertyName = "IsParticipating";
            dataGridViewCheckBoxColumn3.HeaderText = "Účast";
            dataGridViewCheckBoxColumn3.MinimumWidth = 100;
            dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // CheckpointDisqualifiable
            // 
            CheckpointDisqualifiable.DataPropertyName = "CheckpointDisqualifiable";
            CheckpointDisqualifiable.HeaderText = "Diskvalifikační";
            CheckpointDisqualifiable.Name = "CheckpointDisqualifiable";
            // 
            // checkpointAgeCategoryParticipationBindingSource
            // 
            checkpointAgeCategoryParticipationBindingSource.DataSource = typeof(Data.CheckpointAgeCategoryParticipation);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 469);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1284, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // groupBox_edit_checkpoint
            // 
            groupBox_edit_checkpoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox_edit_checkpoint.Controls.Add(checkBox_disqualifiable);
            groupBox_edit_checkpoint.Controls.Add(label_name_checkpoint);
            groupBox_edit_checkpoint.Controls.Add(textBox_name_checkpoint);
            groupBox_edit_checkpoint.Controls.Add(button_save_checkpoint);
            groupBox_edit_checkpoint.Location = new Point(805, 12);
            groupBox_edit_checkpoint.Name = "groupBox_edit_checkpoint";
            groupBox_edit_checkpoint.Size = new Size(467, 93);
            groupBox_edit_checkpoint.TabIndex = 13;
            groupBox_edit_checkpoint.TabStop = false;
            groupBox_edit_checkpoint.Text = "Přidat/upravit stanoviště";
            // 
            // checkBox_disqualifiable
            // 
            checkBox_disqualifiable.AutoSize = true;
            checkBox_disqualifiable.Location = new Point(231, 46);
            checkBox_disqualifiable.Name = "checkBox_disqualifiable";
            checkBox_disqualifiable.Size = new Size(101, 19);
            checkBox_disqualifiable.TabIndex = 10;
            checkBox_disqualifiable.Text = "Diskvalifikační";
            checkBox_disqualifiable.UseVisualStyleBackColor = true;
            // 
            // label_name_checkpoint
            // 
            label_name_checkpoint.AutoSize = true;
            label_name_checkpoint.Location = new Point(23, 26);
            label_name_checkpoint.Name = "label_name_checkpoint";
            label_name_checkpoint.Size = new Size(44, 15);
            label_name_checkpoint.TabIndex = 9;
            label_name_checkpoint.Text = "Název*";
            // 
            // button_save_checkpoint
            // 
            button_save_checkpoint.Location = new Point(359, 38);
            button_save_checkpoint.Margin = new Padding(3, 3, 15, 3);
            button_save_checkpoint.Name = "button_save_checkpoint";
            button_save_checkpoint.Size = new Size(90, 33);
            button_save_checkpoint.TabIndex = 8;
            button_save_checkpoint.Text = "Přidat";
            button_save_checkpoint.UseVisualStyleBackColor = true;
            button_save_checkpoint.Click += Button_Checkpoint_Save_Click;
            // 
            // errorProvider_checkpoint
            // 
            errorProvider_checkpoint.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider_checkpoint.ContainerControl = this;
            // 
            // AgeCategoriesEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1284, 491);
            Controls.Add(groupBox_edit_checkpoint);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox_checkpoints);
            Controls.Add(groupBox_edit_category);
            Controls.Add(groupBox_categories);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1300, 530);
            Name = "AgeCategoriesEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nastavení věkových kategorií a stanovišť";
            Load += AgeCategoriesEditor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_categories).EndInit();
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).EndInit();
            groupBox_categories.ResumeLayout(false);
            groupBox_edit_category.ResumeLayout(false);
            groupBox_edit_category.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_category).EndInit();
            groupBox_checkpoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_checkpoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkpointAgeCategoryParticipationBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox_edit_checkpoint.ResumeLayout(false);
            groupBox_edit_checkpoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_checkpoint).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView_categories;
        private GroupBox groupBox_categories;
        private GroupBox groupBox_edit_category;
        private Label label_code;
        private TextBox textBox_code;
        private Label label_name_category;
        private TextBox textBox_name_category;
        private Button button_save_category;
        private Label label_color;
        private Label label_ageMax;
        private TextBox textBox_ageMax;
        private Label label_ageMin;
        private TextBox textBox_ageMin;
        private TextBox textBox_color;
        private ErrorProvider errorProvider_category;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageMaxDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn duoDataGridViewCheckBoxColumn;
        private GroupBox groupBox_checkpoints;
        private DataGridView dataGridView_checkpoints;
        private DataGridViewTextBoxColumn checkpointNameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isParticipatingDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private BindingSource ageCategoryBindingSource;
        private BindingSource checkpointAgeCategoryParticipationBindingSource;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label label_type;
        private ComboBox comboBox_type;
        private GroupBox groupBox_edit_checkpoint;
        private Button button_save_checkpoint;
        private Label label_name_checkpoint;
        private TextBox textBox_name_checkpoint;
        private ErrorProvider errorProvider_checkpoint;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn TypeString;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private CheckBox checkBox_disqualifiable;
        private DataGridViewTextBoxColumn Checkpoint;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewCheckBoxColumn CheckpointDisqualifiable;
    }
}