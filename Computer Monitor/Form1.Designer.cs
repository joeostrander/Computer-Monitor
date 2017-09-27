namespace Computer_Monitor
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
            this.checkBoxProcesses = new System.Windows.Forms.CheckBox();
            this.checkBoxEvents = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxProcesses = new System.Windows.Forms.GroupBox();
            this.groupBoxEvents = new System.Windows.Forms.GroupBox();
            this.ListViewEvents = new System.Windows.Forms.ListView();
            this.ColumnHeaderCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderComputer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxMonitorProcessAdditions = new System.Windows.Forms.CheckBox();
            this.checkBoxMonitorProcessDeletions = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ListBoxLogTypes = new System.Windows.Forms.ListBox();
            this.ListBoxLogFiles = new System.Windows.Forms.ListBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.TextBoxComputer = new System.Windows.Forms.TextBox();
            this.panelProcessOptions = new System.Windows.Forms.Panel();
            this.panelEventOptions = new System.Windows.Forms.Panel();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxComputer = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderCommandLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderExecutablePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxProcesses.SuspendLayout();
            this.groupBoxEvents.SuspendLayout();
            this.panelProcessOptions.SuspendLayout();
            this.panelEventOptions.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxComputer.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxProcesses
            // 
            this.checkBoxProcesses.AutoSize = true;
            this.checkBoxProcesses.Checked = true;
            this.checkBoxProcesses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxProcesses.Location = new System.Drawing.Point(7, 19);
            this.checkBoxProcesses.Name = "checkBoxProcesses";
            this.checkBoxProcesses.Size = new System.Drawing.Size(113, 17);
            this.checkBoxProcesses.TabIndex = 1;
            this.checkBoxProcesses.Text = "Monitor &Processes";
            this.checkBoxProcesses.UseVisualStyleBackColor = true;
            this.checkBoxProcesses.CheckedChanged += new System.EventHandler(this.checkBoxProcesses_CheckedChanged);
            // 
            // checkBoxEvents
            // 
            this.checkBoxEvents.AutoSize = true;
            this.checkBoxEvents.Checked = true;
            this.checkBoxEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEvents.Location = new System.Drawing.Point(312, 19);
            this.checkBoxEvents.Name = "checkBoxEvents";
            this.checkBoxEvents.Size = new System.Drawing.Size(97, 17);
            this.checkBoxEvents.TabIndex = 2;
            this.checkBoxEvents.Text = "Monitor &Events";
            this.checkBoxEvents.UseVisualStyleBackColor = true;
            this.checkBoxEvents.CheckedChanged += new System.EventHandler(this.checkBoxEvents_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 172);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxProcesses);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxEvents);
            this.splitContainer1.Size = new System.Drawing.Size(838, 411);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // groupBoxProcesses
            // 
            this.groupBoxProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProcesses.Controls.Add(this.ListView1);
            this.groupBoxProcesses.Location = new System.Drawing.Point(3, 3);
            this.groupBoxProcesses.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupBoxProcesses.Name = "groupBoxProcesses";
            this.groupBoxProcesses.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupBoxProcesses.Size = new System.Drawing.Size(832, 196);
            this.groupBoxProcesses.TabIndex = 0;
            this.groupBoxProcesses.TabStop = false;
            this.groupBoxProcesses.Text = "Process History";
            // 
            // groupBoxEvents
            // 
            this.groupBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEvents.Controls.Add(this.ListViewEvents);
            this.groupBoxEvents.Location = new System.Drawing.Point(3, 3);
            this.groupBoxEvents.Name = "groupBoxEvents";
            this.groupBoxEvents.Size = new System.Drawing.Size(832, 199);
            this.groupBoxEvents.TabIndex = 0;
            this.groupBoxEvents.TabStop = false;
            this.groupBoxEvents.Text = "Events";
            // 
            // ListViewEvents
            // 
            this.ListViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderCreationDate,
            this.ColumnHeaderComputer,
            this.ColumnHeaderEventID,
            this.ColumnHeaderType,
            this.ColumnHeaderSource,
            this.ColumnHeaderMessage});
            this.ListViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewEvents.FullRowSelect = true;
            this.ListViewEvents.GridLines = true;
            this.ListViewEvents.Location = new System.Drawing.Point(3, 16);
            this.ListViewEvents.MultiSelect = false;
            this.ListViewEvents.Name = "ListViewEvents";
            this.ListViewEvents.Size = new System.Drawing.Size(826, 180);
            this.ListViewEvents.TabIndex = 9;
            this.ListViewEvents.UseCompatibleStateImageBehavior = false;
            this.ListViewEvents.View = System.Windows.Forms.View.Details;
            this.ListViewEvents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            // 
            // ColumnHeaderCreationDate
            // 
            this.ColumnHeaderCreationDate.Tag = "Date";
            this.ColumnHeaderCreationDate.Text = "Created";
            this.ColumnHeaderCreationDate.Width = 145;
            // 
            // ColumnHeaderComputer
            // 
            this.ColumnHeaderComputer.Tag = "String";
            this.ColumnHeaderComputer.Text = "Computer";
            this.ColumnHeaderComputer.Width = 150;
            // 
            // ColumnHeaderEventID
            // 
            this.ColumnHeaderEventID.Tag = "Numeric";
            this.ColumnHeaderEventID.Text = "Event ID";
            this.ColumnHeaderEventID.Width = 76;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Tag = "String";
            this.ColumnHeaderType.Text = "Type";
            this.ColumnHeaderType.Width = 100;
            // 
            // ColumnHeaderSource
            // 
            this.ColumnHeaderSource.Tag = "String";
            this.ColumnHeaderSource.Text = "Source";
            this.ColumnHeaderSource.Width = 180;
            // 
            // ColumnHeaderMessage
            // 
            this.ColumnHeaderMessage.Tag = "String";
            this.ColumnHeaderMessage.Text = "Message";
            this.ColumnHeaderMessage.Width = 350;
            // 
            // checkBoxMonitorProcessAdditions
            // 
            this.checkBoxMonitorProcessAdditions.AutoSize = true;
            this.checkBoxMonitorProcessAdditions.Checked = true;
            this.checkBoxMonitorProcessAdditions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonitorProcessAdditions.Location = new System.Drawing.Point(3, 8);
            this.checkBoxMonitorProcessAdditions.Name = "checkBoxMonitorProcessAdditions";
            this.checkBoxMonitorProcessAdditions.Size = new System.Drawing.Size(99, 17);
            this.checkBoxMonitorProcessAdditions.TabIndex = 1;
            this.checkBoxMonitorProcessAdditions.Text = "Show Additions";
            this.checkBoxMonitorProcessAdditions.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonitorProcessDeletions
            // 
            this.checkBoxMonitorProcessDeletions.AutoSize = true;
            this.checkBoxMonitorProcessDeletions.Checked = true;
            this.checkBoxMonitorProcessDeletions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonitorProcessDeletions.Location = new System.Drawing.Point(3, 31);
            this.checkBoxMonitorProcessDeletions.Name = "checkBoxMonitorProcessDeletions";
            this.checkBoxMonitorProcessDeletions.Size = new System.Drawing.Size(100, 17);
            this.checkBoxMonitorProcessDeletions.TabIndex = 4;
            this.checkBoxMonitorProcessDeletions.Text = "Show Deletions";
            this.checkBoxMonitorProcessDeletions.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(206, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Log &Types:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Log &Files:";
            // 
            // ListBoxLogTypes
            // 
            this.ListBoxLogTypes.FormattingEnabled = true;
            this.ListBoxLogTypes.Location = new System.Drawing.Point(272, 9);
            this.ListBoxLogTypes.Name = "ListBoxLogTypes";
            this.ListBoxLogTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxLogTypes.Size = new System.Drawing.Size(120, 69);
            this.ListBoxLogTypes.TabIndex = 12;
            // 
            // ListBoxLogFiles
            // 
            this.ListBoxLogFiles.FormattingEnabled = true;
            this.ListBoxLogFiles.Location = new System.Drawing.Point(61, 9);
            this.ListBoxLogFiles.Name = "ListBoxLogFiles";
            this.ListBoxLogFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxLogFiles.Size = new System.Drawing.Size(120, 69);
            this.ListBoxLogFiles.TabIndex = 10;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(199, 17);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(104, 23);
            this.ButtonStart.TabIndex = 13;
            this.ButtonStart.Text = "&Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // TextBoxComputer
            // 
            this.TextBoxComputer.Location = new System.Drawing.Point(6, 19);
            this.TextBoxComputer.Name = "TextBoxComputer";
            this.TextBoxComputer.Size = new System.Drawing.Size(187, 20);
            this.TextBoxComputer.TabIndex = 8;
            // 
            // panelProcessOptions
            // 
            this.panelProcessOptions.Controls.Add(this.checkBox1);
            this.panelProcessOptions.Controls.Add(this.checkBoxMonitorProcessAdditions);
            this.panelProcessOptions.Controls.Add(this.checkBoxMonitorProcessDeletions);
            this.panelProcessOptions.Location = new System.Drawing.Point(126, 11);
            this.panelProcessOptions.Name = "panelProcessOptions";
            this.panelProcessOptions.Size = new System.Drawing.Size(152, 78);
            this.panelProcessOptions.TabIndex = 14;
            // 
            // panelEventOptions
            // 
            this.panelEventOptions.Controls.Add(this.ListBoxLogFiles);
            this.panelEventOptions.Controls.Add(this.Label3);
            this.panelEventOptions.Controls.Add(this.ListBoxLogTypes);
            this.panelEventOptions.Controls.Add(this.Label2);
            this.panelEventOptions.Location = new System.Drawing.Point(415, 11);
            this.panelEventOptions.Name = "panelEventOptions";
            this.panelEventOptions.Size = new System.Drawing.Size(399, 84);
            this.panelEventOptions.TabIndex = 15;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptions.Controls.Add(this.checkBoxProcesses);
            this.groupBoxOptions.Controls.Add(this.checkBoxEvents);
            this.groupBoxOptions.Controls.Add(this.panelProcessOptions);
            this.groupBoxOptions.Controls.Add(this.panelEventOptions);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(832, 97);
            this.groupBoxOptions.TabIndex = 16;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "&Options";
            // 
            // groupBoxComputer
            // 
            this.groupBoxComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxComputer.Controls.Add(this.TextBoxComputer);
            this.groupBoxComputer.Controls.Add(this.ButtonStart);
            this.groupBoxComputer.Location = new System.Drawing.Point(12, 115);
            this.groupBoxComputer.Name = "groupBoxComputer";
            this.groupBoxComputer.Size = new System.Drawing.Size(832, 51);
            this.groupBoxComputer.TabIndex = 17;
            this.groupBoxComputer.TabStop = false;
            this.groupBoxComputer.Text = "&Computer";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Existing Processes";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            this.ListView1.AllowColumnReorder = true;
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.ColumnHeaderName,
            this.ColumnHeaderPID,
            this.ColumnHeaderUserName,
            this.ColumnHeaderCommandLine,
            this.ColumnHeaderExecutablePath});
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.Location = new System.Drawing.Point(0, 16);
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(832, 177);
            this.ListView1.TabIndex = 3;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Date";
            this.columnHeader1.Text = "Created";
            this.columnHeader1.Width = 145;
            // 
            // ColumnHeaderName
            // 
            this.ColumnHeaderName.Tag = "String";
            this.ColumnHeaderName.Text = "Name";
            this.ColumnHeaderName.Width = 117;
            // 
            // ColumnHeaderPID
            // 
            this.ColumnHeaderPID.Tag = "Numeric";
            this.ColumnHeaderPID.Text = "PID";
            this.ColumnHeaderPID.Width = 76;
            // 
            // ColumnHeaderUserName
            // 
            this.ColumnHeaderUserName.Tag = "String";
            this.ColumnHeaderUserName.Text = "User Name";
            this.ColumnHeaderUserName.Width = 114;
            // 
            // ColumnHeaderCommandLine
            // 
            this.ColumnHeaderCommandLine.Tag = "String";
            this.ColumnHeaderCommandLine.Text = "Command Line";
            this.ColumnHeaderCommandLine.Width = 276;
            // 
            // ColumnHeaderExecutablePath
            // 
            this.ColumnHeaderExecutablePath.Tag = "String";
            this.ColumnHeaderExecutablePath.Text = "Executable Path";
            this.ColumnHeaderExecutablePath.Width = 239;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 595);
            this.Controls.Add(this.groupBoxComputer);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(872, 575);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxProcesses.ResumeLayout(false);
            this.groupBoxEvents.ResumeLayout(false);
            this.panelProcessOptions.ResumeLayout(false);
            this.panelProcessOptions.PerformLayout();
            this.panelEventOptions.ResumeLayout(false);
            this.panelEventOptions.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxComputer.ResumeLayout(false);
            this.groupBoxComputer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxProcesses;
        private System.Windows.Forms.CheckBox checkBoxEvents;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxProcesses;
        private System.Windows.Forms.GroupBox groupBoxEvents;
        internal System.Windows.Forms.ListView ListViewEvents;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderCreationDate;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderComputer;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderEventID;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderType;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderSource;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderMessage;
        private System.Windows.Forms.CheckBox checkBoxMonitorProcessAdditions;
        private System.Windows.Forms.CheckBox checkBoxMonitorProcessDeletions;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ListBox ListBoxLogTypes;
        internal System.Windows.Forms.ListBox ListBoxLogFiles;
        internal System.Windows.Forms.Button ButtonStart;
        internal System.Windows.Forms.TextBox TextBoxComputer;
        private System.Windows.Forms.Panel panelProcessOptions;
        private System.Windows.Forms.Panel panelEventOptions;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxComputer;
        private System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.ListView ListView1;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderName;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderPID;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderUserName;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderCommandLine;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderExecutablePath;
    }
}

