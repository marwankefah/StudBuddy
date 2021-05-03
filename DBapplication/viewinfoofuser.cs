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
    public partial class viewinfoofuser :  Form
    {
       private int id;   // tors=3  then i am dealing with student id // 2 then i a dealing with teacher id
       private int ownerid;  // the id of the owner depending on the priv if priv 2 then the ownerid is a tid and if priv=3 then the ownerid is sid
        Controller controllerobj;
       private string  ownerusername;  // the username who is viewing the other user idthe username can be done by inheritance from the base form 
       private int privelage;
       int tors; //i am viewing a teacher or a student
        int opened;  // 0 it is opened in my notification button if it is 1 it is opened in my session the only difference that the button decline is switched to end session
        public viewinfoofuser(int id1,int priv,string owner,int tors1,int opened1=-1)  // tors represent whether u want to see the info of a teacher or a student
        {      
            // tors=2 i am viewing the info of teacher if tors =3 then i am viewing the info of student
            opened = opened1; 
            controllerobj= new Controller();
            id = id1;
            ownerid = 0;   // at first it is set in the comparison of the priv at the end
            InitializeComponent();
            privelage=priv;
            tors = tors1;
            ownerusername = owner;
            DataRow drow=null;
            if (tors == 2)       // tors is sent with 2 i want the teacher info regardless of 
            { 
                drow = controllerobj.selectteacherbyid(id).Rows[0]; // getting most of the info of the teacher 
            priceperhourbox.Text = drow["PriceperHour"].ToString(); // showing the price per hour button because i am showing the info of a teacher
            }
            else if (tors == 3)
            {
                priceperhourbox.Hide();  // hiding the price per hour button because i am showing the info of a student
                priceperhourlabel.Hide();
                drow = controllerobj.selectstudentbyid(id).Rows[0];  // getting most of the info from student table 
            }
            else
            {
                MessageBox.Show("error 112");   // error from database makers cause tors is send privately in the code
                return;
            }
                        
           string name1="";
           name1 = (string) drow["First name"] +(string) drow["last name"];      // last and first name merged together in one name  
           name.Text = name1;
           age.Text = drow["age"].ToString();
           gender.Text = (string) drow["gender"];         // general info about the user that helps the receiver
           city.Text = (string)drow["city"];
           district.Text = (string)drow["district"]; //those info are important for cross sectional communication between the users
           Phone.Text = drow["Phone#"].ToString();
           score.Text = drow["score"].ToString();
           collegename.Text = (string)drow["College Name"];
           facultyname.Text = (string)drow["Faculty Name"];         // info about the educaiton history of the user
           departmentname.Text = (string)drow["Department Name"];
           if (opened == 0)
           {
               comboBox2.Hide();
               label12.Hide();

               
           }
           else if (opened == 1)
           {
               comboBox2.Show();
               label12.Show();
              

           }
     
            //  after the above has been excuted now the form contains the info of the student or the teacher 
           if (!(opened == 0 || opened == 1))
           {

               label1.Hide();
               accept.Hide();      // a default binding that hides all the buttons and just view the info not used just for further implementations 
               decline.Hide();   
               return;     

           }
            
            DataTable dt=null;       // this is the info in the combobox it contains the courses requested or the courses opened with others 
            
            // opened =0 reminder means that i am accepting and declinging requests
            if(priv==2)
            {
                // teacher only deals with students here 
                ownerid = controllerobj.getidfromuserandpriv(ownerusername, 2);
                if (opened == 0)   // i am a teacher in the notification section
                {
                    // because listbox selects distinct names so if someone requested me for two different courses i teach
                    dt = controllerobj.selectcoursenamebyidfromsrt(id, ownerusername); // get the courses that is requested by the id of the student
                }
                else   // it is =1 //if not both just look at line 62 
                {
                    // i am  a teacher in the session section //functionality teacher can end the session 
                   
                //  int tid = controllerobj.getidfromuserandpriv(ownerusername, 2);
                  dt = controllerobj.selectcoursenamebyidfromstos(id,ownerid,1); // the courses that a special student is engaged with a teacher in opened =1 because only opened 
                // dt can not be equal null here no worries to check
                    label11.Text = "Choose the Subject You want to end the Session For";
                 accept.Hide();
                 decline.Text = "End session";
                }

       

            }
            else if(priv==3)   // now   student  implementation
            {
                ownerid = controllerobj.getidfromuserandpriv(ownerusername, 3);
                // student deal with teachers and other students here 
                if (opened == 0)   // now i am a student in the notification form i need to have 2 functionalites (accept or decline)
                {
                    // SRS contains the student request to another student to study a subject with 
                    // because listbox selects distinct names so if someone requested me for two different courses i teach
                 dt = controllerobj.selectcoursenamebyidfromsrs(id, ownerusername); // get the courses that another students requested me to go out with

                }
                else   // if not 0 it can not be anything check line 63
                {
                    // here i am a student in my  sessions then i have the ability to the end the session
                    // you can end the session with a teacher normally
                    // strict  the student from ending the session with a teacher it is easy just enter the form with opened not =0 or 1 see line 63
                    if (tors == 3)   // i am a student viewing another student 
                    {
                        // the id sent to this function
                        dt = controllerobj.selectcoursenamebyidfromssos(id, ownerusername, 1); // the courses that a special student is engaged with a teacher in
                        // now worries dt can not be equal null here 
                        label11.Text = "Choose the Subject You want to end the Session For";
                        accept.Hide();
                        decline.Text="End Session";
                    }
                    else   // tors =2 see line 23 if u need further explanation
                    {
                        // now i am a student with priv 3 viewing a teacher 
                        // the id sent now is the id of the teacher 
                        // now sending it away witht the teacher id to get all courses in common
                        dt = controllerobj.selectcoursenamebyidfromstos(ownerid,id, 1); // the courses that a special student is engaged with a teacher in
                        label11.Text = "Choose the Subject You want to end the Session For";
                        accept.Hide();
                        decline.Text = "End Session";
                    }

                }


                // end of priv comparisons  you can add any priv comparison if not 2 or 3 here




            }
            if (dt == null)   // a check that the combox is empty 
            {

                return;    
            }
            comboBox1.DataSource = dt;   
            comboBox1.ValueMember = "courseid";    // now the combox contains the true values for id,name aand opened =1 so it is opened sessions
            comboBox1.DisplayMember = "course name";
         
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void accept_Click(object sender, EventArgs e)   // first accepet is only visible in the notification section no need to check for opened
        {
            int s=0;
            if (opened != 0)  // for further implementation special because if the code is implemented by html not letting users inspect and make an error in it 
            {
                return;

            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show(" Choose the course ERROR 150");   // error 150 is when u ppress on accept without giving a course 

                return;

            }

            if (privelage == 2) /// i am a TEACHER i am the only one who can insert into open session with me and student
            {    // i am a teacher accepting a student reminder: teacher request no one they only accept or decline other students
             // the id here resemble the student who made the request 
               // each tid can be replaced by ownerid done above
                s = controllerobj.insertintostos(id, ownerusername,(int) comboBox1.SelectedValue); // combox can not be empty here 
                controllerobj.deletefromsrt(id,ownerid,(int)comboBox1.SelectedValue); // here deleting the id of the student requesting the teacher
            }
            else if (privelage == 3) // i am a student 
            {
                // no worried for the combox selected value it can never be null here cause it is a notification from a user by course
                 // now in the open sessions the order does not matter but for generity let the accepter one in the second place and the requester in the first
                
                // no worries here comboboxvalue is not null 
                // at the very insert we must put the opened =1 because initially the session is opened
                s = controllerobj.insertintossos(id, ownerid, (int)comboBox1.SelectedValue); // now id and sid and the course id are inserted in stuent-student session
               // here it depends on the order values are inserted in srs but for me to make
                // sure that it is deleted the primary key of srs are sid1,sid2,courseid2 so implementing it correctly
                controllerobj.deletefromsrs(id,ownerid, (int)comboBox1.SelectedValue); // here deleting the student who requested me from the database 
            }
          
         if (s > 0)
            {

                MessageBox.Show("Accepted Successfuly");

                    this.Close();


            }
            else
            {
                MessageBox.Show("Error in Accepting");



            }
         
           
        }

        private void decline_Click(object sender, EventArgs e)  // here implementing the declining and the ending session
        {

            if (comboBox1.SelectedValue == null)
            {

                MessageBox.Show(" Choose the course ERROR 150");   // error 150 is when u ppress on accept without giving a course 
                return;
            }

            
                 
            if (opened == 0)       // in the notification u can be either a student or a teach er
            {

                 int p=0;
                if (privelage == 2)  // you are a teacher then delete it from srt 
                {
                  
                   p = controllerobj.deletefromsrt(id, ownerid, (int)comboBox1.SelectedValue);
                }
                else if(privelage==3)// you are a student declining other student take care teacher do not request student
                { 
                    // reminders teachers do not request students
                 
                    // does not matter the order cause i will delete each pair having all the attribute the 
                    // the primary key of such a table to be asked 
                    p = controllerobj.deletefromsrs(ownerid, id, (int)comboBox1.SelectedValue); // deleting students from requests table
                }
                      // end of privilage comparison
        
                if (p > 0)
                {
                    MessageBox.Show("Declined Successfuly");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Error in Declining");
                    this.Close();

                }
            }
            else    // it is ending the session not declining it
            { // here it is in stos which is in the open session we can delete it from open session and add it it to closed sessions(optional for us)

                int p = 0;
                // ending the session now 
                if (privelage == 2)  // if i am a teacher i am viewing only students
                {
                    DataTable db = controllerobj.selectratingts(ownerid, id, 1);
                    // now the session is updated  after it is eneded by giving the value false to the opened colummn
                    if (db!=null)
                    {
                        p = controllerobj.updateopenedSTOS(id, ownerid, (int)comboBox1.SelectedValue, 0);  // set the opened in the student-teacher session with 0 means session is closed 
                    }
                    else
                    {
                        if (comboBox2.SelectedItem == null)
                        {
                            MessageBox.Show("Choose rating");
                            return;
                        }

                        int q = controllerobj.insertratingendts(ownerid, id, 1);
                        if (q>0)
                        {
                           
                        }
                        else
                        {
                            MessageBox.Show("Error(130) you have rated this person before or this person rated you before you should check the rate section in mysession");
                            return;
                        }
                        int r = controllerobj.insertratingts(ownerid, id, Convert.ToInt16(comboBox2.SelectedItem),1);
                        if (r > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error(604) You Have Rated this Person before");
                            return;
                        }
                        MessageBox.Show("Rating Successful!!");



                        p = controllerobj.updateopenedSTOS(id, ownerid, (int)comboBox1.SelectedValue, 0); 
                    }
                }
                else if (privelage == 3)
                {
                    // now the session is updated  after it is eneded by giving the value false to the opened colummn
                    if (tors == 3) // i am viewing a student
                    {
                        DataTable db = controllerobj.selectratingstudent(ownerid, id);
                        if (db!=null)
                        {
                            comboBox2.Hide();
                            p = controllerobj.updateopenedSSOS(id, ownerid, (int)comboBox1.SelectedValue, 0);  // set the opened in the student-teacher session with 0 means session is closed 
                        }
                        else
                        {
                            if (comboBox2.SelectedItem == null)
                            {
                                MessageBox.Show("Choose rating");
                                return;
                            }

                            DataTable d2 = controllerobj.checkrating(id, ownerid);
                            if (d2 == null)
                            {
                                int q = controllerobj.insertratingendss(ownerid, id, 0);
                            }
                            else
                            {
                                MessageBox.Show("Error(130) you have rated this person before or this person rated you before you should check the rate section in mysession");
                                return;
                            }
                            int r = controllerobj.insertratingss(ownerid, id, Convert.ToInt16(comboBox2.SelectedItem));
                            if (r > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Error(604) You Have Rated this Person before");
                                return;
                            }
                            MessageBox.Show("Rating Successful!!");



                            p = controllerobj.updateopenedSSOS(id, ownerid, (int)comboBox1.SelectedValue, 0); 

                        }
                        
                    }
                    else if (tors == 2)  // i am viewing a teacher
                    {
                        
                        DataTable db = controllerobj.selectratingts(id, ownerid, 0);
                        // now the session is updated  after it is eneded by giving the value false to the opened colummn
                        if (db != null)
                        {
                            p = controllerobj.updateopenedSTOS(ownerid, id, (int)comboBox1.SelectedValue, 0); // set the opened in the student-teacher session with 0 means session is closed 
                        }
                        else
                        {
                            if (comboBox2.SelectedItem == null)
                            {
                                MessageBox.Show("Choose rating");
                                return;
                            }

                            int q = controllerobj.insertratingendts(id, ownerid, 0);
                            if (q > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Error(130) you have rated this person before or this person rated you before you should check the rate section in mysession");
                                return;
                            }
                            int r = controllerobj.insertratingts(id, ownerid, Convert.ToInt16(comboBox2.SelectedItem), 0);
                            if (r > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Error(604) You Have Rated this Person before");
                                return;
                            }
                            MessageBox.Show("Rating Successful!!");



                            p = controllerobj.updateopenedSTOS(ownerid, id, (int)comboBox1.SelectedValue, 0);
                        }
                    }

                }
                
              
                if (p > 0)
                {
                    MessageBox.Show("Session Ended Successfuly");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Error in Session  Ending");
                    this.Close();

                }

         

            }
            
            
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
