﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using ListViewSorter;
using System.Diagnostics;

namespace Computer_Monitor
{
    public partial class Form1 : Form
    {
        

        /*
         * TO DO:
         * background worker to get existing processes
         * Event icons?
         * 
         */


        string[] logFiles = { "Application","System","Security","DNS Server","File Replication","Directory Service" };
        string[] logTypes = { "Error", "Warning", "Information", "Audit Success", "Audit Failure" };

        private ManagementEventWatcher watcher_events;
        private ManagementEventWatcher watcher_process_created;
        private ManagementEventWatcher watcher_process_deleted;
        public ManagementScope scope;

        private ListViewColumnSorter lvwColumnSorter = null;
        private bool boolWatchingEvents = false;
        private bool boolWatchingProcesses = false;
        private int intProcessCount = 0;
        private bool boolClosing = false;
        private bool boolFailure = false;

        public static string strUsername;
        public static string strPassword;

        public struct MyProcess
        {
            public string ID;
            public string Name;
            public string Owner;
            public string ExecutablePath;
            public string CommandLine;
            public string CreationDate;
            public string TerminationDate;
        }

        public struct eventData
        {
            public string Created;
            public string Computer;
            public string EventID;
            public string Type;
            public string Source;
            public string Message;
        }

        public delegate void AddListViewItemCallback(ListView lv,ListViewItem lvi);
        public delegate void DeleteListViewItemCallback(ListView lv, int columnIndex, string value);
        public delegate void ProcessTerminatedCallback(MyProcess proc);


        public Form1()
        {
            InitializeComponent();
        }

        private void checkBoxProcesses_CheckedChanged(object sender, EventArgs e)
        {
            adjustControls();
        }

        private void checkBoxEvents_CheckedChanged(object sender, EventArgs e)
        {
            adjustControls();
        }

        private void adjustControls()
        {
            splitContainer1.Panel1Collapsed = !checkBoxProcesses.Checked;
            splitContainer1.Panel2Collapsed = !checkBoxEvents.Checked;

            panelProcessOptions.Visible = checkBoxProcesses.Checked;
            panelEventOptions.Visible = checkBoxEvents.Checked;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            toolStripStatusLabel1.Text = "";

            ListBoxLogFiles.Items.AddRange(logFiles);
            ListBoxLogFiles.SetSelected(0, true);
            ListBoxLogTypes.Items.AddRange(logTypes);
            ListBoxLogTypes.SetSelected(0, true);
            ListBoxLogTypes.SetSelected(1, true);
            ListBoxLogTypes.SetSelected(2, true);

            lvwColumnSorter = new ListViewColumnSorter();
            ListViewEvents.ListViewItemSorter = lvwColumnSorter;
            ListViewEvents.Sorting = System.Windows.Forms.SortOrder.Ascending;
            ListViewEvents.AutoArrange = true;
             
            lvwColumnSorter._SortModifier = ListViewColumnSorter.SortModifiers.SortByText;

            
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            SplitContainer s = sender as SplitContainer;
            e.Graphics.FillRectangle(Brushes.LightGray, s.SplitterRectangle);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (ButtonStart.Text=="&Start")
            {
                ListViewEvents.Items.Clear();
                ListViewProcesses.Items.Clear();
                boolFailure = false;

                if (checkBoxProcesses.Checked && checkBoxExistingProcesses.Checked)
                {
                    EnableControls(false);
                    toolStripStatusLabel1.Text = "Gathering existing processes...";
                    List<MyProcess> procs = GetProcesses();
                    toolStripStatusLabel1.Text = "";
                    if (procs.Count == 0)
                    {
                        Console.WriteLine("NO PROCESSES IN LIST!");
                        EnableControls(true);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("PROCESSES:  {0}",procs.Count);
                    }
                    //Add all to listview
                    foreach (MyProcess proc in procs)
                    {
                        Console.WriteLine(proc.ID);

                        ListViewItem lvi = new ListViewItem(proc.CreationDate);
                        lvi.SubItems.Add(proc.TerminationDate);
                        lvi.SubItems.Add(proc.Name);
                        lvi.SubItems.Add(proc.ID);
                        lvi.SubItems.Add(proc.Owner);
                        lvi.SubItems.Add(proc.CommandLine);
                        lvi.SubItems.Add(proc.ExecutablePath);

                        //toolStripStatusLabel1.Text = "Processes:  " + intProcessCount;

                        if (ListViewProcesses.InvokeRequired)
                        {
                            ListViewProcesses.Invoke(new AddListViewItemCallback(ListViewAdd), new object[] { ListViewProcesses, lvi });
                        }
                        else
                        {
                            ListViewAdd(ListViewProcesses, lvi);

                        }
                    }
                        
                }

                if (checkBoxEvents.Checked)
                {
                    boolWatchingEvents = StartWatchingEvents();
                }

                if (boolFailure)
                    return;

                if (checkBoxProcesses.Checked)
                {
                    boolWatchingProcesses = StartWatchingProcesses();
                }


                if (boolFailure) {
                    EnableControls(true);
                    return;
                }
                    

                if (boolWatchingEvents||boolWatchingProcesses)
                {
                    EnableControls(false);
                }

            } else
            {
                try
                {
                    if (boolWatchingEvents)
                    {
                        watcher_events.Stop();
                    }
                        
                    if (boolWatchingProcesses)
                    {
                        watcher_process_created.Stop();
                        watcher_process_deleted.Stop();
                    }
                    
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Do nothing...
                }

                boolWatchingEvents = false;
                boolWatchingProcesses = false;
                EnableControls(true);

            }



        }

        private List<MyProcess> GetProcesses()
        {
            List<MyProcess> listProcs = new List<MyProcess>();
            List<string> listProcID = new List<string>();


            string strComputer = TextBoxComputer.Text;
            ManagementObjectCollection colProcesses;

            try
            {
                colProcesses = GetCollection("select * from Win32_Process");
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Access is denied.\n\n"+uex.Message, "Get Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return listProcs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return listProcs;
            }

            if (colProcesses == null)
            {
                return listProcs;
            }

            intProcessCount = 0;
            foreach (ManagementObject objProcess in colProcesses)
            {
                if (colProcesses == null) {
                    break;
                }
                intProcessCount += 1;

                string strName = "";
                string strProcessID = " ";
                string strExecutablePath = " ";
                string strCommandLine = " ";
                string strOwner = " ";
                string strCreationDate = "";
                string strTerminationDate = "";
                string dmtfDate = "";
                string dmtfDateTerminated = "";

                foreach (PropertyData prop in objProcess.Properties)
                {
                    switch (prop.Name.ToLower())
                    {
                        case "name":
                            strName = (string)prop.Value;
                            break;
                        case "creationdate":
                            dmtfDate = (string)prop.Value;
                            if (!string.IsNullOrEmpty(dmtfDate))
                            {
                                DateTime dtmCreationDate = ManagementDateTimeConverter.ToDateTime(dmtfDate);
                                strCreationDate = dtmCreationDate.ToString();
                            }
                            break;
                        case "terminationdate":
                            dmtfDateTerminated = (string)prop.Value;
                            if (!string.IsNullOrEmpty(dmtfDateTerminated))
                            {
                                DateTime dtmTerminationDate = ManagementDateTimeConverter.ToDateTime(dmtfDateTerminated);
                                strTerminationDate = dtmTerminationDate.ToString();
                            }
                            break;
                        case "processid":
                            strProcessID = (string)prop.Value.ToString();
                            break;
                        case "executablepath":
                            strExecutablePath = (string)prop.Value;
                            break;
                        case "commandline":
                            strCommandLine = (string)prop.Value;
                            break;
                            
                    }
                }


                strOwner = GetProcessOwnerByRef(objProcess);

                if (!listProcID.Contains(strProcessID))
                {
                    listProcID.Add(strProcessID);
                }

                MyProcess proc = new MyProcess();
                proc.ID = strProcessID;
                proc.Name = strName;
                proc.Owner = strOwner;
                proc.CommandLine = strCommandLine;
                proc.ExecutablePath = strExecutablePath;
                proc.CreationDate = strCreationDate;
                proc.TerminationDate = strTerminationDate;
                listProcs.Add(proc);

            }


                return listProcs;

        }


        public bool IsNumeric(String s)
        {
            return s.All(Char.IsDigit);
        }

        private string GetProcessOwnerByRef(ManagementObject objProcess)
        {
            string strOwner = "";
            string[] methodArgs = { "", "" };
            string strNameOfUser = "";
            string strDomain = "";

            try
            {
                objProcess.InvokeMethod("GetOwner", methodArgs);
                strNameOfUser = methodArgs[0];
                strDomain = methodArgs[1];
            }
            catch (Exception ex)
            {
                //Do nothing
            }

            if (!string.IsNullOrEmpty(strNameOfUser))
            {
                if (string.IsNullOrEmpty(strDomain))
                {
                    strOwner = strNameOfUser;
                }
                else
                {
                    strOwner = strDomain + "\\" + strNameOfUser;
                }
            } 
            else
            {
                strOwner = "";
            }

            return string.IsNullOrEmpty(strOwner) ? " " : strOwner;
        }

        private bool StartWatchingProcesses()
        {
            Console.WriteLine("StartWatchingProcesses...");
            watcher_process_created = new ManagementEventWatcher();
            watcher_process_deleted = new ManagementEventWatcher();
            scope = GetScope();
            if (scope == null)
                return false;

            bool boolSuccess = false;

            try
            {
                if (!scope.IsConnected)
                {
                    scope.Connect();
                }
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Access is denied.", Application.ProductName + " Watch Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, Application.ProductName + " Watch Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (scope.IsConnected) {

                if (checkBoxMonitorProcessAdditions.Checked)
                {
                    string strQueryCreated = "TargetInstance isa \"Win32_Process\"";
                    WqlEventQuery query_created = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), strQueryCreated);

                    watcher_process_created.Scope = scope;
                    watcher_process_created.Query = query_created;
                    watcher_process_created.Options.Timeout = new TimeSpan(1, 0, 0);

                    try
                    {
                        watcher_process_created.EventArrived += CreatedArrived;
                        watcher_process_created.Start();
                        boolSuccess = true;
                    }
                    catch (UnauthorizedAccessException uex)
                    {
                        Console.WriteLine("StartWatchingProcesses() - UnauthorizedAccessException - " + uex.Message);
                        MessageBox.Show("Access is denied.", Application.ProductName + " - Start Watching Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        boolSuccess = false;
                        boolFailure = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("StartWatchingProcesses() - Exception - " + ex.Message);
                        MessageBox.Show(ex.Message, Application.ProductName + " - Start Watching Processes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        boolSuccess = false;
                        boolFailure = true;
                    }
                }

                if (checkBoxMonitorProcessDeletions.Checked)
                {
                    string strQueryDeleted = "TargetInstance isa \"Win32_Process\"";
                    WqlEventQuery query_deleted = new WqlEventQuery("__InstanceDeletionEvent", new TimeSpan(0, 0, 1), strQueryDeleted);

                    watcher_process_deleted.Scope = scope;
                    watcher_process_deleted.Query = query_deleted;
                    watcher_process_deleted.Options.Timeout = new TimeSpan(1, 0, 0);

                    try
                    {
                        watcher_process_deleted.EventArrived += DeletedArrived;
                        watcher_process_deleted.Start();
                        boolSuccess = true;
                    }
                    catch (UnauthorizedAccessException uex)
                    {
                        Console.WriteLine("StartWatchingProcesses() - UnauthorizedAccessException - " + uex.Message);
                        MessageBox.Show("Access is denied.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        boolSuccess = false;
                        boolFailure = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("StartWatchingProcesses() - Exception - " + ex.Message);
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        boolSuccess = false;
                        boolFailure = true;
                    }
                }
            }



            return boolSuccess;
        }

        private void DeletedArrived(object sender, EventArrivedEventArgs e)
        {
            if (boolClosing)
                return;

            if (!boolWatchingProcesses)
                return;

            MyProcess proc = new MyProcess();
            ManagementBaseObject evt = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                    

            
            DateTime dtmTerminationDate = DateTime.Now;
            string strTerminationDate = dtmTerminationDate.ToString();
            proc.TerminationDate = strTerminationDate;

            foreach (PropertyData prop in evt.Properties)
            {
                switch (prop.Name.ToLower())
                {
                    case "processid":
                        proc.ID = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "name":
                        proc.Name = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "creationdate":
                        string dmtfDateCreated = prop.Value == null ? "" : prop.Value.ToString();
                        if (!string.IsNullOrEmpty(dmtfDateCreated))
                        {
                            DateTime dtmCreationDate = ManagementDateTimeConverter.ToDateTime(dmtfDateCreated);
                            proc.CreationDate = dtmCreationDate.ToString();
                        }
                        break;
                    case "owner":
                        if (string.IsNullOrEmpty(proc.ID))
                        {
                            proc.Owner = GetProcessOwner(proc.ID);
                        }
                        break;
                    case "commandline":
                        proc.CommandLine = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "executablepath":
                        proc.ExecutablePath = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "terminationdate":
                        //skip... use DateTime.Now
                        break;
                }

            }



            
            if (!string.IsNullOrEmpty(strTerminationDate)&& !string.IsNullOrEmpty(proc.ID))
            {
                if (ListViewProcesses.InvokeRequired)
                {
                    //ListViewProcesses.Invoke(new DeleteListViewItemCallback(ListViewDelete), new object[] { ListViewProcesses, pidColumn, PID });
                    //ListViewProcesses.Invoke(new ProcessTerminatedCallback(ListViewProcessTerminate), new object[] { proc.ID, proc.TerminationDate});
                    ListViewProcesses.Invoke(new ProcessTerminatedCallback(ListViewProcessTerminate), proc);

                }
            }



        }

        private void CreatedArrived(object sender, EventArrivedEventArgs e)
        {
            if (boolClosing)
                return;

            if (!boolWatchingProcesses)
                return;

            string strCreationDate = "";
            string dmtfDateCreated = "";
            string strName = "";
            string PID = "";
            string strExecutablePath = "";
            string strCommandLine = "";

            ManagementBaseObject evt = (ManagementBaseObject)e.NewEvent["TargetInstance"];


            foreach (PropertyData prop in evt.Properties)
            {
                switch (prop.Name.ToLower())
                {
                    case "creationdate":
                        dmtfDateCreated = prop.Value == null ? "" : prop.Value.ToString();
                        if (!string.IsNullOrEmpty(dmtfDateCreated))
                        {
                            DateTime dtmCreationDate = ManagementDateTimeConverter.ToDateTime(dmtfDateCreated);
                            strCreationDate = dtmCreationDate.ToString();
                        }
                        break;
                    case "name":
                        strName = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "processid":
                        PID = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "executablepath":
                        strExecutablePath = prop.Value == null ? "" : prop.Value.ToString();
                        break;
                    case "commandline":
                        strCommandLine = prop.Value==null ? "" : prop.Value.ToString();
                        break;
                }

            }




            ListViewItem lvi = new ListViewItem(strCreationDate);
            lvi.SubItems.Add("");
            lvi.SubItems.Add(strName);
            lvi.SubItems.Add(PID);
            string strOwner = GetProcessOwner(PID);
            lvi.SubItems.Add(strOwner);
            lvi.SubItems.Add(strCommandLine);
            lvi.SubItems.Add(strExecutablePath);

            intProcessCount += 1;

            if (ListViewProcesses.InvokeRequired)
            {
                ListViewProcesses.Invoke(new AddListViewItemCallback(ListViewAdd),new object[] { ListViewProcesses, lvi});
            }
            else
            {
                ListViewAdd(ListViewProcesses, lvi);
            }

        }

        private string GetProcessOwner(string strProcessID)
        {
            string strOwner = "";
            ManagementObjectCollection colProcesses = GetCollection("select * from Win32_Process where ProcessID='" + strProcessID + "'");
            if (colProcesses==null)
            {
                return "";
            }

            foreach (ManagementObject objProcess in colProcesses)
            {
                string[] methodArgs = { "", "" };
                string strNameOfUser = "";
                string strDomain = "";

                try
                {
                    objProcess.InvokeMethod("GetOwner", methodArgs);
                    strNameOfUser = methodArgs[0];
                    strDomain = methodArgs[1];
                }
                catch (Exception ex)
                {
                    //Do nothing
                }

                if (!string.IsNullOrEmpty(strNameOfUser))
                {
                    if (string.IsNullOrEmpty(strDomain))
                    {
                        strOwner = strNameOfUser;
                    }
                    else
                    {
                        strOwner = strDomain + "\\" + strNameOfUser;
                    }
                }
                else
                {
                    strOwner = "";
                }

            }


            return strOwner;
        }

        private ManagementObjectCollection GetCollection(string strQuery)
        {
            bool boolAddSecurity = false;
            scope = GetScope();
            if (scope == null)
                return null;


            try
            {
                if (!scope.IsConnected)
                {
                    scope.Connect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCollection - scope connect "+ex.Message);
            }

            if (scope.IsConnected)
            {
                try
                {
                    SelectQuery oQuery = new SelectQuery(string.Format(strQuery));
                    ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(scope, oQuery);
                    ManagementObjectCollection colTemp = oSearcher.Get();

                    return colTemp;
                }
                catch (System.UnauthorizedAccessException unauth)
                {
                    Console.WriteLine("GetCollection - oSearcher.Get " + unauth.Message);
                    MessageBox.Show("Access is denied.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                catch (Exception ex)
                {
                    //no msg
                    return null;
                }
            }
            else
            {
                return null;
            }

            

        }


        private void ListViewProcessTerminate(MyProcess proc)
        {
            int columnIndexPid = GetColumnIndex(ListViewProcesses, "PID");
            int columnIndexTerminated = GetColumnIndex(ListViewProcesses, "Terminated");
            bool boolFound = false;
                
            foreach (ListViewItem lvi in ListViewProcesses.Items)
            {

                if (lvi.SubItems[columnIndexPid].Text == proc.ID)
                {
                    boolFound = true;
                    lvi.ForeColor = Color.Red;
                    lvi.SubItems[columnIndexTerminated].Text = proc.TerminationDate;
                    if (lvi.Index > 0)
                    {
                        int index = ListViewProcesses.Items.Count - 1;
                        ListViewProcesses.Items.RemoveAt(lvi.Index);
                        ListViewProcesses.Items.Insert(index, lvi);
                    }
                    break;
                }
                
            }

            if (!boolFound)
            {
                //TO DO...
                //not found... can't move... create new

                ListViewItem lvi = new ListViewItem(proc.CreationDate);
                lvi.SubItems.Add(proc.TerminationDate);
                if (!string.IsNullOrEmpty(proc.TerminationDate))
                {
                    lvi.ForeColor = Color.Red;
                }
                lvi.SubItems.Add(proc.Name);
                lvi.SubItems.Add(proc.ID);
                lvi.SubItems.Add(proc.Owner);
                lvi.SubItems.Add(proc.CommandLine);
                lvi.SubItems.Add(proc.ExecutablePath);

                if (ListViewProcesses.InvokeRequired)
                {
                    ListViewProcesses.Invoke(new AddListViewItemCallback(ListViewAdd), new object[] { ListViewProcesses, lvi });
                }
                else
                {
                    ListViewAdd(ListViewProcesses, lvi);
                }

            }


            ColorLines(ListViewProcesses);
            ScrollListView(ListViewProcesses);
        }

        private void ListViewDelete(ListView lv, int columnIndex, string value)
        {
            foreach (ListViewItem lvi in lv.Items)
            {

                if (lvi.SubItems[columnIndex].Text == value)
                {
                    lvi.Remove();
                    break;
                }
            }

            //lv.Items.Remove(lvi);
            //lv.Items[lv.Items.Count - 1].EnsureVisible();
            ColorLines(lv);
        }

        private int GetColumnIndex(ListView lvi,string strColumnTitle)
        {
            foreach(ColumnHeader col in lvi.Columns)
            {
                if (col.Text == strColumnTitle)
                {
                    return col.Index;
                }
            }
            return 9999;
        }

        private bool StartWatchingEvents()
        {
            Console.WriteLine("StartWatchingEvents...");
            if (ListBoxLogFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least 1 log file.",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListBoxLogFiles.Focus();
                return false;
            }

            if (ListBoxLogTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least 1 log file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListBoxLogTypes.Focus();
                return false;
            }

            bool boolAddSecurity = false;
            string strQuery = "TargetInstance isa 'Win32_NTLogEvent'";
            string strCheckLogFile = "";
            foreach (string opt in ListBoxLogFiles.SelectedItems)
            {
                if (string.IsNullOrEmpty(strCheckLogFile))
                {
                    strCheckLogFile = " TargetInstance.LogFile='" + opt + "'";
                }
                else
                {
                    strCheckLogFile += " OR TargetInstance.LogFile='" + opt + "'";
                }
                if (opt == "Security")
                    boolAddSecurity = true;
            }
            if (!string.IsNullOrEmpty(strCheckLogFile))
            {
                strQuery += " AND (" + strCheckLogFile + ")";
            }

            string strCheckLogType = "";
            foreach (string opt in ListBoxLogTypes.SelectedItems)
            {
                if (string.IsNullOrEmpty(strCheckLogType))
                {
                    strCheckLogType = " TargetInstance.Type='" + opt + "'";
                }
                else
                {
                    strCheckLogType += " OR TargetInstance.Type='" + opt + "'";
                }
            }
            if (!string.IsNullOrEmpty(strCheckLogType))
            {
                strQuery += " AND (" + strCheckLogType + ")";
            }

            scope = GetScope();
            if (scope == null)
                return false;

            Console.WriteLine("Got scope...");

            try
            {
                if (!scope.IsConnected)
                {
                    Console.WriteLine("Scope connect...");
                    scope.Connect();
                }
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Access is denied.", Application.ProductName + " Watch Events", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                boolFailure = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("scope connect failed..."+ex.Message);
                MessageBox.Show(ex.Message, Application.ProductName + " Watch Events", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                boolFailure = true;
            }

            if (scope.IsConnected)
            {
                Console.WriteLine("Scope is connected...");
                Console.WriteLine(strQuery);
                WqlEventQuery query_created = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), strQuery);

                //Using watcher_created As New ManagementEventWatcher
                watcher_events = new ManagementEventWatcher();

                watcher_events.Scope = scope;
                watcher_events.Query = query_created;
                watcher_events.Options.Timeout = new TimeSpan(1, 0, 0);

                try
                {
                    Console.WriteLine("ONE");
                    watcher_events.EventArrived += EventArrived;
                    Console.WriteLine("TWO");
                    watcher_events.Start();
                    Console.WriteLine("THREE");
                    return true;
                }
                catch (UnauthorizedAccessException uex)
                {
                    Console.WriteLine(uex.Message);
                    MessageBox.Show("Access is denied.", Application.ProductName + " - Start Watching Events", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    boolFailure = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName + " - Start Watching Events", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    boolFailure = true;
                }
            }


            return false;
        }

        private void EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (boolClosing)
                return;

            if (!boolWatchingEvents)
                return;

            try
            {
                ManagementBaseObject evt = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                string strTimeGenerated = "";
                string dmtfDate = evt["TimeGenerated"].ToString();
                if (!string.IsNullOrEmpty(dmtfDate))
                {
                    DateTime dtmTimeGenerated = ManagementDateTimeConverter.ToDateTime(dmtfDate);
                    strTimeGenerated = dtmTimeGenerated.ToString();
                }
                
                string sComputer = evt["ComputerName"].ToString();
                string sEventID = evt["EventCode"].ToString();
                string sType = evt["Type"].ToString();
                string sMessage = evt["Message"].ToString();
                string sSource = evt["SourceName"].ToString();
                

                ListViewItem lvi = new ListViewItem(strTimeGenerated);
                lvi.SubItems.Add(sComputer);
                lvi.SubItems.Add(sEventID);
                lvi.SubItems.Add(sType);
                lvi.SubItems.Add(sSource);
                lvi.SubItems.Add(sMessage);

                if (ListViewEvents.InvokeRequired)
                {
                    ListViewEvents.Invoke(new AddListViewItemCallback(ListViewAdd), new object[] { ListViewEvents, lvi });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " " + ex.Message);
            }

        }

        private ManagementScope GetScope()
        {
            string strComputer = TextBoxComputer.Text;
            if (string.IsNullOrEmpty(strComputer))
            {
                strComputer = ".";
            }

            ConnectionOptions oConn = new ConnectionOptions();
            if (CheckBoxAlternateCredentials.Checked && strComputer!="")
            {
                oConn.Username = strUsername;
                oConn.Password = strPassword;
                oConn.Impersonation = ImpersonationLevel.Impersonate;
            }
            //oConn.EnablePrivileges = true;
            //oConn.Timeout = new TimeSpan(0, 5, 0);

            ManagementScope oMs;
            try
            {
                ManagementPath mp = new ManagementPath(@"\\" + strComputer + @"\root\cimv2");
                oMs = new ManagementScope(mp, oConn);
                return oMs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetScope - \n\n"+ex.Source + "\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        private void EnableControls(bool boolEnable)
        {
            TextBoxComputer.Enabled = boolEnable;
            ListBoxLogFiles.Enabled = boolEnable;
            ListBoxLogTypes.Enabled = boolEnable;
            groupBoxOptions.Enabled = boolEnable;
            TextBoxComputer.Enabled = boolEnable;
            ListBoxLogFiles.Enabled = boolEnable;
            ListBoxLogTypes.Enabled = boolEnable;

            if (boolEnable)
            {
                ButtonStart.Text = "&Start";
            } else
            {
                ButtonStart.Text = "&Stop";
            }
            

        }

        public void ListViewAdd(ListView lv,ListViewItem lvi)
        {
            lv.Items.Add(lvi);
            lv.Items[lv.Items.Count - 1].EnsureVisible();
            ColorLines(lv);
            ScrollListView(lv);


        }

        public void ScrollListView(ListView lv)
        {
            if (lv.Items.Count > 1)
            {
                lv.TopItem = lv.Items[lv.Items.Count - 1];
            }
        }

        public void ColorLines(ListView listView)
        {
            int count = 0;
            foreach (ListViewItem line in listView.Items)
            {
                count += 1;
                if (count % 2 ==0)
                {
                    line.BackColor = Color.WhiteSmoke;
                } else
                {
                    line.BackColor = Color.White;
                }
                //line.ForeColor = Color.Black;
            }
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.ColumnToSort)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.ColumnToSort = e.Column;
                lvwColumnSorter.OrderOfSort = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (boolWatchingEvents)
            watcher_events.Stop();

            if (boolWatchingProcesses)
            {
                watcher_process_created.Stop();
                watcher_process_deleted.Stop();
            }

            boolClosing = true;
        }

        private void viewMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewEvent();

        }

        private void ListViewEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            viewEvent();
        }

        private void viewEvent()
        {
            int intSelectedIndex = ListViewEvents.SelectedIndices[0];

            List<eventData> tmpList = new List<eventData>();
            foreach (ListViewItem lvi in ListViewEvents.Items)
            {
                eventData evt = new eventData();
                               
                evt.Created = lvi.SubItems[GetColumnIndex(ListViewEvents, "Created")].Text;
                evt.Computer = lvi.SubItems[GetColumnIndex(ListViewEvents, "Computer")].Text;
                evt.EventID = lvi.SubItems[GetColumnIndex(ListViewEvents, "Event ID")].Text;
                evt.Type = lvi.SubItems[GetColumnIndex(ListViewEvents, "Type")].Text;
                evt.Source = lvi.SubItems[GetColumnIndex(ListViewEvents, "Source")].Text;
                evt.Message = lvi.SubItems[GetColumnIndex(ListViewEvents, "Message")].Text;
                tmpList.Add(evt);
            }

            FormEventView frmEvt = new FormEventView();
            frmEvt.currentIndex = intSelectedIndex;
            frmEvt.ListOfEvents = tmpList;
            frmEvt.ShowDialog();
                       

        }

        

        private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int intSelectedIndex = ListViewProcesses.SelectedIndices[0];
            int colIndexPID = GetColumnIndex(ListViewProcesses, "PID");
            int colIndexName = GetColumnIndex(ListViewProcesses, "Name");

            string PID = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexPID].Text;
            string procName = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexName].Text;

            DialogResult result = MessageBox.Show("Terminate process:  " + procName + " [" + PID + "]", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                KillProcess(PID);
            }
            else
            {
                MessageBox.Show("Cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //ListViewProcesses.Items[intSelectedIndex].SubItems[col.Index].Text

        }

        private void KillProcess(string pID)
        {
            ManagementObjectCollection colProcesses = GetCollection("select * from Win32_Process where ProcessId='" + pID + "'");
            if (colProcesses.Count==0)
            {
                return;
            }
            foreach(ManagementObject objProcess in colProcesses)
            {
                UInt32 ret = (UInt32)objProcess.InvokeMethod("Terminate", null);
                
                Console.WriteLine("returned:  {0}", ret);
                
                string message = "Unknown result...";
                switch (ret)
                {
                    case 0:
                        message = "Successfully terminated process ID:  " + pID;
                        break;
                    case 2:
                        message = "Access denied";
                        break;
                    case 3:
                        message = "Insufficient privilege";
                        break;
                    case 8:
                        message = "Unknown failure";
                        break;
                    case 9:
                        message = "Path not found";
                        break;
                    case 21:
                        message = "Invalid Parameter";
                        break;
                }

                string finalMessage = ret == 0 ? message : "Failed to terminate process ID:  " + pID + "\r\n\r\n" + message;
                MessageBoxIcon icon = ret == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation;
                MessageBox.Show(finalMessage, Application.ProductName, MessageBoxButtons.OK, icon);
            }

        }

        private void contextMenuStripEvents_Opening(object sender, CancelEventArgs e)
        {
            if (ListViewEvents.SelectedIndices.Count == 0) 
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStripProcesses_Opening(object sender, CancelEventArgs e)
        {
            terminateToolStripMenuItem.Visible = true;
            showInExplorerToolStripMenuItem.Visible = true;

            if (ListViewProcesses.SelectedIndices.Count == 0)
            {
                e.Cancel = true;
            }
            else
            {

                int intSelectedIndex = ListViewProcesses.SelectedIndices[0];
                int colIndexPID = GetColumnIndex(ListViewProcesses, "PID");
                int colIndexName = GetColumnIndex(ListViewProcesses, "Name");
                int colIndexTerminated = GetColumnIndex(ListViewProcesses, "Terminated");
                int colIndexExecutablePath = GetColumnIndex(ListViewProcesses, "Executable Path");
                string PID = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexPID].Text;
                string procName = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexName].Text;
                string terminated = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexTerminated].Text;
                string executablePath = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexExecutablePath].Text;

                //if the process is terminated... cancel
                if (!string.IsNullOrEmpty(terminated))
                {
                    //e.Cancel = true;
                    terminateToolStripMenuItem.Visible = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(procName) || string.IsNullOrEmpty(PID) || PID=="0" || procName=="System")
                    {
                        //e.Cancel = true;
                        terminateToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        terminateToolStripMenuItem.Text = "&Terminate process:  " + procName + " [" + PID + "]";
                    }
                }

                if (string.IsNullOrEmpty(executablePath))
                {
                    showInExplorerToolStripMenuItem.Visible = false;
                }


            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            TextBoxComputer.Focus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void CheckBoxAlternateCredentials_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAlternateCredentials.Checked) {
                ButtonSetCredentials.Visible = true;
            } else {
                ButtonSetCredentials.Visible = false;
            }
        }

        private void ButtonSetCredentials_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.ShowDialog();


        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSV_Export.ExportToCSV(ListViewProcesses);
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CSV_Export.ExportToCSV(ListViewEvents);
        }

        private void copyRowToolStripMenuItemEvents_Click(object sender, EventArgs e)
        {
            copyRow(ListViewEvents);
        }

        private void copyRowToolStripMenuItemProcesses_Click(object sender, EventArgs e)
        {
            copyRow(ListViewProcesses);
        }

        private void copyRow(ListView view)
        {
            int intSelectedIndex = view.SelectedIndices[0];
            ListViewItem lvi = view.Items[intSelectedIndex];

            string copyText = "";
            int idx = 0;
            foreach (ListViewItem.ListViewSubItem subItem in lvi.SubItems)
            {
                
                copyText += view.Columns[idx].Text + ":\r\n";
                copyText += subItem.Text + "\r\n\r\n";
                idx += 1;
            }
            Clipboard.SetText(copyText);
        }

        private void showInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int intSelectedIndex = ListViewProcesses.SelectedIndices[0];
            ListViewItem lvi = ListViewProcesses.Items[intSelectedIndex];

            int colIndexExecutablePath = GetColumnIndex(ListViewProcesses, "Executable Path");
            string executablePath = ListViewProcesses.Items[intSelectedIndex].SubItems[colIndexExecutablePath].Text;

            if (string.IsNullOrEmpty(executablePath))
                return;

            string strComputer = TextBoxComputer.Text;
            if (!string.IsNullOrEmpty(strComputer))
            {
                executablePath = @"\\" + strComputer + @"\" + executablePath.Replace(':', '$');
            }

            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo("explorer.exe", "/e,/select,\"" + executablePath + "\"");
            proc.Start();


        }
    }



}
