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
  
    public partial class MySpots : Form
    {
        int back;
        
        private int privillege;
        private string ownerusername;
        Controller controllerobj;

        public MySpots(string username, int priv)
        {
            
            back = 0;
            ownerusername = username;
            privillege = priv;
            InitializeComponent();
            controllerobj = new Controller();
            updateCOURSES();
        }

        public void updateCOURSES()
        {


            DataTable dt = null;
                if (privillege == 2)
                {
                    int id = controllerobj.getidfromuserandpriv(ownerusername, privillege);
                   dt= controllerobj.getallspotsofteacher(id);
                }
                else if (privillege == 3)
                {
                    int id = controllerobj.getidfromuserandpriv(ownerusername, privillege);
                   dt=  controllerobj.getallspotsofstudent(id);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                if (dt == null)
                {
                    label1.Text = "NO SPOTS REGISTERED";
                }
                else
                {
                    label1.Text = "MY SPOTS :";
                }
            }

        private void BACK_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back = 1;
            this.Close();
        }

        private void MyCourses_FormClosed(object sender, FormClosedEventArgs e)
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

        private void ADD_Click(object sender, EventArgs e)
        {
            int id = controllerobj.getidfromuserandpriv(ownerusername, privillege);
            new AddSpots(privillege, id, ownerusername).Show(this);
            this.Hide();
            
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            int id1=controllerobj.getidfromuserandpriv(ownerusername, privillege);
            string s = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            int r = controllerobj.DeleteSpots(s, s1, privillege, id1);
            if (r > 0)
            {
                MessageBox.Show("Spot Deleted Successfully!!");
            }
            else
            {
                MessageBox.Show("Error(104) You May Have Deleted this Spot Before.Press Refresh");
            }
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCOURSES();
        }



    }
}

