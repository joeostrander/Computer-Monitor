using System;
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

namespace Computer_Monitor
{
    public partial class Form1 : Form
    {
        

        string[] logFiles = { "Application","System","Security","DNS Server","File Replication","Directory Service" };
        string[] logTypes = { "Error", "Warning", "Information", "Audit Success", "Audit Failure" };

        private ManagementEventWatcher watcher_events;
        public ManagementScope scope;

        private ListViewColumnSorter lvwColumnSorter = null;
        private bool boolWatchingEvents = false;

        public delegate void AddListViewItemCallback(ListViewItem lvi);


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
                if (checkBoxEvents.Checked)
                {
                    StartWatchingEvents();
                }
                
            } else
            {
                try
                {
                    watcher_events.Stop();
                    boolWatchingEvents = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                EnableControls(true);

            }



        }

        private void StartWatchingEvents()
        {

            if (ListBoxLogFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least 1 log file.",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListBoxLogFiles.Focus();
                return;
            }

            if (ListBoxLogTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select at least 1 log file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListBoxLogTypes.Focus();
                return;
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

            scope = GetScope(boolAddSecurity);
            if (scope == null)
                return;

            EnableControls(false);


            Console.WriteLine(strQuery);
            WqlEventQuery query_created = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), strQuery);

            //Using watcher_created As New ManagementEventWatcher
            watcher_events = new ManagementEventWatcher();

            watcher_events.Scope = scope;
            watcher_events.Query = query_created;
            watcher_events.Options.Timeout = new TimeSpan(1, 0, 0);

            try
            {
                watcher_events.EventArrived += EventArrived;
                watcher_events.Start();
                boolWatchingEvents = true;
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Access is denied.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                EnableControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableControls(true);
            }

        }

        private void EventArrived(object sender, EventArrivedEventArgs e)
        {
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

                //AddListViewItemCallback cb = new AddListViewItemCallback(ListViewAdd);
                if (ListViewEvents.InvokeRequired)
                {
                    ListViewEvents.Invoke(new AddListViewItemCallback(ListViewAdd), lvi);
                    //AddListViewItemCallback cb = ListViewAdd;
                    //cb(lvi);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " " + ex.Message);
            }

        }

        private ManagementScope GetScope(bool boolAddSecurity)
        {
            string strComputer = TextBoxComputer.Text;
            if (string.IsNullOrEmpty(strComputer))
            {
                strComputer = ".";
            }

            ConnectionOptions oConn = new ConnectionOptions();
            if (boolAddSecurity)
            {
                oConn.EnablePrivileges = boolAddSecurity;
            }

            ManagementScope oMs;
            try
            {
                ManagementPath mp = new ManagementPath(@"\\" + strComputer + @"\root\cimv2");
                oMs = new ManagementScope(mp, oConn);
                return oMs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public void ListViewAdd(ListViewItem lvi)
        {
            ListViewEvents.Items.Add(lvi);
            ListViewEvents.Items[ListViewEvents.Items.Count - 1].EnsureVisible();
            ColorLines();
        }

        public void ColorLines()
        {
            int count = 0;
            foreach (ListViewItem line in ListViewEvents.Items)
            {
                count += 1;
                if (count % 2 ==0)
                {
                    line.BackColor = Color.WhiteSmoke;
                } else
                {
                    line.BackColor = Color.White;
                }
                line.ForeColor = Color.Black;
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
    }

    


}
