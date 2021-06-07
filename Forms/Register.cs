using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class Register : Form
    {
        string connectionString = "server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D";
        private static int agentId;
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
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtUserName.Text.Length < 4 || txtPassword.Text == "" || txtPassword.Text.Length < 4)
                MessageBox.Show("Please ensure  username and password are not blank or less than 4 characters.");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Passwords do not match");
            else
            {

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
                    MessageBox.Show("Registration was successful");

                    Clear();

                }
            }

            void Clear()

            {
                txtName.Text = txtPassword.Text = txtUserName.Text = txtConfirmPassword.Text= "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();

        }
    }
}