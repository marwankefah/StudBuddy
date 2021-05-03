namespace DBapplication
{
    partial class Form1
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
            this.notification = new System.Windows.Forms.Button();
            this.mycourses = new System.Windows.Forms.Button();
            this.mysession = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSpotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowDiscoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableDiscoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysessionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Search = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notification
            // 
            this.notification.Location = new System.Drawing.Point(73, 84);
            this.notification.Name = "notification";
            this.notification.Size = new System.Drawing.Size(140, 23);
            this.notification.TabIndex = 0;
            this.notification.Text = "notification";
            this.notification.UseVisualStyleBackColor = true;
            this.notification.Click += new System.EventHandler(this.button1_Click);
            // 
            // mycourses
            // 
            this.mycourses.Location = new System.Drawing.Point(73, 123);
            this.mycourses.Name = "mycourses";
            this.mycourses.Size = new System.Drawing.Size(140, 23);
            this.mycourses.TabIndex = 1;
            this.mycourses.Text = "mycourses";
            this.mycourses.UseVisualStyleBackColor = true;
            this.mycourses.Click += new System.EventHandler(this.button2_Click);
            // 
            // mysession
            // 
            this.mysession.Location = new System.Drawing.Point(73, 202);
            this.mysession.Name = "mysession";
            this.mysession.Size = new System.Drawing.Size(140, 23);
            this.mysession.TabIndex = 2;
            this.mysession.Text = "my session";
            this.mysession.UseVisualStyleBackColor = true;
            this.mysession.Click += new System.EventHandler(this.mysession_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.mysessionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editProfileToolStripMenuItem,
            this.discoveryToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // editProfileToolStripMenuItem
            // 
            this.editProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.addSpotsToolStripMenuItem});
            this.editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            this.editProfileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editProfileToolStripMenuItem.Text = "Account";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // addSpotsToolStripMenuItem
            // 
            this.addSpotsToolStripMenuItem.Name = "addSpotsToolStripMenuItem";
            this.addSpotsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addSpotsToolStripMenuItem.Text = "Edit profile info";
            this.addSpotsToolStripMenuItem.Click += new System.EventHandler(this.editProfileToolStripMenuItem_Click);
            // 
            // discoveryToolStripMenuItem
            // 
            this.discoveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowDiscoveryToolStripMenuItem,
            this.disableDiscoveryToolStripMenuItem});
            this.discoveryToolStripMenuItem.Name = "discoveryToolStripMenuItem";
            this.discoveryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.discoveryToolStripMenuItem.Text = "Discovery";
            // 
            // allowDiscoveryToolStripMenuItem
            // 
            this.allowDiscoveryToolStripMenuItem.Name = "allowDiscoveryToolStripMenuItem";
            this.allowDiscoveryToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.allowDiscoveryToolStripMenuItem.Text = "Allow Discovery";
            this.allowDiscoveryToolStripMenuItem.Click += new System.EventHandler(this.allowDiscoveryToolStripMenuItem_Click);
            // 
            // disableDiscoveryToolStripMenuItem
            // 
            this.disableDiscoveryToolStripMenuItem.Name = "disableDiscoveryToolStripMenuItem";
            this.disableDiscoveryToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.disableDiscoveryToolStripMenuItem.Text = "Disable Discovery";
            this.disableDiscoveryToolStripMenuItem.Click += new System.EventHandler(this.disableDiscoveryToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // mysessionToolStripMenuItem
            // 
            this.mysessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mysessionToolStripMenuItem1});
            this.mysessionToolStripMenuItem.Name = "mysessionToolStripMenuItem";
            this.mysessionToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.mysessionToolStripMenuItem.Text = "Activity Log";
            this.mysessionToolStripMenuItem.Click += new System.EventHandler(this.mysessionToolStripMenuItem_Click);
            // 
            // mysessionToolStripMenuItem1
            // 
            this.mysessionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teachersSessionsToolStripMenuItem,
            this.studentSessionsToolStripMenuItem});
            this.mysessionToolStripMenuItem1.Name = "mysessionToolStripMenuItem1";
            this.mysessionToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.mysessionToolStripMenuItem1.Text = "Mysessions";
            this.mysessionToolStripMenuItem1.Click += new System.EventHandler(this.mysessionToolStripMenuItem1_Click);
            // 
            // teachersSessionsToolStripMenuItem
            // 
            this.teachersSessionsToolStripMenuItem.Name = "teachersSessionsToolStripMenuItem";
            this.teachersSessionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.teachersSessionsToolStripMenuItem.Text = "Teachers Sessions";
            this.teachersSessionsToolStripMenuItem.Click += new System.EventHandler(this.teachersSessionsToolStripMenuItem_Click);
            // 
            // studentSessionsToolStripMenuItem
            // 
            this.studentSessionsToolStripMenuItem.Name = "studentSessionsToolStripMenuItem";
            this.studentSessionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.studentSessionsToolStripMenuItem.Text = "Student Sessions";
            this.studentSessionsToolStripMenuItem.Click += new System.EventHandler(this.studentSessionsToolStripMenuItem_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(73, 41);
            this.Search.Margin = new System.Windows.Forms.Padding(2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(140, 20);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 162);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "myspots";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.mysession);
            this.Controls.Add(this.mycourses);
            this.Controls.Add(this.notification);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button notification;
        private System.Windows.Forms.Button mycourses;
        private System.Windows.Forms.Button mysession;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSpotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowDiscoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableDiscoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem mysessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysessionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem teachersSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentSessionsToolStripMenuItem;
    }
}