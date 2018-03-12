using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Monitor
{
    public partial class FormEventView : Form
    {


        public FormEventView()
        {
            InitializeComponent();
        }

        //public string rtf { get; set; }

        public List<Form1.eventData> ListOfEvents;

        public int currentIndex { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEventView_Load(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            this.Text = Application.ProductName + " - Event Details";
            loadRtf();
        }

        private void loadRtf()
        {


            //ListOfEvents[currentIndex].Computer;

            //richTextBox1.Rtf = rtf;
            string rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}}\r\n";
            rtf += @"{\colortbl ;\red0\green77\blue187;\red255\green0\blue0;}";

            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Created", fixForRtf(ListOfEvents[currentIndex].Created));
            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Computer", fixForRtf(ListOfEvents[currentIndex].Computer));
            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Event ID", fixForRtf(ListOfEvents[currentIndex].EventID));
            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Type", fixForRtf(ListOfEvents[currentIndex].Type));
            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Source", fixForRtf(ListOfEvents[currentIndex].Source));
            rtf += String.Format("\\cf1\\b {0}:\\b0\\cf0\\par \r\n{1}\\par \\par \r\n", "Message", fixForRtf(ListOfEvents[currentIndex].Message));


            richTextBox1.Rtf = rtf;

            buttonPrevious.Enabled = true;
            buttonNext.Enabled = true;

            if (currentIndex == 0)
            {
                buttonPrevious.Enabled = false;
            }
            else if (currentIndex == ListOfEvents.Count - 1)
            {
                buttonNext.Enabled = false;
            }
        }

        private string fixForRtf(string txt)
        {
            return txt.Replace("\\", "\\\\").Replace("\n", "\\par ");
        }

        private void FormEventView_ResizeEnd(object sender, EventArgs e)
        {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            //button1.Top = (this.ClientSize.Height - button1.Height) / 2;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Current Index:  {0}", currentIndex);

            if (currentIndex < ListOfEvents.Count-1)
            {
                currentIndex += 1;
                loadRtf();
            }

            Console.WriteLine("New Index:  {0}", currentIndex);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Current Index:  {0}",currentIndex);

            if (currentIndex > 0 )
            {
                currentIndex -= 1;
                loadRtf();
            }

            Console.WriteLine("New Index:  {0}", currentIndex);

            /*
            Program.Main
            string rtfTmp = Form1.getEventRtf(currentIndex);
            
            if (string.IsNullOrEmpty(rtfTmp)) { return; }

            rtf = rtfTmp;
            loadRtf();
            */



        }
    }
}
