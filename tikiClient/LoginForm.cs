using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tikiClient
{
    public partial class LoginForm : Form
    {
        

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                txtUsername.BackColor = Color.Red;
                txtUsername.Text = "Username cannot be blank!";
                //MessageBox.Show("Test");
                //txtUsername.Update();
            }if(txtPassword.Text == "")
            {
                txtPassword.BackColor = Color.Red;
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "Password cannot be blank!";
            }else if(txtUsername.Text != "" && txtPassword.Text != "")
            {
                timerServerPoll.Start();
                System.Threading.Thread netThread = new System.Threading.Thread(()=>netHandler.connect(txtUsername.Text,txtPassword.Text));
                netThread.Start();
              //  netHandler.connect(txtUsername.Text, txtPassword.Text);
            }

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "Username cannot be blank!")
            {
                txtUsername.Text = "";
                txtUsername.BackColor = SystemColors.Window;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password cannot be blank!")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.BackColor = SystemColors.Window;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password cannot be blank!")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.BackColor = SystemColors.Window;
            }
        }

        private void timerServerPoll_Tick(object sender, EventArgs e)
        {
            if (netHandler.loggedIn)
            {
                MessageBox.Show("You have been logged in!");
            }
            if(netHandler.errorMsg != "")
            {
                MessageBox.Show(netHandler.errorMsg);
            }
        }
    }
}
