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
    public partial class Form1 : Form
    {
        public int _privilege;
        public int id;
        private string username;
        Controller contoller;
       public Form1(int privilage,string username1)
        {
           InitializeComponent();
           contoller = new Controller();
           username = username1;
           id = 0;
           this._privilege = privilage;
           
           if (_privilege ==2 )
           {
               this.Search.Enabled = false;
               this.Search.Hide();
               teachersSessionsToolStripMenuItem.Visible = false;
               studentSessionsToolStripMenuItem.Visible = false;
            }
        }

       public Form1()
       {


       }

        public string getusername()
        {
            return username;

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            
            new MyCourses(username, _privilege).Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
               new notification(username,_privilege).Show(this);
                this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            Owner.Show();
        }

        private void addCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void mysession_Click(object sender, EventArgs e)
        {
            int id = contoller.getidfromuserandpriv(username, _privilege);
            new mysessions(username, _privilege,id).Show(this);
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("STINDER                                                is an APP to Help Teachers and Students connect with each other , find their studbuddy,and receiving help from each other.                                                     How to Use                                                                            Terms and conditions ");
        }

        private void editSpotsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditProfile(username, _privilege).Show(this);
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Search(username).Show(this);
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            new MySpots(username, _privilege).Show(this);
            this.Hide();
        }

        private void allowDiscoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = contoller.getidfromuserandpriv(username, _privilege);
            int p=contoller.EnableDiscovery(id,_privilege);
            if (p > 0)
            {
                MessageBox.Show("YOu are now Discoverable");
            }
            else
            {

                MessageBox.Show("Error in updating discovery");
            }
        }

        private void disableDiscoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = contoller.getidfromuserandpriv(username, _privilege);
            int p=contoller.DisableDiscovery(id, _privilege);
            if (p > 0)
            {
                MessageBox.Show("NO one Can see YOU NOW ;)");
            }
            else
            {
                MessageBox.Show("Error in updating discovery");
            }
        }

        private void mysessionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mysessionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_privilege == 2)
            {
   
                new sessionacticity(username,_privilege,3).Show(this); // tors is 3 cause i will be seeing a student
            }
        }

        private void teachersSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new sessionacticity(username, _privilege, 2).Show(this); // tors is 3 cause i will be seeing a teacher
        }

        private void studentSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new sessionacticity(username, _privilege, 3).Show(this); // tors is 3 cause i will be seeing a teacher

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new changepassword(username, _privilege).Show(this);
            this.Hide();
        }
        
    }
}




