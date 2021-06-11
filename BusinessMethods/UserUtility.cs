
using GI_Inc.DataSources;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GI_Inc.BusinessMethods
{
    public partial class UserUtility
    {

        private const string connectionString = "server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D";
        string username;
        private static int agentID;
        private static string userName;
        U06P8DEntities11 entities = new U06P8DEntities11();
        public UserUtility(string username)
        {
            this.username = username;
        }

        public UserUtility()
        {

        }
        public static int getCurrentUserId()
        {
            return agentID;
        }

        public static void setCurrentUserId(int currentUserId)
        {
            agentID = currentUserId;
        }

        public static string getCurrentUserName()
        {
            return userName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            userName = currentUserName;
        }
        static public string convertToTimezone(string dateTime)
        {
            DateTime utcDateTime = DateTime.Parse(dateTime.ToString());
            DateTime localDateTime = utcDateTime.ToLocalTime();

            return localDateTime.ToString("MM/dd/yyyy hh:mm tt");
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

        public DataTable schedule(int agentShift)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * from agent where agent.agentName = agentName order by agentId";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            DataTable datatable = new DataTable();
            datatable.Load(cmd.ExecuteReader());


            conn.Close();
            return datatable;
        }

        public string getUserNameById(int dataId)
        {
            var user = entities.agents.FirstOrDefault(a => a.agentId == dataId);
            return user.agentName;

        }





    }
}
