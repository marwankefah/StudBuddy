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
    public partial class Ratenum : Form
    {
        private int ownerid;
        private int id;
        Controller controllerobj;
        private int open;
        public Ratenum(int owner,int id1,int open1)
        {
            open = open1;
            ownerid = owner;
            id = id1;
            InitializeComponent();
            controllerobj = new Controller();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Error (342) Choose a rating number");
                return;
            }
            else
            {
                
                if (open == 0)//student rate student
                {
                    controllerobj.updateratedstudent(ownerid, id);
                    int r=controllerobj.insertratingss(ownerid, id, Convert.ToInt16(comboBox1.SelectedItem));
                    if (r <= 0)
                    {

                        MessageBox.Show("Error(928) You Rated this Person before");
                        return;
                    }
                }
                else if (open == 1)//student rate teacher
                {
                    controllerobj.updateratedteacher(id, ownerid);
                    int r=controllerobj.insertratingts(id, ownerid,  Convert.ToInt16(comboBox1.SelectedItem),0);
                    if (r <= 0)
                    {

                        MessageBox.Show("Error(928) You Rated this Person before");
                        return;
                    }
                }
                else //teacher rate student
                {
                    controllerobj.updateratedteacher(ownerid, id);
                   int r= controllerobj.insertratingts( ownerid, id, Convert.ToInt16(comboBox1.SelectedItem),1);
                   if (r <= 0)
                   {

                       MessageBox.Show("Error(928) You Rated this Person before");
                       return;
                   }
                }
                MessageBox.Show("Rated Successfully!!");
            }
        }
    }
}
