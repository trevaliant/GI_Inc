
using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Linq;

namespace GI_Inc.BusinessMethods
{
    public partial class UserUtility
    {

        private const string connectionString = "server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D";
        string username;
        private static int agentID;
        private static string userName;
        U06P8DEntities1 u06P8DEntities1 = new U06P8DEntities1();
        public UserUtility()
        {

        }

        public int verifyUser(agent userInfo)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int agentId = -1;

            string returnedUserName;
            string returnedPassword;

            try
            {
                conn.Open();
                MySqlCommand checkUserNameCmd = conn.CreateCommand();
                checkUserNameCmd.CommandText = "SELECT EXISTS(SELECT userName FROM agent WHERE userName = @username)";
                checkUserNameCmd.Parameters.AddWithValue("@username", userInfo.userName);
                returnedUserName = checkUserNameCmd.ExecuteScalar().ToString();

                MySqlCommand checkPasswordCmd = conn.CreateCommand();
                checkPasswordCmd.CommandText = "SELECT EXISTS(SELECT password FROM agent WHERE  password = @password AND userName = @username)";
                checkPasswordCmd.Parameters.AddWithValue("@password", userInfo.password);
                checkPasswordCmd.Parameters.AddWithValue("@username", userInfo.userName);
                returnedPassword = checkPasswordCmd.ExecuteScalar().ToString();



                if (returnedUserName == "1" && returnedPassword == "1")
                {
                    MySqlCommand returnUserIdCmd = conn.CreateCommand();
                    returnUserIdCmd.CommandText = "SELECT agentId FROM agent WHERE BINARY password = @password AND userName = @username";
                    returnUserIdCmd.Parameters.AddWithValue("@password", userInfo.password);
                    returnUserIdCmd.Parameters.AddWithValue("@username", userInfo.userName);
                    agentId = (int)returnUserIdCmd.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown verifying user: " + ex);
            }
            finally
            {
                conn.Close();
            }

            return agentId;
        }

        public string getUserNameById(int dataId)
        {
            var user = u06P8DEntities1.agents.FirstOrDefault(a => a.agentId == dataId);
            return user.agentName;

        }
    }
}
