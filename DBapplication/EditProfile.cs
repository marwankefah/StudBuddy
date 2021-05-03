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
    public partial class EditProfile : Form
    {
        int back;
        private int privillege;
        private string ownerusername;
        Controller controllerobj;

        public EditProfile(string username, int priv)
        {
            back = 0;
            ownerusername = username;
            privillege = priv;
            InitializeComponent();
            controllerobj = new Controller();

            fname.Text = Convert.ToString(controllerobj.getfname(ownerusername, privillege));
            Lname.Text = Convert.ToString(controllerobj.getlname(ownerusername, privillege));
            age.Value = Convert.ToInt32(controllerobj.getage(ownerusername,privillege));
            email.Text = Convert.ToString(controllerobj.getemail(ownerusername, privillege));
            phone.Text = Convert.ToString(controllerobj.getphone(ownerusername,privillege));
            if (privillege == 2)
            {
                price.Value = Convert.ToInt32(controllerobj.getpriceperhour(ownerusername, privillege));
            }
            DataTable dt = controllerobj.EditCollege(ownerusername, privillege);
            college.DisplayMember = "college name";
            college.ValueMember = "CollegeID";
            college.DataSource = dt;

            DataTable dt2 = controllerobj.Selectcity();
            city.DisplayMember = "City";
            city.ValueMember = "City";
            city.DataSource = dt2;

             if (privillege == 3)  //student
            {
               label7.Hide();
                price.Hide();
            }

        }
        private void updatefaculty()
        {
            DataTable dt = controllerobj.SelectFaculty(college.SelectedValue.ToString());
            faculty.DataSource = dt;
            faculty.DisplayMember = "faculty name";
            faculty.ValueMember = "Faculty ID";

        }
        private void updateDepartment()
        {
            DataTable dt = controllerobj.SelectDepartment(faculty.SelectedValue.ToString(),college.SelectedValue.ToString());
            department.DataSource = dt;
            department.DisplayMember = "Department name";
            department.ValueMember = "Department-ID";
        }
        private void updatecity()
        {
            DataTable dt = controllerobj.Selectcity();
            city.DataSource = dt;
            city.DisplayMember = "City";
            city.ValueMember = "[Spot-ID]";
        }
        private void updatedistrict()
        {
            DataTable dt = controllerobj.Selectdistrict(city.SelectedValue.ToString());
            district.DataSource = dt;
            district.DisplayMember = "District";
            district.ValueMember = "District";
        }
        //private void updateSpotname()
        //{
        //    DataTable dt = controllerobj.selectSpotName(city.SelectedValue.ToString(),district.SelectedValue.ToString());
        //    SPOTNAME.DataSource = dt;
        //    SPOTNAME.DisplayMember = "Street name";
        //    SPOTNAME.ValueMember = "Street name";

        //}
        ///////////// selected index changed////////////////////////////////
        private void college_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatefaculty();
        }
        private void faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDepartment();
        }
        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatedistrict();
        }
        private void district_SelectedIndexChanged(object sender, EventArgs e)
        {
           // updateSpotname();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //HENA HA SEND KOL HAGA MHTAGA TEB2A UPDATED
            int count = 0;

                if(fname.Text !="")    //check for FNAME
                {
                    controllerobj.updateFName(ownerusername, privillege, fname.Text.ToString());
                    count++;
                }
                else if (fname.Text == "")
                {
                    object name= controllerobj.getfname(ownerusername, privillege);
                    controllerobj.updateFName(ownerusername, privillege, Convert.ToString(name));
                }

                if (Lname.Text != "")    //check for LNAME
                {
                    controllerobj.updateLName(ownerusername, privillege, Lname.Text.ToString());
                    count++;
                }
                else if (Lname.Text == "")
                {
                    object name = controllerobj.getlname(ownerusername, privillege);
                    controllerobj.updateLName(ownerusername, privillege, Convert.ToString(name));
                }


                if (age.Value >=18)    //check for age
                {
                    controllerobj.updateAge(ownerusername, privillege,Convert.ToInt32(age.Value));
                    count++;
                }
                else if (age.Value < 18)
                {
                    object age1 = controllerobj.getage(ownerusername, privillege);
                    controllerobj.updateAge(ownerusername, privillege,Convert.ToInt32(age1));
                }


                if (email.Text != "")    //check for email
                {
                    controllerobj.updateEmail(ownerusername, privillege, email.Text.ToString());
                    count++;
                }
                else if (email.Text == "")
                {
                    object email1 = controllerobj.getemail(ownerusername, privillege);
                    controllerobj.updateEmail(ownerusername, privillege,Convert.ToString(email1));
                }

                if (phone.Text != "")    //check for phone number
                {
                    // object phone1 = int.Parse(phone.Text);
                    controllerobj.updatePhoneNO(ownerusername, privillege,Convert.ToInt32(phone.Text));
                    count++;
                }
                else if (phone.Text == "")
                {
                    object phone1 = controllerobj.getphone(ownerusername, privillege);
                    controllerobj.updatePhoneNO(ownerusername, privillege, Convert.ToInt32(phone1));
                }


                if (privillege == 2)
                {
                    if (price.Value >=80 && price.Value<= 250)    //check for phone number
                    {
                        controllerobj.updatePricePerHour(ownerusername, privillege, Convert.ToInt32(price.Value));
                        count++;
                    }
                    else if (price.Value <80)
                    {
                        object price1 = controllerobj.getpriceperhour(ownerusername, privillege);
                        controllerobj.updatePricePerHour(ownerusername, privillege,Convert.ToInt32(price1));
                    }
                }

            //////////////////////////////////////////UPATE OF COLLEGE ....ETC////////////////////////////////////////////////////////////
                if (college.SelectedValue != null) //value member is college id
                {
                    controllerobj.updateCollege(ownerusername, privillege, Convert.ToInt32(college.SelectedValue));
                    count++;
                }
                if (college.SelectedValue == null) //value member is college id
                {
                    object cid = controllerobj.getcollege(ownerusername,privillege);
                    controllerobj.updateCollege(ownerusername, privillege, Convert.ToInt32(college.SelectedValue));
                }

                
                if (faculty.SelectedValue != null)
                {
                    controllerobj.updateFaculty(ownerusername, privillege, Convert.ToInt32(faculty.SelectedValue));
                    count++;
                }
                if (faculty.SelectedValue == null) //value member is college id
                {
                    object fid = controllerobj.getfaculty(ownerusername, privillege);
                    controllerobj.updateCollege(ownerusername, privillege,Convert.ToInt32(fid) );
                }


                if (department.SelectedValue != null)
                {
                    controllerobj.updateDepartment(ownerusername, privillege, Convert.ToInt32(department.SelectedValue));
                    count++;
                }
                if (department.SelectedValue == null) //value member is college id
                {
                    object did = controllerobj.getdepartement(ownerusername, privillege);
                    controllerobj.updateCollege(ownerusername, privillege,Convert.ToInt32(did));
                }


                if (city.SelectedValue != null)
                {
                    controllerobj.updateCity(ownerusername, privillege,Convert.ToString(city.SelectedValue));
                    count++;
                }
                if (city.SelectedValue == null) //value member is college id
                {
                    object city1 = controllerobj.getcity(ownerusername, privillege);
                    controllerobj.updateCity(ownerusername, privillege, Convert.ToString(city1));
                }
            

                if (district.SelectedValue != null)
                {
                    controllerobj.updateDistrict(ownerusername, privillege, Convert.ToString(district.SelectedValue));
                    count++;
                }
                if (district.SelectedValue == null) //value member is college id
                {
                    object district1 = controllerobj.getdistrict(ownerusername, privillege);
                    controllerobj.updateCity(ownerusername, privillege, Convert.ToString(district1));
                }


                //if (SPOTNAME.SelectedValue != null)
                //{
                //    controllerobj.updateDistrict(ownerusername, privillege, district.SelectedValue.ToString());
                //    count++;
                //}
            ///////////////////hena lesa fe haga msh mazbota leha 3elaka b spots wana m3ndesh spot name fel teacher aw student


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (count == 0)
                {
                    MessageBox.Show("NO NEW EDITS OCCURED IN YOUR ACCOUNT");
                }
                else
                {
                    MessageBox.Show("YOUR ACCOUNT HAS BEEN UPDATED");
                }



        }
        private void EditProfile_FormClosed(object sender, FormClosedEventArgs e)
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
        private void price_ValueChanged(object sender, EventArgs e)
        {

        }
        private void SPOTNAME_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 65 && ch != 66 && ch != 67 && ch != 68 && ch != 69 && ch != 70 && ch != 71 && ch != 72 && ch != 73 && ch != 74 && ch != 75
                && ch != 76 && ch != 77 && ch != 78 && ch != 79 && ch != 80 && ch != 81 && ch != 82 && ch != 83 && ch != 84 && ch != 85 && ch != 86 && ch != 87 && ch != 88
                && ch != 89 && ch != 90)
            {
                e.Handled = true;
                MessageBox.Show(" RE-ENTER NUMBERS ONLY !!");
                phone.Text = "";
            }
        }
        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            //if (!char.IsDigit(ch) && ch != 32)
            //{
            //    e.Handled = true;
            //    MessageBox.Show(" RE-ENTER :: no  spaces are allowed");
            //}
            //else if(ch==8)
            //{
            //    e.Handled = true;
            //}
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {

        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
