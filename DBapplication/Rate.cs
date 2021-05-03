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
    public partial class Rate : Form
    {
        private int priv;
        private int ownerid;
        Controller controllerobj;
        public Rate(int id,int pri)
        {
            ownerid = id;
            priv = pri;
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.selectratings(ownerid);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "username";
            listBox1.ValueMember = "Rated";

            DataTable dt3 = controllerobj.selectratingsstudent(ownerid);
            listBox3.DataSource = dt3;
            listBox3.DisplayMember = "username";
            listBox3.ValueMember = "Student-ID";

            DataTable dt2 = controllerobj.selectratingsteacher(ownerid);
            listBox2.DataSource = dt2;
            listBox2.DisplayMember = "username";
            listBox2.ValueMember = "Teacher-ID";
            
            if (priv == 3)
            {
                listBox2.Show();
                tlabel.Show();
                listBox1.Show();
                listBox3.Hide();
                update();
                
            }
            else if (priv == 2)
            {
                listBox3.Show();
                listBox1.Hide();
                listBox2.Hide();
                tlabel.Hide();
                updatet();
            }
        }
        private void update()
        {
            
           DataTable dt = controllerobj.selectratings(ownerid);
            listBox1.DataSource = dt;
            listBox1.DisplayMember="username";
            listBox1.ValueMember = "Rated";
            listBox1.Refresh();
            
            DataTable dt2 = controllerobj.selectratingsteacher(ownerid);
            listBox2.DataSource = dt2;
            listBox2.DisplayMember="username";
            listBox2.ValueMember = "Teacher-ID";
            listBox2.Refresh();

        }
        private void updatet()
        {
            DataTable dt = controllerobj.selectratingsstudent(ownerid);
            listBox3.DataSource = dt;
            listBox3.DisplayMember = "username";
            listBox3.ValueMember = "Student-ID";
            listBox3.Refresh();

        }

        private void Rate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                new Ratenum(ownerid, Convert.ToInt16(listBox1.SelectedValue),0).Show(this);//student rate student

            }
        }

      

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_DoubleClick_1(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                new Ratenum(ownerid, Convert.ToInt16(listBox3.SelectedValue), 2).Show(this);//teacher rate student

            }
        }

        private void listBox2_DoubleClick_1(object sender, EventArgs e)
        {
           
         
            if (listBox2.SelectedValue!=null)
            {
                new Ratenum(ownerid, Convert.ToInt16(listBox2.SelectedValue), 1).Show(this);//student rate teacher

            }
        }

    }
}
