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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TextBoxUsername.Text = Form1.strUsername;
            TextBoxPassword.Text = Form1.strPassword;



        }

        private void SaveCredentials()
        {


            if (string.IsNullOrEmpty(TextBoxUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBoxUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBoxPassword.Focus();
                return;
            }

            Form1.strUsername = TextBoxUsername.Text;
            Form1.strPassword = TextBoxPassword.Text;

            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveCredentials();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can enter your name like:\n\nusername@domain.com\nor\nDOMAIN\\username", "Setting the Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TextBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                SaveCredentials();
            }
        }
    }
}
