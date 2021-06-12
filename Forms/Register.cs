using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class Register : Form
    {
        string connectionString = "server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D";
        private static int agentId;
        private static string userName;

        public Register()
        {
            InitializeComponent();
        }
        public static int getAgentId()
        {
            return agentId;
        }

        public static void setAgentId(int currentAgentId)
        {
            agentId = currentAgentId;
        }
        public static bool CheckUserData(string userName)
        {
            string sql = @"SELECT * FROM agent WHERE userName = @userName";
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.HasRows)
                    {
                        return true;  // data exist
                    }
                    else
                    {
                        return false; //data not exist
                    }
                }
            
        }

        public static int getAgentID(string table, string id)
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            conn.Open();
            var query = $"SELECT max({agentId}) FROM agent";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr[0] == DBNull.Value)
                {

                    return 0;
                }
                return Convert.ToInt32(rdr[0]); ;
            }

            return 0;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true;
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(txtName, "First and Last Name");

            ToolTip  toolTip2 = new ToolTip();
            toolTip2.Active = true;
            toolTip2.IsBalloon = true;
            toolTip2.SetToolTip(cbDepartment, "Choose item from dropdown");

            ToolTip toolTip3 = new ToolTip();
            toolTip3.Active = true;
            toolTip3.IsBalloon = true;
            toolTip3.SetToolTip(cbCountry, "Choose item from dropdown");

            ToolTip toolTip4 = new ToolTip();
            toolTip4.Active = true;
            toolTip4.IsBalloon = true;
            toolTip4.SetToolTip(cbTimezone, "Choose item from dropdown"); 
            
            ToolTip toolTip5 = new ToolTip();
            toolTip5.Active = true;
            toolTip5.IsBalloon = true;
            toolTip5.SetToolTip(txtPassword, "Min. 4 characters");

            ToolTip toolTip6 = new ToolTip();
            toolTip6.Active = true;
            toolTip6.IsBalloon = true;
            toolTip6.SetToolTip(txtConfirmPassword, "Must match initial password");

            ToolTip toolTip7 = new ToolTip();
            toolTip7.Active = true;
            toolTip7.IsBalloon = true;
            toolTip7.SetToolTip(txtUserName, "First Initial, Last Name");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                 if (txtUserName.Text == "" || txtUserName.Text.Length < 4 || txtPassword.Text == "" || txtPassword.Text.Length < 4)
                    MessageBox.Show("Please ensure  username and password are not blank or less than 4 characters.");
                else if (txtPassword.Text != txtConfirmPassword.Text)
                    MessageBox.Show("Passwords do not match");
                else
                {
                    bool CheckUserData = false;
                    if (CheckUserData)
                    {
                        MessageBox.Show("That username is already in use, please choose another");
                    }

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        int AgentID = getAgentID("agent", "agentId") + 1;

                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("AddUser", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@agentId", agentId);
                        cmd.Parameters.AddWithValue("@agentName", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@agentDepartment", cbDepartment.SelectedItem);
                        cmd.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@agentTimeZone", cbTimezone.SelectedItem);
                        cmd.Parameters.AddWithValue("@agentCountry", cbCountry.SelectedItem);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration was successful, click the 'Login Button' to log in!");

                        Clear();

                    }
                }

                void Clear()

                {
                txtName.Text = txtPassword.Text = txtUserName.Text = txtConfirmPassword.Text = "";
                cbTimezone.SelectedItem = cbDepartment.SelectedItem = cbCountry.SelectedItem = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void btnLoginForm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            Hide();
        }
    }
}