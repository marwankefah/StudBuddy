using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class changepassword : Form
    {
        int back;
        public static int showpass = 0;
        private int privillege;
        private string ownerusername;
        Controller controllerobj=new Controller();

        public changepassword(string username,int priv)
        {
            InitializeComponent();
            ownerusername = username;
            privillege = priv;
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (showpass == 0)
            {
                textBox1.UseSystemPasswordChar = false;
                showpass = 1;
            }
            else if (showpass == 1)
            {
                textBox1.UseSystemPasswordChar = true;
                showpass = 0;
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
           // changepassword(ownerusername, privillege);
            if (textBox1.Text != "")    //check for FNAME
            {
                int pass1=controllerobj.changepassword(ownerusername, privillege, textBox1.Text);
                MessageBox.Show("password is changed"); 
            }
            else if (textBox1.Text == "")
            {
                object name = controllerobj.getfname(ownerusername, privillege);
                controllerobj.changepassword(ownerusername, privillege, Convert.ToString(textBox1.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }
    }
}
