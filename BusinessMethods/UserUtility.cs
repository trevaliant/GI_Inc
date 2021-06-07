using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc.BusinessMethods
{
    public partial class UserUtility
    {

        private const string connectionString = "server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D";

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

        public static List<KeyValuePair<string, object>> getAgentApptList(int agentId)
        {
            var agentApptList = new List<KeyValuePair<string, object>>();
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
            conn.Open();
            var query = $"SELECT * FROM appointment WHERE agentId = {agentId}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    agentApptList.Add(new KeyValuePair<string, object>("appointmentId", reader[0]));
                    agentApptList.Add(new KeyValuePair<string, object>("customerId", reader[1]));
                    agentApptList.Add(new KeyValuePair<string, object>("description", reader[3]));
                    agentApptList.Add(new KeyValuePair<string, object>("location", reader[4]));
                    agentApptList.Add(new KeyValuePair<string, object>("type", reader[5]));
                    agentApptList.Add(new KeyValuePair<string, object>("start", reader[6]));
                    agentApptList.Add(new KeyValuePair<string, object>("end", reader[7]));
                    agentApptList.Add(new KeyValuePair<string, object>("agentId", reader[12]));
                    agentApptList.Add(new KeyValuePair<string, object>("title", reader[13]));
                    reader.Close();
                }
                else
                {
                    return null;
                }
                return agentApptList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable schedule(string agentId)
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            conn.Open();

            string query = "select c.customerName, a.start, a.end, a.agentId, ag.agentName from appointment a JOIN customer c on c.customerId = a.customerId Join agent ag on ag.agentId = a.agentId order by start; ";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            DataTable datatable = new DataTable();
            datatable.Load(cmd.ExecuteReader());

            foreach (DataRow row in datatable.Rows)
            {
                DateTime utcStart = Convert.ToDateTime(row["start"]);
                DateTime utcEnd = Convert.ToDateTime(row["end"]);

                row["Start"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                row["End"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);

            }

            conn.Close();
            return datatable;
        }
    }
}
