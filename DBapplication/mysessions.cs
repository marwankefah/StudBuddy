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

    // DATE IS NOT IMPORTANT IN THIS APPLICATION as it is studbuddies for more explanation contact us
    /*
    
  HERE IT IS MY SESSIONS WHERE A STUDENT OR A TEACHER CAN SEE THE OPENED SESSIONS WITH OTHERS BY CHOOSING FROM COURSES HE IS INTERESTED IN
      
     */

    public partial class  mysessions : Form
    {
        private int privillege;   // the priv of the user
        private string ownerusername;   // the username of the user which is unique regardless it is student or teacher 
        int back;      // used for form closing 
        Controller controllerobj;
        private int totalnofoswiths;  // total number of opened session with student
        private int totalnofoswitht;// total number of opened session with teacher
        int id;   // the id that depends on the priv whether student or teacher
        public mysessions(string username,int priv,int id1)    // making sure that there is no privilage can enter this form
        {
            back = 0;
            ownerusername = username;  // the username stored inn userbasic
            privillege = priv;     // the privilage of the student,teacher if 2 it is a teacher if 3 it is a student no other privilage enter this form
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt=null;
            id = id1;
            if (priv == 2)  // priv =2 then i am a teacher
            {
                id = controllerobj.getidfromuserandpriv(ownerusername, 2);
                 dt = controllerobj.selectcourses_withpriv(ownerusername,2); // select all the courses teacher is interested in
                 radioButton1.Hide();
                 radioButton2.Hide();
                 label5.Hide(); // hide the statisitcs about teachers who reported me
            }
            else if (priv == 3)   // i am a student
            {
                id=controllerobj.getidfromuserandpriv(ownerusername,3);
                dt = controllerobj.selectcourses_withpriv(ownerusername,3);    // select all the courses that student is interested in
               
               

            }
               
                comboBox1.DataSource = dt;             // time to put in the combox the courses
                comboBox1.DisplayMember = "course name";
                comboBox1.ValueMember = "Course-ID";
            

            if (priv == 3)
            {
             radioButton1.Checked = true;
             
            }
            updatesessions();

        }

        public void updatesessions()
        {

            
               label4.Text = "Total number of opened session with students is ";
               if(privillege==3)   // i am a student  then i can have OS with students or teacher
               {
                int y = controllerobj.getcountofSfromSTOS(id,privillege,1); //here privilage 3 is sent
                label5.Text = "Total number of opened session with teachers is " + y.ToString(); // now i have the totak number
                int x = controllerobj.getcountofSfromSSOS(id, privillege,1);  // must search with pairs 1 because i want to return the opened sessions
                   label4.Text = "Total number of opened session with students is " + x;

               }
               else if (privillege == 2)  // i am a teacher i only have opened session with students 
               {
                   int y = controllerobj.getcountofSfromSTOS(id, privillege,1); // here privillege 2 is sent
                   label4.Text = "Total number of opened session with students is "+y;  
               }


            if (comboBox1.SelectedValue == null)   // the combox is empty
            {
                label1.Text = "NO OPENED sessions check Your notifications";
                label2.Text = " ";

                return;
            }
            DataTable dt = null;  // initialization with null
           
             if (privillege == 2)   // i am ateacher then i will select the open sessions i teach from STOS which is Student teacher sessions only
            {
              dt = controllerobj.selectmystudentsfromstos(id,(int)comboBox1.SelectedValue,1); // the id that is sent here is the id of a teacher as the privilage =2 and the selected value of the course id and opened =1 means that the session is still opened
               listBox1.DataSource = dt;
               listBox1.DisplayMember = "Username";
               listBox1.ValueMember = "studentid";
               
               label1.Text = "Opened Sessions with students";
               label2.Text = " Double Click on the username for more info or to end the session";
            }
            else if (privillege == 3)   // i  am a student then i will select the open sesions from STOS where i am with the teacher or from SSOS where i am with another student
            {
                if (radioButton1.Checked)
                {

                    dt = controllerobj.selectmystudentsfromssos(id, (int)comboBox1.SelectedValue, 1); // this will get all the student i am with and our session is opened  
                   
                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "Username";
                    listBox1.ValueMember = "sid1";
                    
                    label1.Text = "Opened Sessions with students";
                   
                }
                else if (radioButton2.Checked)
                {
                       dt = controllerobj.selectteachersfromstos(id, (int)comboBox1.SelectedValue, 1); // this will get all the teachers i am with and our session is opened  
                       listBox1.DataSource = dt;
                       listBox1.DisplayMember = "Username";
                       listBox1.ValueMember = "teacherid";    // value and display member depend on what is retirved
                        
                        label1.Text = "Opened Sessions with teachers";
                    
                }
                
                
                
                label2.Text = " Double Click on the username for more info or to end the session"; // message to clarify to user
            }
           
            if (dt == null)
            {
                label1.Text = "NO OPENED session for selected course"; // message to print 
                label2.Text = " ";

            }
            

            listBox1.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }

        private void mysessions_FormClosed(object sender, FormClosedEventArgs e)
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

        private void opened_Click(object sender, EventArgs e)
        {
         //   new openedsessions(privillege,ownerusername).Show(this);
        }

        private void closed_Click(object sender, EventArgs e)
        {
         //   new closedsessions(privillege, ownerusername).Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatesessions();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
            
        {
            if (listBox1.Items.Count == 0)
            {
                return;
            }

            if(privillege==2)   // i  am a teacher it is easy just view the info of the student i press on 
            {
            int studentid = (int) listBox1.SelectedValue;
            viewinfoofuser studentinfo = new viewinfoofuser(studentid, privillege, ownerusername,3,1);
            studentinfo.Show(this);
               
            }
            else if (privillege == 3)   // i am a student either show me student info or teacher info depending on the radiobutton
            {
                if (radioButton1.Checked)     // then i am double clicking on a student no error cause update session works at the instant radiobutton change 
                {
                    int studentid = (int)listBox1.SelectedValue;
                    viewinfoofuser studentinfo = new viewinfoofuser(studentid, privillege, ownerusername, 3,1);
                    studentinfo.Show(this);


                }
                else if (radioButton2.Checked)  // i am double clicking on teacher then info about the teacher appear
                {

                    int teacherid = (int)listBox1.SelectedValue;

                    // here the tors is 2 as i am a teacher and opened=1 as i am in the mysession button
                    viewinfoofuser teacherinfo = new viewinfoofuser(teacherid, privillege, ownerusername,2,1);
                    teacherinfo.Show(this);

                }




            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatesessions();
        }

        private void mysessions_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            updatesessions();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            updatesessions();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Rate(id,privillege).Show(this);
            

        }


    }
}
