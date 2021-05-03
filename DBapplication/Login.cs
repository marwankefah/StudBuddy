using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public enum Privileges
    {
        Admin=1,
        Others=2
    }
    public partial class Login : Form
    {
        private bool _loggedin = false;
        private Controller controllerObj; // A Reference of type Controller 
                                          // (Initially NULL; NO Controller Object is created yet)

        public Login()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

/*        //checks the username/password and returns the privlidges associated with this user
        //Returns 0 in case of error
        private int CheckPassword_Basic(string username, string password)
        {
            controllerObj = new Controller();
            return controllerObj.CheckPassword_Basic(username, password); 
            //return password == "1234";  //Password can be saved in the DB encrypted rather than being hardcoded.
                                        //Even if it is stored in a DB, keeping passwords in it's raw form is prone to attacks
        }
        
  */
        private bool CheckPassword_Hash(string password)
        {
            const string salt = "r4Nd0m_5A1t";  //They are concatenated to the password to protects against rainbow table attacks.
            HashAlgorithm algorithm = new SHA256Managed();
            string passwordandsalt = password + salt;
            string hashed = Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordandsalt)));
            return hashed == "w+0fHMgNFl7jSDJ7WpvRfIQLzfflSi9pPNdiQg+v4/E=";    //The Hash should be stored in the DB
                                                                                //Hashes needs a lot of time to be reversed (Brute Force, Dictionary Attacks, Rainbow Tables, etc.)
                                                                                //So even if they are stolen from the database, 
                                                                                //you should have enough time to notify users to change it
                                                                                //before the attacker can use them.
        }


        private void Btn_Login_Click(object sender, EventArgs e)
        {
            int privlg = controllerObj.CheckPassword_Basic(TxtBx_username.Text, TxtBx_pass.Text);
            if (privlg > 0) // Successful Login
            {
                _loggedin = true;
                // Create an Object of "Provided_Functionalities" Form and Show it

                if (privlg > 1)  // if the privlg >1 then he is a teacher or student and form of functiontalities will appear
                 {

                

                    Form1 func = new Form1(privlg,TxtBx_username.Text);
                    func.Show(this);
                    TxtBx_pass.Clear();
                    TxtBx_username.Clear();
                    // Hide the Login Form 
                    // Don't close it because it's the startup form and the application will exit
                    this.Hide();
                }
                else if (privlg == 1)
                {

             /// here the admin form is loaded 


                }
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }            
        }

        
        //private void Login_FormClosing(object sender, FormClosingEventArgs e)
        //{
            //if (e.CloseReason == CloseReason.UserClosing && !_loggedin)
              //  Owner.Show();
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void register_Click(object sender, EventArgs e)
        {
            new Register().Show();
        }

        private void TxtBx_pass_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
