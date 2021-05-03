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
    public partial class notification : Form1
    {
        int back; // responsible for closing without closing the owner 
        private int  priviliage;
        private string username1;
        Controller controllerobj;

        public notification( string username2,int priv)
        {
            back = 0;
            priviliage = priv;
            username1 = username2;
            InitializeComponent();
            controllerobj= new Controller();
            updatelistbox();   // to update the list box with the requestes ypu have
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }

        private void updatelistbox()
        {
            // check the privilage here 
            DataTable dt = null;

                 if(priviliage==2)    // here i am a teacher then the only notifications that come come from students
                 {
                  dt=   controllerobj.selectsr(username1);
                   
                      listBox1.DataSource = dt;
                      listBox1.DisplayMember = "Username";  // displaying the username on the listbox with the value memeber id that is used to view info
                      listBox1.ValueMember = "student-id";
                    
                  
                    }
                       else if(priviliage==3)  // here i am a student all notifications only comes from students
                            {
                         dt=    controllerobj.selectsrs(username1);  // here i will select disiinct usernames for all people who requested me 
                          
                             listBox1.DataSource = dt;
                             listBox1.DisplayMember = "Username";
                             listBox1.ValueMember = "sid1";   // the id of the one who requested me 
                         
                       }
            if (dt == null)
            {
                label1.Text = "NO one requested you";  // message to show
                label2.Text = " ";
            }
            else
            {
                label1.Text = "People who requested YOU";
                label2.Text = " double click on the username to show more details,accept,or decline";  
            }
            listBox1.Refresh();
        }
        
        private void f(object sender, EventArgs e)
        {

        }

        private void notification_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (back == 1)      // a notified that back haas been made 
            {

                back = 0;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Owner.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)  // when someone double click on the list box info is seen
        {

            if (listBox1.Items.Count == 0)
            {
                return;
            }

            if (priviliage == 2)  // if i am a teacher then i am double clicking on a student
            {
                int studentid = (int)listBox1.SelectedValue;
                viewinfoofuser studentinfo = new viewinfoofuser(studentid, priviliage, username1, 3, 0);  // info about the student appears tors here is always 3 
                studentinfo.Show(this);
            }
            else if (priviliage == 3)     // i am a student then all my notifications will also be from students
            {
                
                int studentid = (int)listBox1.SelectedValue;
                // here t or s passed to viewstudent is always 3 because only people who are allowed to request are students 
                // so only students usernames appear on your notifications  // 0 represent a number that u are in the notification section
                viewinfoofuser studentinfo = new viewinfoofuser(studentid, priviliage, username1, 3, 0);
                studentinfo.Show(this);


            }


        }

        private void refresh_Click(object sender, EventArgs e)
        {
            updatelistbox(); // a message to update the box
        }




    }
}
