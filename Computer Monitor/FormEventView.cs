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

        public string rtf { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEventView_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = rtf;
            richTextBox1.BackColor = Color.White;
            this.Text = Application.ProductName + " - Event Details";
        }

        private void FormEventView_ResizeEnd(object sender, EventArgs e)
        {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            //button1.Top = (this.ClientSize.Height - button1.Height) / 2;
        }
    }
}
