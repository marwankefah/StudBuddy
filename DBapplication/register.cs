using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DBapplication
{
    public partial class Register : Form
    {
        // now in this project we will autogenerate all the database for all colleges and faculties and their corrosponding departments on the internet as any other website 
        // data generated now in the database are for test 
        // registration made easy by checking for values not in combox at the end of the excution process
        Controller controllerObj;

        public Register()
        {
             // all the validation of the register is made by me when he press on the button Thank you (kefah)
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.SelectCollege();
            college.DataSource = dt;
            college.DisplayMember = "college name";    // initialization of college combox
            college.ValueMember = "CollegeID";
            DataTable citiestable= controllerObj.SelectCities();
            city.DataSource = citiestable;     // initialization of the cities tablle
            city.ValueMember = "City";      // does not violate 3NFD as city do not imply anything
            city.DisplayMember = "City";

            if (city.SelectedValue != null)
            {     // now handling the schema that i did not make
                // here selecting the district that hve the same city and insertion in the table of the student,teacher depending on the name
                // it was better if we dealt it by city id and district id
                DataTable districttable = controllerObj.Selectdistrict(city.SelectedValue.ToString());
                district.DataSource = districttable;     // initialization of the cities tablle
                district.ValueMember = "District";      // does not violate 3NFD as city do not imply anything
                district.DisplayMember = "District";


            }



            
            
            if (college.SelectedValue != null)
            {
                DataTable dt2 = controllerObj.SelectFaculty(college.SelectedValue.ToString());
                faculty.DataSource = dt2;      // initialization of faculty combobox
                faculty.DisplayMember = "faculty name";
                faculty.ValueMember = "Faculty ID";
            }


            if (faculty.SelectedValue != null && college.SelectedValue != null)
            {
               
                DataTable dt3 = controllerObj.selectdepartment(Convert.ToInt16(faculty.SelectedValue), Convert.ToInt16(college.SelectedValue));
                department.DataSource = dt3;
                 
                department.DisplayMember = "Department Name";  // initialization of departmentcombobox
                department.ValueMember = "Department-ID";
            }
            radioButton1.Checked = true; // just initiallization 




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // when changing the college everything need to be updated
        {

            if (college.SelectedValue != null)
            {
                DataTable dt = controllerObj.SelectFaculty(college.SelectedValue.ToString());
                faculty.DataSource = dt;
                faculty.DisplayMember = "faculty name";        // at every change of college id faculty must be updated
                faculty.ValueMember = "Faculty ID"; 
            }

            DataTable dt3;
            if (faculty.SelectedValue != null && college.SelectedValue != null)
            {
                 dt3 = controllerObj.selectdepartment((int)faculty.SelectedValue, (int)college.SelectedValue);  // at every change of college departmen t also myst be updated
                 department.DataSource = dt3;
                department.DisplayMember = "Department Name";
                department.ValueMember = "Department-ID";
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // changin the index of faculty only updates the department 
        {
            // here just getting the departments 
            DataTable dt3;
            if (faculty.SelectedValue != null && college.SelectedValue != null)
            {
                 dt3 = controllerObj.selectdepartment((int)faculty.SelectedValue, (int)college.SelectedValue);
                 department.DataSource = dt3;

                department.DisplayMember = "Department Name";        // when faculty combox is changed the department combox must be changed
                department.ValueMember = "Department-ID";
            }

           
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private bool isemailvalid(string email)    // email address is valid whenever it is like %@% as each email address consits of host and name
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);  // clas system.net.mail reperest the address of an email
                return true;               
            }
            catch     // if exception is thrown just return false for ERROR  above to add the string
            {
                return false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label10.Hide();
            priceperhour.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {



            label10.Show();
            priceperhour.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           //// must update district 

            if (city.SelectedValue != null)
            {     // now handling the schema that i did not make
                // here selecting the district that hve the same city and insertion in the table of the student,teacher depending on the name
                // it was better if we dealt it by city id and district id
                DataTable districttable = controllerObj.Selectdistrict(city.SelectedValue.ToString());
                district.DataSource = districttable;     // initialization of the cities tablle
                district.ValueMember = "District";      // does not violate 3NFD as city do not imply anything
                district.DisplayMember = "District";


            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   // Age is Auto checked And in OUR APPLICATION the default age is 16 cause
            
            // check for all normal names except username1 and password1,phonen
             
             string x="";   /// the string which will contains all the errors 
            bool correct=true;  // at first it turns false whether an exception is made
            if(firstname.Text.Count()>50)    // checking for the first name
            {
                x = x + "Error 001 Write a Firstname Maxiumum 50 Letters    ";
                correct=false;
            }
             // regex function is known from .NET Framework 4

            // so here matches letter from a to z or from A to Z +  te null terminator 
            if (!Regex.IsMatch( firstname.Text.ToString(),@"^[a-zA-Z]+$"))   // checking for the first name if matches = to like but this is the System.Text.RegularExpressions 
            {
                x = x + "  Error 002 FirstnamesNames can only have Characters    ";
                correct=false;

            }

            if (lastname.Text.Count() > 50)    // checking for the first name
            {
                x = x + "Error 001 Write a  Last name  Maxiumum 50 Letters    ";
                correct=false;

            }
            // regex function is known from .NET Framework 4

            // so here matches letter from a to z or from A to Z +  te null terminator 
            if (!Regex.IsMatch(lastname.Text.ToString(), @"^[a-zA-Z]+$"))   // checking for the first name if matches = to like but this is the System.Text.RegularExpressions 
            {
                x = x + "  Error 002 Lastnames can only have Characters    ";
                correct=false;

            }

            if (gender.SelectedItem == null)
            {
                x = x + "error select gender";
                correct = false;


            }



                 if (college.SelectedValue == null)
            {
                x = x + " Error 006 College is not selected  ";
                correct = false;

            }

            if (faculty.SelectedValue == null)
            {
                x = x + " Error 007 Faculty is not selected  ";
                correct = false;
                

            }

            if (department.SelectedValue == null)
            {
                x = x + " Error 006 department is not selected or contact us if u can not find urs    ";

                correct = false;
                
            }
            if (city.SelectedValue == null)
            {
                x = x + " Error 007 city is not selected     ";

                correct = false;
               
            }
            if (district.SelectedValue == null)
            {
                x = x + " Error 007 city is not selected     ";

                correct = false;
               
            }

            if (phonen.Text.Count() > 11)
            {
                x = x + " Error 007 please enter a valid phone number     ";
                correct = false;

            }
            if (!Regex.IsMatch(phonen.Text.ToString(), @"^(010|011|012|015)[0-9]{8}$"))   //Valid for EgYPT our country when will lanuch our application 
                // for vodafone ,orange,weee, andetisalat @"^01[0-2]{1}[0-9]{8}" @"^(010|011|012)(015)[0-9]{8}$" not working
            {
                x = x + " Error 007 please enter a valid phone number     ";
                correct = false;

            }


            if (correct == false)    // some values are null 
            {
                MessageBox.Show(x); // show all the errors and return 
                return;

            }


            if (!(gender.SelectedItem.ToString() == "M" || gender.SelectedItem.ToString() == "F"))
            {
                x = x + " ERROR 003 Please Specifiy Your Gender    ";
                correct=false;
            }

            if(email.Text.Count()>50)
            {
                x =x+" Error 004 Email must not exceed 50 characters   ";
                correct=false;
            }
            if (email.Text.Count() == 0)
            {
                x = x + " Error 004 enter a valid email  ";
                correct = false;
            }


            if (!isemailvalid(email.Text.ToString()))  // does not match the format user@host =to %@% we must not enter it 
            {
                x = x + " Error 005 Erorr Entering Your email Check Again  ";

                 correct=false;
            }

     

          
                // alternative used for hardocding password is hashing  , no encryption for now, or no storing in outer file

            if (username1.Text.Count() < 3)
            {
                x = x + " Error 007 please enter a valid Username Minimum 3 characters     ";
                correct = false;
            }

            if (password1.Text.Count() < 3)
            {
                x = x + " Error 008 please enter a valid Password Minimum 3 characters     ";
                correct = false;

            }

            if (controllerObj.isusernamehere(username1.Text.ToString()))  // now making sure each username is unique 
            {

                x = x + " Error 111 USERNAME ALREADY IN OUR DATABASE     ";
                correct = false;

            }

            if (correct == false)
            {
                MessageBox.Show(x); // show all the errors and return 
                return;

            }

            else if (correct == true)  // now each and every thing is correct we now must see the radiobutton
            {
                int y = 0;
                int z = 0;
                if (radioButton1.Checked == true) // is the radiobutton checked or not
                {
                    // first insert into userbasic
                    // then insert into  student so at a time each username is unique in our application regardeless whetheer he is student or teacher
                    y= controllerObj.insertintouserbasic(username1.Text,password1.Text,3); // as he is a student
                    z = controllerObj.insertintostudent(email.Text,firstname.Text, lastname.Text, (int)age.Value, gender.SelectedItem.ToString(), phonen.Text, city.SelectedValue.ToString(), district.SelectedValue.ToString(), (int)department.SelectedValue, (int)college.SelectedValue, (int)faculty.SelectedValue, username1.Text);
                   

                }

                else if (radioButton2.Checked== true)  // the radiobutton of the teacher is available
                {
                    // first insert into userbasic
                    // then insert into  student so at a time each username is unique in our application regardeless whetheer he is student or teacher

                   y= controllerObj.insertintouserbasic(username1.Text, password1.Text, 2); // as he is a teacher
                   z = controllerObj.insertintoteacher(email.Text,(int) priceperhour.Value,firstname.Text, lastname.Text, (int)age.Value, gender.SelectedItem.ToString(), phonen.Text, city.SelectedValue.ToString(), district.SelectedValue.ToString(), (int)department.SelectedValue, (int)college.SelectedValue, (int)faculty.SelectedValue, username1.Text);




                }
                else
                {

                    MessageBox.Show("ERROR REGISTREING PLEASE CONTACT marwanefah@gmail.com");
                    return;
                }





                if (y > 0 && z > 0)
                {
                    MessageBox.Show(" REGISTREING Successfully");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("  Error999 in REGISTREING contact us marwankefah ");

                }







            }



           


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
