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
    public partial class Search : Form
    {
        Controller controllerObj;
        private string username;
        private int privshow;
        private int back;
        private int courseselected;
        public Search(string username1)
        {
            back = 0;
            username = username1;
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.SelectCourses();
            course.DataSource = dt;
            course.DisplayMember = "Course Name";
            course.ValueMember = "Course-ID";
            DataTable dt2 = controllerObj.SelectCities();
            City.DataSource = dt2;
            City.DisplayMember = "City";
            City.ValueMember = "City";
           
        }


        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectDistricts(City.SelectedValue.ToString());
            District.DataSource = dt;
            District.DisplayMember = "District";
            District.ValueMember = "District";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (District.SelectedValue == null)
            {
                MessageBox.Show("Please Choose District");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Please Choose Student or Teacher");
                }

                else if (radioButton1.Checked)
                {
                    listBox2.Hide();
                    listBox1.Show();
                    privshow = 3;
                    listBox1.DisplayMember = null;
                    listBox1.ValueMember = null;
                    int id = controllerObj.getidfromuserandpriv(username, privshow);
                    DataTable dt = controllerObj.SelectStudentssearch(course.SelectedValue.ToString(), City.SelectedValue.ToString(), District.SelectedValue.ToString(),username,id);
                    listBox1.DisplayMember = "Username";
                    listBox1.ValueMember = "student-id";
                    listBox1.DataSource = dt;
                    listBox1.Refresh();
                    courseselected = Convert.ToInt16(course.SelectedValue);

                }
                else
                {
                    listBox1.Hide();
                    listBox2.Show();
                    listBox1.DisplayMember = null;
                    listBox1.ValueMember = null;
                    privshow = 2;
                    int id = controllerObj.getidfromuserandpriv(username, 3);
                    // to add here to prevent him from searching in the same course if he has open session with
                    DataTable dt = controllerObj.SelectTeacherssearch(course.SelectedValue.ToString(), City.SelectedValue.ToString(), District.SelectedValue.ToString(),username,id);
                    listBox2.DisplayMember = "Username";
                    listBox2.ValueMember = "teacher-id";
                    listBox2.DataSource = dt;
                    listBox2.Refresh();
                    courseselected = Convert.ToInt16(course.SelectedValue);
                }
            }
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                return;
            }
            string s1 = listBox1.DisplayMember;
            int s = Convert.ToInt16(listBox1.SelectedValue);
            viewinfo s3 = new viewinfo(privshow, s, s1, username, courseselected);
            s3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            back = 1;
            Owner.Show();
            this.Close();

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)
            {
                return;
            }

            string s1 = listBox2.DisplayMember;
            int s = Convert.ToInt16(listBox2.SelectedValue);
            viewinfo s3 = new viewinfo(privshow, s, s1, username, courseselected);
            s3.Show();




        }

        private void course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

       

      
    }
    
}
