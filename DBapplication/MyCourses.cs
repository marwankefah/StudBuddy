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
    public partial class MyCourses : Form
    {
        int back;
       
        private int privillege;
        private string ownerusername;
        Controller controllerobj;

        public MyCourses(string username, int priv)
        {
           
            back = 0;
            ownerusername = username;
            privillege = priv;
            InitializeComponent();
            controllerobj = new Controller();
            updateCOURSES();
        }

        public void updateCOURSES()
        {
                listBox1.Show();
                DataTable dt = null;

                if (privillege == 2)
                {
                    dt = controllerobj.selectcourses_withpriv(ownerusername,2);
                }
                else if (privillege == 3)
                {
                    dt = controllerobj.selectcourses_withpriv(ownerusername,3);
                }
               

                if (dt == null)
                {
                    label1.Text = "NO COURSES REGISTERED";
                }
                else
                { 
                    listBox1.DisplayMember = "course name";
                listBox1.ValueMember = "Course-ID";
                listBox1.DataSource = dt;
                    label1.Text = "MY COURSES :";
                }
                listBox1.Refresh();
            }
              
        private void BACK_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }

        private void MyCourses_Load(object sender, EventArgs e)
        {

        }

        private void MyCourses_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (back == 1)
            {

                back = 0;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Owner.Close();
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            new Add_coursesT(ownerusername, privillege).Show(this);
            this.Hide();    
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
           new Delete_coursesT(ownerusername, privillege).Show(this);
           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCOURSES();
        }

    }
}
