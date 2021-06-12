using GI_Inc.BusinessMethods;
using GI_Inc.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GI_Inc
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            lblError.Visible = false;

        }


        //find file in bin>Debug
        public void writeToLoginFile()
        {
            StreamWriter fileName = File.AppendText("WriteLoginToFile.txt");

            DateTime loginTime = DateTime.Now;

            fileName.WriteLine(string.Format("{0} logged in on {1} at {2}", txtUsername.Text, loginTime.ToShortDateString(), loginTime.ToShortTimeString()));
            fileName.Close();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserUtility userUtility = new UserUtility();
            Agent userInfo = new Agent(txtUsername.Text, txtPassword.Text);
            userInfo.agentId = userUtility.verifyUser(userInfo);

            if (userInfo.agentId != -1)
            {
                DateTime dateTime = DateTime.Now;
                writeToLoginFile();

                MainForm mainForm = new MainForm();
                Hide();
                mainForm.Show();
                apptReminder();

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "User credentials were not correct, please select the Reset button to try again.";
                lblError.AutoSize = false;
                lblError.Dock = DockStyle.Fill;

            }
        }

        public static DateTime getTime()
        {
            return DateTime.Now.ToLocalTime();
        }
        public static void apptReminder()
        {
            var list = CalendarObject.getNextAppt();
            IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
            DateTime? currentTime = getTime();
            DateTime? nextAppt = Convert.ToDateTime(dictionary["start"]);
            string agent = dictionary["agentName"].ToString();
            string name = dictionary["customerName"].ToString();
            if (currentTime != null && nextAppt != null)
            {
                DateTime dateTime = currentTime.Value;
                DateTime dateTime2 = nextAppt.Value;
                string dateString = nextAppt.Value.ToString("h:mm tt");
                TimeSpan difference = dateTime2.Subtract(dateTime);
                if (difference.Minutes < 15)
                {
                    MessageBox.Show("ALERT: " +agent+ " has an appointment coming up at " + dateString + " with " + name + "!");
                }
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            Hide();

        }


        private void btnReset_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();

        }


    }
}
