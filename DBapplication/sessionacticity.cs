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
    public partial class sessionacticity : Form
    {
        
        private int ownerid;   // the id of the owner 
        private int privilage; // the privilage of the user seeing this report
        private int tors;       // the data that is shown is about student or teachers only a student can see data about teachers
        Controller controllerobj;
        public sessionacticity(string username,int priv,int tors1)
        {
            controllerobj=new Controller();
            ownerid =controllerobj.getidfromuserandpriv(username,priv) ;
            privilage = priv;
            tors = tors1;
            InitializeComponent();
            if (tors == 2)    // i will be seeing a teacher 
            {
                this.reportViewer1.Hide();

            }
            else  // i will be seeing a student
            {
                this.reportViewer2.Hide();

            }
        }

        private void sessionacticity_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Student1' table. You can move, or remove it, as needed.

            if (privilage == 2)  // i am  ateacher  then i will see statsitics about other students regarding of the tors
            {
                this.Student1TableAdapter.fillSTopenedSbytid(this.DataSet1.Student1, ownerid); //he is filling the data with the opnened session about the teacher
                // TODO: This line of code loads data into the 'DataSet1.Student' table. You can move, or remove it, as needed.

                this.StudentTableAdapter.fillSTclosedSbytid(this.DataSet1.Student, ownerid); // now filling the data with stats about closed session withs tudents

                this.reportViewer1.RefreshReport();// TODO: This line of code loads data into the 'DataSet1.S_Request_T' table. You can move, or remove it, as needed.
            }
            else if (privilage == 3)
            {
                if (tors == 2)   // he will be seeing a teacher
                {
                    this.Student1TableAdapter.fillSTopenedSbysid(this.DataSet1.Student1, ownerid); //he is filling the data with the opnened session about the teacher
                    // TODO: This line of code loads data into the 'DataSet1.Student' table. You can move, or remove it, as needed.

                    this.StudentTableAdapter.fillSTclosedSbysid(this.DataSet1.Student, ownerid); // now filling the data with stats about closed session withs tudents
                    this.reportViewer2.RefreshReport();    // TODO: This line of code loads data into the 'DataSet1.S_Request_T' table. You can move, or remove it, as needed.
                
                }
                else   // tors ==3 he will be seeing a student then SSOS implementation works here 
                {


                    this.reportViewer1.RefreshReport();

                }
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}
