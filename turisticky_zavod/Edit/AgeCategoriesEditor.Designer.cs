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
            dataGridView_categories = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            ageCategoryBindingSource = new BindingSource(components);
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            groupBox_categories = new GroupBox();
            groupBox_edit = new GroupBox();
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
            button_save = new Button();
            errorProvider = new ErrorProvider(components);
            groupBox_checkpoints = new GroupBox();
            dataGridView_checkpoints = new DataGridView();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
            checkpointAgeCategoryParticipationBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView_categories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).BeginInit();
            groupBox_categories.SuspendLayout();
            groupBox_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox_checkpoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_checkpoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkpointAgeCategoryParticipationBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
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
            dataGridView_categories.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewCheckBoxColumn2 });
            dataGridView_categories.DataSource = ageCategoryBindingSource;
            dataGridView_categories.Location = new Point(6, 22);
            dataGridView_categories.MultiSelect = false;
            dataGridView_categories.Name = "dataGridView_categories";
            dataGridView_categories.ReadOnly = true;
            dataGridView_categories.RowHeadersWidth = 50;
            dataGridView_categories.RowTemplate.Height = 25;
            dataGridView_categories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_categories.Size = new Size(718, 251);
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
            dataGridViewTextBoxColumn9.HeaderText = "Věk do";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "Color";
            dataGridViewTextBoxColumn10.HeaderText = "Barva";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.DataPropertyName = "Duo";
            dataGridViewCheckBoxColumn2.HeaderText = "Dvojice";
            dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            dataGridViewCheckBoxColumn2.ReadOnly = true;
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
            groupBox_categories.Size = new Size(730, 279);
            groupBox_categories.TabIndex = 8;
            groupBox_categories.TabStop = false;
            groupBox_categories.Text = "Věkové kategorie";
            // 
            // groupBox_edit
            // 
            groupBox_edit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_edit.Controls.Add(textBox_color);
            groupBox_edit.Controls.Add(label5);
            groupBox_edit.Controls.Add(checkBox_duo);
            groupBox_edit.Controls.Add(label4);
            groupBox_edit.Controls.Add(textBox_ageMax);
            groupBox_edit.Controls.Add(label3);
            groupBox_edit.Controls.Add(label2);
            groupBox_edit.Controls.Add(textBox_ageMin);
            groupBox_edit.Controls.Add(textBox_code);
            groupBox_edit.Controls.Add(label1);
            groupBox_edit.Controls.Add(textBox_name);
            groupBox_edit.Controls.Add(button_save);
            groupBox_edit.Location = new Point(12, 12);
            groupBox_edit.Name = "groupBox_edit";
            groupBox_edit.Size = new Size(730, 93);
            groupBox_edit.TabIndex = 9;
            groupBox_edit.TabStop = false;
            groupBox_edit.Text = "Přidat/upravit kategorii";
            // 
            // textBox_color
            // 
            errorProvider.SetIconAlignment(textBox_color, ErrorIconAlignment.MiddleLeft);
            textBox_color.Location = new Point(434, 44);
            textBox_color.Name = "textBox_color";
            textBox_color.Size = new Size(68, 23);
            textBox_color.TabIndex = 4;
            textBox_color.KeyPress += TextBox_Color_KeyPress;
            textBox_color.Validating += TextBox_Color_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 26);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 16;
            label5.Text = "Barva*";
            // 
            // checkBox_duo
            // 
            checkBox_duo.AutoSize = true;
            checkBox_duo.Location = new Point(521, 40);
            checkBox_duo.Name = "checkBox_duo";
            checkBox_duo.Size = new Size(65, 19);
            checkBox_duo.TabIndex = 5;
            checkBox_duo.Text = "Dvojice";
            checkBox_duo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(365, 26);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 13;
            label4.Text = "Věk do";
            // 
            // textBox_ageMax
            // 
            errorProvider.SetIconAlignment(textBox_ageMax, ErrorIconAlignment.MiddleLeft);
            textBox_ageMax.Location = new Point(365, 44);
            textBox_ageMax.Name = "textBox_ageMax";
            textBox_ageMax.Size = new Size(54, 23);
            textBox_ageMax.TabIndex = 3;
            textBox_ageMax.KeyDown += TextBox_AgeMax_KeyDown;
            textBox_ageMax.KeyPress += TextBox_AgeMax_KeyPress;
            textBox_ageMax.Validating += TextBox_AgeMax_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 26);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 11;
            label3.Text = "Věk od*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 26);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Zkratka*";
            // 
            // textBox_ageMin
            // 
            errorProvider.SetIconAlignment(textBox_ageMin, ErrorIconAlignment.MiddleLeft);
            textBox_ageMin.Location = new Point(296, 44);
            textBox_ageMin.Name = "textBox_ageMin";
            textBox_ageMin.Size = new Size(54, 23);
            textBox_ageMin.TabIndex = 2;
            textBox_ageMin.KeyDown += TextBox_AgeMin_KeyDown;
            textBox_ageMin.KeyPress += TextBox_AgeMin_KeyPress;
            textBox_ageMin.Validating += TextBox_AgeMin_Validating;
            // 
            // textBox_code
            // 
            errorProvider.SetIconAlignment(textBox_code, ErrorIconAlignment.MiddleLeft);
            textBox_code.Location = new Point(188, 44);
            textBox_code.Name = "textBox_code";
            textBox_code.Size = new Size(93, 23);
            textBox_code.TabIndex = 1;
            textBox_code.KeyPress += TextBox_Code_KeyPress;
            textBox_code.Validating += TextBox_Code_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 26);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Název*";
            // 
            // textBox_name
            // 
            errorProvider.SetIconAlignment(textBox_name, ErrorIconAlignment.MiddleLeft);
            textBox_name.Location = new Point(20, 44);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(152, 23);
            textBox_name.TabIndex = 0;
            textBox_name.KeyPress += TextBox_Name_KeyPress;
            textBox_name.Validating += TextBox_Name_Validating;
            // 
            // button_save
            // 
            button_save.Location = new Point(622, 34);
            button_save.Name = "button_save";
            button_save.Size = new Size(90, 33);
            button_save.TabIndex = 6;
            button_save.Text = "Přidat";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += Button_Save_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // groupBox_checkpoints
            // 
            groupBox_checkpoints.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_checkpoints.Controls.Add(dataGridView_checkpoints);
            groupBox_checkpoints.Location = new Point(12, 396);
            groupBox_checkpoints.Name = "groupBox_checkpoints";
            groupBox_checkpoints.Size = new Size(730, 299);
            groupBox_checkpoints.TabIndex = 11;
            groupBox_checkpoints.TabStop = false;
            groupBox_checkpoints.Text = "Stanoviště";
            // 
            // dataGridView_checkpoints
            // 
            dataGridView_checkpoints.AllowUserToAddRows = false;
            dataGridView_checkpoints.AllowUserToDeleteRows = false;
            dataGridView_checkpoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_checkpoints.AutoGenerateColumns = false;
            dataGridView_checkpoints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_checkpoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_checkpoints.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn11, dataGridViewCheckBoxColumn3 });
            dataGridView_checkpoints.DataSource = checkpointAgeCategoryParticipationBindingSource;
            dataGridView_checkpoints.Location = new Point(6, 22);
            dataGridView_checkpoints.Name = "dataGridView_checkpoints";
            dataGridView_checkpoints.RowHeadersWidth = 50;
            dataGridView_checkpoints.RowTemplate.Height = 25;
            dataGridView_checkpoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_checkpoints.Size = new Size(718, 271);
            dataGridView_checkpoints.TabIndex = 0;
            dataGridView_checkpoints.CellEndEdit += DataGridView_Checkpoints_CellEndEdit;
            dataGridView_checkpoints.RowsAdded += DataGridView_Checkpoints_RowsAdded;
            dataGridView_checkpoints.KeyDown += DataGridView_Checkpoints_KeyDown;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn11.DataPropertyName = "CheckpointName";
            dataGridViewTextBoxColumn11.HeaderText = "Název";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            dataGridViewCheckBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCheckBoxColumn3.DataPropertyName = "IsParticipating";
            dataGridViewCheckBoxColumn3.HeaderText = "Účast";
            dataGridViewCheckBoxColumn3.MinimumWidth = 100;
            dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // checkpointAgeCategoryParticipationBindingSource
            // 
            checkpointAgeCategoryParticipationBindingSource.DataSource = typeof(Data.CheckpointAgeCategoryParticipation);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 698);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(754, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // AgeCategoriesEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(754, 720);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox_checkpoints);
            Controls.Add(groupBox_edit);
            Controls.Add(groupBox_categories);
            HelpButton = true;
            MinimumSize = new Size(770, 300);
            Name = "AgeCategoriesEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nastavení věkových kategorií";
            Load += AgeCategoriesEditor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_categories).EndInit();
            ((System.ComponentModel.ISupportInitialize)ageCategoryBindingSource).EndInit();
            groupBox_categories.ResumeLayout(false);
            groupBox_edit.ResumeLayout(false);
            groupBox_edit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox_checkpoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_checkpoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkpointAgeCategoryParticipationBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView_categories;
        private GroupBox groupBox_categories;
        private GroupBox groupBox_edit;
        private Label label2;
        private TextBox textBox_code;
        private Label label1;
        private TextBox textBox_name;
        private Button button_save;
        private Label label5;
        private CheckBox checkBox_duo;
        private Label label4;
        private TextBox textBox_ageMax;
        private Label label3;
        private TextBox textBox_ageMin;
        private TextBox textBox_color;
        private ErrorProvider errorProvider;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private BindingSource ageCategoryBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private BindingSource checkpointAgeCategoryParticipationBindingSource;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}