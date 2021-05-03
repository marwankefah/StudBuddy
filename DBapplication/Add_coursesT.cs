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
    public partial class Add_coursesT : Form
    {
        int back2;
        Controller controllerobj;
        private int privillege;
        private string ownerusername;

        public Add_coursesT(string username, int priv)
        {
            back2 = 0;
            ownerusername = username;
            privillege = priv;
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.selectcourses(ownerusername,privillege);
            comboBox1.DisplayMember = "course name";
            comboBox1.ValueMember = "Course-ID";
            comboBox1.DataSource = dt;
        }

        private void Add_coursesT_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (back2 == 1)
            {
                back2 = 0;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Owner.Close();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back2 = 1;
            this.Close();
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) //validation part
            {
                MessageBox.Show("NO COURSES TO ADD !!!");
            }
            else
            {
                int r = controllerobj.InsertCourseT(ownerusername,Convert.ToInt32(comboBox1.SelectedValue));
                if (r > 0)
                {
                    MessageBox.Show("COURSE inserted successfully");
                    updateCombobox_after_insertion();
                }
                else
                    MessageBox.Show("Error inserting course");
            }
        }

        public void updateCombobox_after_insertion()
        {
            DataTable dt = controllerobj.selectcourses(ownerusername,privillege);

            comboBox1.DisplayMember = "course name";
            comboBox1.ValueMember = "Course-ID";
            comboBox1.DataSource = dt;

            if (dt == null)
            {
                label1.Text = "NO COURSES TO ADD ";
            }
            else
            {
                label1.Text = "CHOOSE COURSE :";
            }
            comboBox1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
