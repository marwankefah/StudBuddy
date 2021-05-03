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
    public partial class Delete_coursesT : Form
    {
       
        Controller controllerobj;
        private int privillege;
        private string ownerusername;

        public Delete_coursesT(string username, int priv)
        {
             
            ownerusername = username;
            privillege = priv;
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.selectcourses_withpriv(ownerusername,privillege);
            comboBox1.DisplayMember = "course name";
            comboBox1.ValueMember = "Course-ID";
            comboBox1.DataSource = dt;
        }

    

        public void updateCombobox_after_deletion()
        {
            DataTable dt = controllerobj.selectcourses_withpriv(ownerusername,privillege);

            comboBox1.DisplayMember = "course name";
            comboBox1.ValueMember = "Course-ID";
            comboBox1.DataSource = dt;

            if (dt == null)
            {
                label1.Text = "NO COURSES TO DELETE";
            }
            else
            {
                label1.Text = "CHOOSE COURSE :";
            }
            comboBox1.Refresh();
        }

        private void done_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) //validation part
            {
                MessageBox.Show("NO COURSES TO DELETE");
            }
            else
            {
                int r = controllerobj.DeleteCourseT(ownerusername, Convert.ToInt32(comboBox1.SelectedValue), privillege);
                if (r > 0)
                {
                    MessageBox.Show("COURSE is deleted successfully");
                    updateCombobox_after_deletion();
                }
                else
                    MessageBox.Show("Error in deleting course");
            }

        }

        private void back3_Click_1(object sender, EventArgs e)
        {
            Owner.Show();
            
            this.Close();
        }

        private void Delete_coursesT_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            DataTable dt = controllerobj.selectcourses_withpriv(ownerusername, privillege);

            comboBox1.DisplayMember = "course name";
            comboBox1.ValueMember = "Course-ID";
            comboBox1.DataSource = dt;

            if (dt == null)
            {
                label1.Text = "NO COURSES TO DELETE";
            }
            else
            {
                label1.Text = "CHOOSE COURSE :";
            }
            comboBox1.Refresh();
        }
    }
}

