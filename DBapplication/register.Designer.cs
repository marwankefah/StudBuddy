namespace DBapplication
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.faculty = new System.Windows.Forms.ComboBox();
            this.college = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.ComboBox();
            this.age = new System.Windows.Forms.NumericUpDown();
            this.lastname = new System.Windows.Forms.TextBox();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.password1 = new System.Windows.Forms.TextBox();
            this.username1 = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.priceperhour = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.district = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.phonen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.age)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceperhour)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 135);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Department";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Faculty";
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(386, 132);
            this.department.Margin = new System.Windows.Forms.Padding(2);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(92, 21);
            this.department.TabIndex = 37;
            this.department.SelectedIndexChanged += new System.EventHandler(this.department_SelectedIndexChanged);
            // 
            // faculty
            // 
            this.faculty.FormattingEnabled = true;
            this.faculty.Location = new System.Drawing.Point(214, 132);
            this.faculty.Margin = new System.Windows.Forms.Padding(2);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(92, 21);
            this.faculty.TabIndex = 36;
            this.faculty.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // college
            // 
            this.college.FormattingEnabled = true;
            this.college.Location = new System.Drawing.Point(47, 132);
            this.college.Margin = new System.Windows.Forms.Padding(2);
            this.college.Name = "college";
            this.college.Size = new System.Drawing.Size(92, 21);
            this.college.TabIndex = 35;
            this.college.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 132);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "College";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Email";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(145, 81);
            this.email.Margin = new System.Windows.Forms.Padding(2);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(331, 20);
            this.email.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Gender";
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.gender.Location = new System.Drawing.Point(48, 80);
            this.gender.Margin = new System.Windows.Forms.Padding(2);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(57, 21);
            this.gender.TabIndex = 30;
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(385, 50);
            this.age.Margin = new System.Windows.Forms.Padding(2);
            this.age.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.age.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(90, 20);
            this.age.TabIndex = 29;
            this.age.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(230, 46);
            this.lastname.Margin = new System.Windows.Forms.Padding(2);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(106, 20);
            this.lastname.TabIndex = 28;
            this.lastname.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(63, 42);
            this.firstname.Margin = new System.Windows.Forms.Padding(2);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(102, 20);
            this.firstname.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Register as:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(260, 4);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Teacher";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(157, 4);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Student";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 275);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 33);
            this.button1.TabIndex = 40;
            this.button1.Text = "signup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password1
            // 
            this.password1.Location = new System.Drawing.Point(74, 228);
            this.password1.Margin = new System.Windows.Forms.Padding(2);
            this.password1.Name = "password1";
            this.password1.Size = new System.Drawing.Size(76, 20);
            this.password1.TabIndex = 41;
            this.password1.UseSystemPasswordChar = true;
            // 
            // username1
            // 
            this.username1.Location = new System.Drawing.Point(74, 179);
            this.username1.Margin = new System.Windows.Forms.Padding(2);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(76, 20);
            this.username1.TabIndex = 42;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(9, 179);
            this.username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(53, 13);
            this.username.TabIndex = 43;
            this.username.Text = "username";
            this.username.Click += new System.EventHandler(this.label10_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(11, 230);
            this.password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(52, 13);
            this.password.TabIndex = 44;
            this.password.Text = "password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 181);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "price per hour";
            // 
            // priceperhour
            // 
            this.priceperhour.Location = new System.Drawing.Point(246, 181);
            this.priceperhour.Margin = new System.Windows.Forms.Padding(2);
            this.priceperhour.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.priceperhour.Name = "priceperhour";
            this.priceperhour.Size = new System.Drawing.Size(90, 20);
            this.priceperhour.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 185);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "City";
            // 
            // city
            // 
            this.city.FormattingEnabled = true;
            this.city.Location = new System.Drawing.Point(388, 183);
            this.city.Margin = new System.Windows.Forms.Padding(2);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(92, 21);
            this.city.TabIndex = 49;
            this.city.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(344, 232);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "District";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // district
            // 
            this.district.FormattingEnabled = true;
            this.district.Location = new System.Drawing.Point(388, 230);
            this.district.Margin = new System.Windows.Forms.Padding(2);
            this.district.Name = "district";
            this.district.Size = new System.Drawing.Size(92, 21);
            this.district.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(169, 232);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "phone";
            // 
            // phonen
            // 
            this.phonen.Location = new System.Drawing.Point(214, 228);
            this.phonen.Margin = new System.Windows.Forms.Padding(2);
            this.phonen.Name = "phonen";
            this.phonen.Size = new System.Drawing.Size(123, 20);
            this.phonen.TabIndex = 53;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 355);
            this.Controls.Add(this.phonen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.district);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.city);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.priceperhour);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.username1);
            this.Controls.Add(this.password1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.department);
            this.Controls.Add(this.faculty);
            this.Controls.Add(this.college);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.age);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.age)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceperhour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.ComboBox faculty;
        private System.Windows.Forms.ComboBox college;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.NumericUpDown age;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password1;
        private System.Windows.Forms.TextBox username1;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown priceperhour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox city;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox district;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox phonen;
    }
}