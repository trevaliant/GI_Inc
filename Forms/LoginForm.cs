using GI_Inc.BusinessMethods;
using GI_Inc.Properties.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

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
            User userInfo = new User(txtUsername.Text, txtPassword.Text);
            userInfo.userId = userUtility.verifyUser(userInfo);

            if (userInfo.userId != -1)
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
                lblError.Text = "User credentials were not correct, press reset to try again!";
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
            string type = dictionary["type"].ToString();
            DateTime? nextAppt = Convert.ToDateTime(dictionary["start"]);
            string name = dictionary["customerName"].ToString();
            if (currentTime != null && nextAppt != null)
            {
                DateTime dateTime = currentTime.Value;
                DateTime dateTime2 = nextAppt.Value;
                string dateString = nextAppt.Value.ToString("h:mm tt");
                TimeSpan difference = dateTime2.Subtract(dateTime);
                if (difference.Minutes < 15)
                {
                    MessageBox.Show("ALERT: There is a " + type + " appointment coming up at " + dateString + " with " + name + "!");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
