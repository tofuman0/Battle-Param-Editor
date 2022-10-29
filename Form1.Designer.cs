namespace Battle_Param_Editor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbDifficulty = new System.Windows.Forms.ToolStripComboBox();
            this.cbStatisticTable = new System.Windows.Forms.ToolStripComboBox();
            this.dataOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTableDataToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCopyTableTo = new System.Windows.Forms.ToolStripComboBox();
            this.copyTableDataFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCopyTableFrom = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dgTableView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.increaseByPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseByNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTableView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.cbDifficulty,
            this.cbStatisticTable,
            this.dataOperationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.Enabled = false;
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(121, 23);
            this.cbDifficulty.Text = "Difficulty";
            this.cbDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbDifficulty_SelectedIndexChanged);
            // 
            // cbStatisticTable
            // 
            this.cbStatisticTable.Enabled = false;
            this.cbStatisticTable.Items.AddRange(new object[] {
            "Physical Stats",
            "Resist Stats",
            "Attack Stats",
            "Movement Stats"});
            this.cbStatisticTable.Name = "cbStatisticTable";
            this.cbStatisticTable.Size = new System.Drawing.Size(121, 23);
            this.cbStatisticTable.Text = "Statistic Table";
            this.cbStatisticTable.SelectedIndexChanged += new System.EventHandler(this.cbStatisticTable_SelectedIndexChanged);
            // 
            // dataOperationsToolStripMenuItem
            // 
            this.dataOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDifficultyToolStripMenuItem,
            this.copyTableDataToToolStripMenuItem,
            this.copyTableDataFromToolStripMenuItem});
            this.dataOperationsToolStripMenuItem.Enabled = false;
            this.dataOperationsToolStripMenuItem.Name = "dataOperationsToolStripMenuItem";
            this.dataOperationsToolStripMenuItem.Size = new System.Drawing.Size(104, 23);
            this.dataOperationsToolStripMenuItem.Text = "Data Operations";
            // 
            // addDifficultyToolStripMenuItem
            // 
            this.addDifficultyToolStripMenuItem.Name = "addDifficultyToolStripMenuItem";
            this.addDifficultyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addDifficultyToolStripMenuItem.Text = "Add Difficulty";
            this.addDifficultyToolStripMenuItem.Click += new System.EventHandler(this.addDifficultyToolStripMenuItem_Click);
            // 
            // copyTableDataToToolStripMenuItem
            // 
            this.copyTableDataToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbCopyTableTo});
            this.copyTableDataToToolStripMenuItem.Name = "copyTableDataToToolStripMenuItem";
            this.copyTableDataToToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyTableDataToToolStripMenuItem.Text = "Copy table data to";
            // 
            // cbCopyTableTo
            // 
            this.cbCopyTableTo.Name = "cbCopyTableTo";
            this.cbCopyTableTo.Size = new System.Drawing.Size(121, 23);
            this.cbCopyTableTo.Text = "Select table";
            this.cbCopyTableTo.SelectedIndexChanged += new System.EventHandler(this.cbCopyTableTo_SelectedIndexChanged);
            // 
            // copyTableDataFromToolStripMenuItem
            // 
            this.copyTableDataFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbCopyTableFrom});
            this.copyTableDataFromToolStripMenuItem.Name = "copyTableDataFromToolStripMenuItem";
            this.copyTableDataFromToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyTableDataFromToolStripMenuItem.Text = "Copy table data from";
            // 
            // cbCopyTableFrom
            // 
            this.cbCopyTableFrom.Name = "cbCopyTableFrom";
            this.cbCopyTableFrom.Size = new System.Drawing.Size(121, 23);
            this.cbCopyTableFrom.Text = "Select table";
            this.cbCopyTableFrom.SelectedIndexChanged += new System.EventHandler(this.cbCopyTableFrom_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 17);
            this.Status.Text = "Ready";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dgTableView
            // 
            this.dgTableView.AllowUserToAddRows = false;
            this.dgTableView.AllowUserToDeleteRows = false;
            this.dgTableView.AllowUserToResizeColumns = false;
            this.dgTableView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgTableView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTableView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgTableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTableView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgTableView.Location = new System.Drawing.Point(0, 27);
            this.dgTableView.Name = "dgTableView";
            this.dgTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgTableView.Size = new System.Drawing.Size(524, 313);
            this.dgTableView.TabIndex = 2;
            this.dgTableView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTableView_CellMouseDown);
            this.dgTableView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTableView_CellValueChanged);
            this.dgTableView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTableView_ColumnHeaderMouseClick);
            this.dgTableView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgTableView_DataBindingComplete);
            this.dgTableView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgTableView_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseByPToolStripMenuItem,
            this.increaseByNToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 48);
            // 
            // increaseByPToolStripMenuItem
            // 
            this.increaseByPToolStripMenuItem.Name = "increaseByPToolStripMenuItem";
            this.increaseByPToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.increaseByPToolStripMenuItem.Text = "Increase by %";
            this.increaseByPToolStripMenuItem.Click += new System.EventHandler(this.increaseByPToolStripMenuItem_Click);
            // 
            // increaseByNToolStripMenuItem
            // 
            this.increaseByNToolStripMenuItem.Name = "increaseByNToolStripMenuItem";
            this.increaseByNToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.increaseByNToolStripMenuItem.Text = "Increase by n";
            this.increaseByNToolStripMenuItem.Click += new System.EventHandler(this.increaseByNToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 362);
            this.Controls.Add(this.dgTableView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(540, 400);
            this.Name = "Form1";
            this.Text = "Battle Param Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTableView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbDifficulty;
        private System.Windows.Forms.ToolStripComboBox cbStatisticTable;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView dgTableView;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.ToolStripMenuItem dataOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDifficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTableDataToToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbCopyTableTo;
        private System.Windows.Forms.ToolStripMenuItem copyTableDataFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbCopyTableFrom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem increaseByPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseByNToolStripMenuItem;
    }
}

