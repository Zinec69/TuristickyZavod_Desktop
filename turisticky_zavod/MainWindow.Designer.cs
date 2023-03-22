namespace Forms
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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            runnerIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            teamDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageCategoryFormattedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startTimeFormattedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            finishTimeFormattedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disqualifiedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            runnerBindingSource = new BindingSource(components);
            runnersGroupBox = new GroupBox();
            menuStrip1 = new MenuStrip();
            importDatToolStripMenuItem = new ToolStripMenuItem();
            cSVToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            nFCToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)runnerBindingSource).BeginInit();
            runnersGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 499);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1034, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { runnerIDDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, teamDataGridViewTextBoxColumn, ageCategoryFormattedDataGridViewTextBoxColumn, startTimeFormattedDataGridViewTextBoxColumn, finishTimeFormattedDataGridViewTextBoxColumn, disqualifiedDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = runnerBindingSource;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(998, 441);
            dataGridView1.TabIndex = 3;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
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
            // teamDataGridViewTextBoxColumn
            // 
            teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            teamDataGridViewTextBoxColumn.HeaderText = "Oddíl";
            teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            // 
            // ageCategoryFormattedDataGridViewTextBoxColumn
            // 
            ageCategoryFormattedDataGridViewTextBoxColumn.DataPropertyName = "AgeCategoryFormatted";
            ageCategoryFormattedDataGridViewTextBoxColumn.HeaderText = "Věková kategorie";
            ageCategoryFormattedDataGridViewTextBoxColumn.Name = "ageCategoryFormattedDataGridViewTextBoxColumn";
            ageCategoryFormattedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeFormattedDataGridViewTextBoxColumn
            // 
            startTimeFormattedDataGridViewTextBoxColumn.DataPropertyName = "StartTimeFormatted";
            startTimeFormattedDataGridViewTextBoxColumn.HeaderText = "Čas startu";
            startTimeFormattedDataGridViewTextBoxColumn.Name = "startTimeFormattedDataGridViewTextBoxColumn";
            startTimeFormattedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finishTimeFormattedDataGridViewTextBoxColumn
            // 
            finishTimeFormattedDataGridViewTextBoxColumn.DataPropertyName = "FinishTimeFormatted";
            finishTimeFormattedDataGridViewTextBoxColumn.HeaderText = "Čas konce";
            finishTimeFormattedDataGridViewTextBoxColumn.Name = "finishTimeFormattedDataGridViewTextBoxColumn";
            finishTimeFormattedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // disqualifiedDataGridViewCheckBoxColumn
            // 
            disqualifiedDataGridViewCheckBoxColumn.DataPropertyName = "Disqualified";
            disqualifiedDataGridViewCheckBoxColumn.HeaderText = "Diskvalifikován/a";
            disqualifiedDataGridViewCheckBoxColumn.Name = "disqualifiedDataGridViewCheckBoxColumn";
            // 
            // runnerBindingSource
            // 
            runnerBindingSource.DataSource = typeof(Data.Runner);
            // 
            // runnersGroupBox
            // 
            runnersGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            runnersGroupBox.Controls.Add(dataGridView1);
            runnersGroupBox.Location = new Point(12, 27);
            runnersGroupBox.Name = "runnersGroupBox";
            runnersGroupBox.Size = new Size(1010, 469);
            runnersGroupBox.TabIndex = 4;
            runnersGroupBox.TabStop = false;
            runnersGroupBox.Text = "Seznam běžců";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { importDatToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1034, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // importDatToolStripMenuItem
            // 
            importDatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cSVToolStripMenuItem, jSONToolStripMenuItem, nFCToolStripMenuItem });
            importDatToolStripMenuItem.Name = "importDatToolStripMenuItem";
            importDatToolStripMenuItem.Size = new Size(75, 20);
            importDatToolStripMenuItem.Text = "Import dat";
            // 
            // cSVToolStripMenuItem
            // 
            cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            cSVToolStripMenuItem.Size = new Size(102, 22);
            cSVToolStripMenuItem.Text = "CSV";
            cSVToolStripMenuItem.Click += CSVToolStripMenuItem_Click;
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(102, 22);
            jSONToolStripMenuItem.Text = "JSON";
            jSONToolStripMenuItem.Click += JSONToolStripMenuItem_Click;
            // 
            // nFCToolStripMenuItem
            // 
            nFCToolStripMenuItem.Name = "nFCToolStripMenuItem";
            nFCToolStripMenuItem.Size = new Size(102, 22);
            nFCToolStripMenuItem.Text = "NFC";
            nFCToolStripMenuItem.Click += NFCToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 521);
            Controls.Add(runnersGroupBox);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1050, 215);
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
        private ToolStripMenuItem importDatToolStripMenuItem;
        private ToolStripMenuItem cSVToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
        private ToolStripMenuItem nFCToolStripMenuItem;
        private BindingSource runnerBindingSource;
        private DataGridViewTextBoxColumn runnerIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageCategoryFormattedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startTimeFormattedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finishTimeFormattedDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn disqualifiedDataGridViewCheckBoxColumn;
    }
}