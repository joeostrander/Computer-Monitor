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
            this.components = new System.ComponentModel.Container();
            this.checkBoxProcesses = new System.Windows.Forms.CheckBox();
            this.checkBoxEvents = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxProcesses = new System.Windows.Forms.GroupBox();
            this.ListViewProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderTerminationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderCommandLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderExecutablePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxEvents = new System.Windows.Forms.GroupBox();
            this.ListViewEvents = new System.Windows.Forms.ListView();
            this.ColumnHeaderCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderComputer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxMonitorProcessAdditions = new System.Windows.Forms.CheckBox();
            this.checkBoxMonitorProcessDeletions = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ListBoxLogTypes = new System.Windows.Forms.ListBox();
            this.ListBoxLogFiles = new System.Windows.Forms.ListBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.TextBoxComputer = new System.Windows.Forms.TextBox();
            this.panelProcessOptions = new System.Windows.Forms.Panel();
            this.checkBoxExistingProcesses = new System.Windows.Forms.CheckBox();
            this.panelEventOptions = new System.Windows.Forms.Panel();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxComputer = new System.Windows.Forms.GroupBox();
            this.contextMenuStripForm1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CheckBoxAlternateCredentials = new System.Windows.Forms.CheckBox();
            this.ButtonSetCredentials = new System.Windows.Forms.Button();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItemProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItemEvents = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxProcesses.SuspendLayout();
            this.contextMenuStripProcesses.SuspendLayout();
            this.groupBoxEvents.SuspendLayout();
            this.contextMenuStripEvents.SuspendLayout();
            this.panelProcessOptions.SuspendLayout();
            this.panelEventOptions.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxComputer.SuspendLayout();
            this.contextMenuStripForm1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.checkBoxProcesses.TabIndex = 0;
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
            this.splitContainer1.Size = new System.Drawing.Size(838, 399);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // groupBoxProcesses
            // 
            this.groupBoxProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProcesses.Controls.Add(this.ListViewProcesses);
            this.groupBoxProcesses.Location = new System.Drawing.Point(3, 3);
            this.groupBoxProcesses.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupBoxProcesses.Name = "groupBoxProcesses";
            this.groupBoxProcesses.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupBoxProcesses.Size = new System.Drawing.Size(832, 186);
            this.groupBoxProcesses.TabIndex = 0;
            this.groupBoxProcesses.TabStop = false;
            this.groupBoxProcesses.Text = "Process History";
            // 
            // ListViewProcesses
            // 
            this.ListViewProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.ColumnHeaderTerminationDate,
            this.ColumnHeaderName,
            this.ColumnHeaderPID,
            this.ColumnHeaderUserName,
            this.ColumnHeaderCommandLine,
            this.ColumnHeaderExecutablePath});
            this.ListViewProcesses.ContextMenuStrip = this.contextMenuStripProcesses;
            this.ListViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewProcesses.FullRowSelect = true;
            this.ListViewProcesses.GridLines = true;
            this.ListViewProcesses.Location = new System.Drawing.Point(0, 16);
            this.ListViewProcesses.MultiSelect = false;
            this.ListViewProcesses.Name = "ListViewProcesses";
            this.ListViewProcesses.Size = new System.Drawing.Size(832, 167);
            this.ListViewProcesses.TabIndex = 0;
            this.ListViewProcesses.UseCompatibleStateImageBehavior = false;
            this.ListViewProcesses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Date";
            this.columnHeader1.Text = "Created";
            this.columnHeader1.Width = 145;
            // 
            // ColumnHeaderTerminationDate
            // 
            this.ColumnHeaderTerminationDate.Tag = "Date";
            this.ColumnHeaderTerminationDate.Text = "Terminated";
            this.ColumnHeaderTerminationDate.Width = 145;
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
            // contextMenuStripProcesses
            // 
            this.contextMenuStripProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.copyRowToolStripMenuItemProcesses});
            this.contextMenuStripProcesses.Name = "contextMenuStripProcesses";
            this.contextMenuStripProcesses.ShowImageMargin = false;
            this.contextMenuStripProcesses.Size = new System.Drawing.Size(128, 92);
            this.contextMenuStripProcesses.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripProcesses_Opening);
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.terminateToolStripMenuItem.Text = "&Terminate";
            this.terminateToolStripMenuItem.Click += new System.EventHandler(this.terminateToolStripMenuItem_Click);
            // 
            // groupBoxEvents
            // 
            this.groupBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEvents.Controls.Add(this.ListViewEvents);
            this.groupBoxEvents.Location = new System.Drawing.Point(3, 3);
            this.groupBoxEvents.Name = "groupBoxEvents";
            this.groupBoxEvents.Size = new System.Drawing.Size(832, 197);
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
            this.ListViewEvents.ContextMenuStrip = this.contextMenuStripEvents;
            this.ListViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewEvents.FullRowSelect = true;
            this.ListViewEvents.GridLines = true;
            this.ListViewEvents.Location = new System.Drawing.Point(3, 16);
            this.ListViewEvents.MultiSelect = false;
            this.ListViewEvents.Name = "ListViewEvents";
            this.ListViewEvents.Size = new System.Drawing.Size(826, 178);
            this.ListViewEvents.TabIndex = 0;
            this.ListViewEvents.UseCompatibleStateImageBehavior = false;
            this.ListViewEvents.View = System.Windows.Forms.View.Details;
            this.ListViewEvents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this.ListViewEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewEvents_MouseDoubleClick);
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
            // contextMenuStripEvents
            // 
            this.contextMenuStripEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMessageToolStripMenuItem,
            this.exportToolStripMenuItem1,
            this.copyRowToolStripMenuItemEvents});
            this.contextMenuStripEvents.Name = "contextMenuStripEvents";
            this.contextMenuStripEvents.ShowImageMargin = false;
            this.contextMenuStripEvents.Size = new System.Drawing.Size(124, 70);
            this.contextMenuStripEvents.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripEvents_Opening);
            // 
            // viewMessageToolStripMenuItem
            // 
            this.viewMessageToolStripMenuItem.Name = "viewMessageToolStripMenuItem";
            this.viewMessageToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.viewMessageToolStripMenuItem.Text = "&View Message";
            this.viewMessageToolStripMenuItem.Click += new System.EventHandler(this.viewMessageToolStripMenuItem_Click);
            // 
            // checkBoxMonitorProcessAdditions
            // 
            this.checkBoxMonitorProcessAdditions.AutoSize = true;
            this.checkBoxMonitorProcessAdditions.Checked = true;
            this.checkBoxMonitorProcessAdditions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonitorProcessAdditions.Location = new System.Drawing.Point(3, 8);
            this.checkBoxMonitorProcessAdditions.Name = "checkBoxMonitorProcessAdditions";
            this.checkBoxMonitorProcessAdditions.Size = new System.Drawing.Size(99, 17);
            this.checkBoxMonitorProcessAdditions.TabIndex = 0;
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
            this.checkBoxMonitorProcessDeletions.TabIndex = 1;
            this.checkBoxMonitorProcessDeletions.Text = "Show Deletions";
            this.checkBoxMonitorProcessDeletions.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(206, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Log &Types:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Log &Files:";
            // 
            // ListBoxLogTypes
            // 
            this.ListBoxLogTypes.FormattingEnabled = true;
            this.ListBoxLogTypes.Location = new System.Drawing.Point(272, 9);
            this.ListBoxLogTypes.Name = "ListBoxLogTypes";
            this.ListBoxLogTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxLogTypes.Size = new System.Drawing.Size(120, 69);
            this.ListBoxLogTypes.TabIndex = 3;
            // 
            // ListBoxLogFiles
            // 
            this.ListBoxLogFiles.FormattingEnabled = true;
            this.ListBoxLogFiles.Location = new System.Drawing.Point(61, 9);
            this.ListBoxLogFiles.Name = "ListBoxLogFiles";
            this.ListBoxLogFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxLogFiles.Size = new System.Drawing.Size(120, 69);
            this.ListBoxLogFiles.TabIndex = 1;
            // 
            // ButtonStart
            // 
            this.ButtonStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonStart.Location = new System.Drawing.Point(199, 17);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(104, 23);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "&Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // TextBoxComputer
            // 
            this.TextBoxComputer.Location = new System.Drawing.Point(6, 19);
            this.TextBoxComputer.Name = "TextBoxComputer";
            this.TextBoxComputer.Size = new System.Drawing.Size(187, 20);
            this.TextBoxComputer.TabIndex = 0;
            // 
            // panelProcessOptions
            // 
            this.panelProcessOptions.Controls.Add(this.checkBoxExistingProcesses);
            this.panelProcessOptions.Controls.Add(this.checkBoxMonitorProcessAdditions);
            this.panelProcessOptions.Controls.Add(this.checkBoxMonitorProcessDeletions);
            this.panelProcessOptions.Location = new System.Drawing.Point(126, 11);
            this.panelProcessOptions.Name = "panelProcessOptions";
            this.panelProcessOptions.Size = new System.Drawing.Size(152, 78);
            this.panelProcessOptions.TabIndex = 1;
            // 
            // checkBoxExistingProcesses
            // 
            this.checkBoxExistingProcesses.AutoSize = true;
            this.checkBoxExistingProcesses.Location = new System.Drawing.Point(3, 54);
            this.checkBoxExistingProcesses.Name = "checkBoxExistingProcesses";
            this.checkBoxExistingProcesses.Size = new System.Drawing.Size(114, 17);
            this.checkBoxExistingProcesses.TabIndex = 2;
            this.checkBoxExistingProcesses.Text = "Existing Processes";
            this.checkBoxExistingProcesses.UseVisualStyleBackColor = true;
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
            this.panelEventOptions.TabIndex = 3;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptions.ContextMenuStrip = this.contextMenuStripForm1;
            this.groupBoxOptions.Controls.Add(this.checkBoxProcesses);
            this.groupBoxOptions.Controls.Add(this.checkBoxEvents);
            this.groupBoxOptions.Controls.Add(this.panelProcessOptions);
            this.groupBoxOptions.Controls.Add(this.panelEventOptions);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(832, 97);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "&Options";
            // 
            // groupBoxComputer
            // 
            this.groupBoxComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxComputer.ContextMenuStrip = this.contextMenuStripForm1;
            this.groupBoxComputer.Controls.Add(this.ButtonSetCredentials);
            this.groupBoxComputer.Controls.Add(this.CheckBoxAlternateCredentials);
            this.groupBoxComputer.Controls.Add(this.TextBoxComputer);
            this.groupBoxComputer.Controls.Add(this.ButtonStart);
            this.groupBoxComputer.Location = new System.Drawing.Point(12, 115);
            this.groupBoxComputer.Name = "groupBoxComputer";
            this.groupBoxComputer.Size = new System.Drawing.Size(832, 51);
            this.groupBoxComputer.TabIndex = 1;
            this.groupBoxComputer.TabStop = false;
            this.groupBoxComputer.Text = "&Computer";
            // 
            // contextMenuStripForm1
            // 
            this.contextMenuStripForm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.contextMenuStripForm1.Name = "contextMenuStripForm1";
            this.contextMenuStripForm1.ShowImageMargin = false;
            this.contextMenuStripForm1.Size = new System.Drawing.Size(83, 26);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // CheckBoxAlternateCredentials
            // 
            this.CheckBoxAlternateCredentials.AutoSize = true;
            this.CheckBoxAlternateCredentials.Location = new System.Drawing.Point(325, 21);
            this.CheckBoxAlternateCredentials.Name = "CheckBoxAlternateCredentials";
            this.CheckBoxAlternateCredentials.Size = new System.Drawing.Size(145, 17);
            this.CheckBoxAlternateCredentials.TabIndex = 9;
            this.CheckBoxAlternateCredentials.Text = "Use &Alternate Credentials";
            this.CheckBoxAlternateCredentials.UseVisualStyleBackColor = true;
            this.CheckBoxAlternateCredentials.CheckedChanged += new System.EventHandler(this.CheckBoxAlternateCredentials_CheckedChanged);
            // 
            // ButtonSetCredentials
            // 
            this.ButtonSetCredentials.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonSetCredentials.FlatAppearance.BorderSize = 0;
            this.ButtonSetCredentials.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ButtonSetCredentials.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.ButtonSetCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSetCredentials.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ButtonSetCredentials.Location = new System.Drawing.Point(485, 17);
            this.ButtonSetCredentials.Name = "ButtonSetCredentials";
            this.ButtonSetCredentials.Size = new System.Drawing.Size(102, 23);
            this.ButtonSetCredentials.TabIndex = 10;
            this.ButtonSetCredentials.Text = "Set C&redentials";
            this.ButtonSetCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonSetCredentials.UseVisualStyleBackColor = true;
            this.ButtonSetCredentials.Visible = false;
            this.ButtonSetCredentials.Click += new System.EventHandler(this.ButtonSetCredentials_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.exportToolStripMenuItem1.Text = "&Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // copyRowToolStripMenuItemProcesses
            // 
            this.copyRowToolStripMenuItemProcesses.Name = "copyRowToolStripMenuItemProcesses";
            this.copyRowToolStripMenuItemProcesses.Size = new System.Drawing.Size(127, 22);
            this.copyRowToolStripMenuItemProcesses.Text = "&Copy Row";
            this.copyRowToolStripMenuItemProcesses.Click += new System.EventHandler(this.copyRowToolStripMenuItemProcesses_Click);
            // 
            // copyRowToolStripMenuItemEvents
            // 
            this.copyRowToolStripMenuItemEvents.Name = "copyRowToolStripMenuItemEvents";
            this.copyRowToolStripMenuItemEvents.Size = new System.Drawing.Size(123, 22);
            this.copyRowToolStripMenuItemEvents.Text = "&Copy Row";
            this.copyRowToolStripMenuItemEvents.Click += new System.EventHandler(this.copyRowToolStripMenuItemEvents_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.ButtonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonStart;
            this.ClientSize = new System.Drawing.Size(856, 596);
            this.ContextMenuStrip = this.contextMenuStripEvents;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxComputer);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(872, 575);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxProcesses.ResumeLayout(false);
            this.contextMenuStripProcesses.ResumeLayout(false);
            this.groupBoxEvents.ResumeLayout(false);
            this.contextMenuStripEvents.ResumeLayout(false);
            this.panelProcessOptions.ResumeLayout(false);
            this.panelProcessOptions.PerformLayout();
            this.panelEventOptions.ResumeLayout(false);
            this.panelEventOptions.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxComputer.ResumeLayout(false);
            this.groupBoxComputer.PerformLayout();
            this.contextMenuStripForm1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox checkBoxExistingProcesses;
        internal System.Windows.Forms.ListView ListViewProcesses;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderName;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderPID;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderUserName;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderCommandLine;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderExecutablePath;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderTerminationDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEvents;
        private System.Windows.Forms.ToolStripMenuItem viewMessageToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProcesses;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForm1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.Button ButtonSetCredentials;
        internal System.Windows.Forms.CheckBox CheckBoxAlternateCredentials;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItemProcesses;
        private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItemEvents;
    }
}

