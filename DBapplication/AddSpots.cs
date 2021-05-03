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
    public partial class AddSpots : Form
    {
        int back2;
        Controller controllerobj;
        private int privillege;
        private string username;
        private int id;
        public AddSpots(int priv,int id1,string username1)
        {
            back2 = 0;
            InitializeComponent();
            comboBox1.SelectedValue = " ";
            privillege = priv;
            username = username1;
            id = id1;
            controllerobj = new Controller();
            DataTable dt = controllerobj.SelectCities();
            comboBox1.DisplayMember = "City";
            comboBox1.ValueMember = "City";
            comboBox1.DataSource = dt;
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            Owner.Show();
            back2 = 1;
            this.Close();
        }

        private void AddSpots_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (back2 == 1)
            {
                back2 = 0;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Owner.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.SelectDistricts(comboBox1.SelectedValue.ToString());
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "District";
            comboBox2.ValueMember = "District";
        }

        private void done_Click(object sender, EventArgs e)
        {
            int r = controllerobj.insertspotpreffered(id, privillege, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
            if (r > 0)
            {
                MessageBox.Show(" Spot Inserted Successfully!!");
            }
            else
            {
                MessageBox.Show(" Error(304) Spot Already Choosed ");
            }
        }
    }
}
