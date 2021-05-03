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
    public partial class viewinfo : Form
    {
        Controller controllerObj;
        private string requesterusername;
        private int priv;
        private int id;
        private string username;
        private int courseid;
        public viewinfo(int priv1,int id1,string username1,string requesterid1,int courseid1)
        {
            courseid = courseid1;
            priv = priv1;
            id = id1;
            username = username1;
            requesterusername=requesterid1;
            InitializeComponent();
            controllerObj = new Controller();
            collegename.Text = controllerObj.SelectCollege(priv,id);
            facultyname.Text = controllerObj.SelectFaculty(priv, id);
            departmentname.Text = controllerObj.SelectDepartment(priv, id);
            city.Text = controllerObj.SelectCity(priv, id);
            district.Text = controllerObj.SelectDistrict(priv, id);
            name.Text = controllerObj.SelectName(priv, id);
            gender.Text = controllerObj.SelectGender(priv, id);
            age.Text = controllerObj.SelectAge(priv, id).ToString();
            if (priv == 2)
            {
                price.Text = controllerObj.SelectPrice(id).ToString();
            }
            else
            {
                price.Hide();
                label2.Hide();
            }
            score.Text = controllerObj.SelectRating(priv, id).ToString();







        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void request_Click(object sender, EventArgs e)
        {
               int iduser=controllerObj.getidfromuserandpriv(requesterusername, 3);
            int r=  controllerObj.Request(iduser, id,courseid,priv);
            if (r > 0)
                MessageBox.Show("Request Sent successfully");
            else
                MessageBox.Show("Error(204): Error Sending Request, you may have requested this request before");


            this.Close();
        }
    }
}
