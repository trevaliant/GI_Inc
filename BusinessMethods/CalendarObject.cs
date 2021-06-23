
using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GI_Inc.BusinessMethods
{
    public class CalendarObject
    {
        private static string userName;
        string username;
        private static int agentID;
        U06P8DEntities entities = new U06P8DEntities();
        private static Dictionary<int, Hashtable> _agents = new Dictionary<int, Hashtable>();
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";

        public CalendarObject(string username)
        {
            this.username = username;
        }
        public CalendarObject()
        {

        }
        public static int getUserID()
        {
            return agentID;
        }
        public static void setUserID(int currUserID)
        {
            agentID = currUserID;
        }
        public static void setAgentID(int assignedAgent)
        {
            agentID = assignedAgent;
        }
        public static string getUserName()
        {
            return userName;
        }
        public static Dictionary<int, Hashtable> getAgentList()
        {
            return _agents;
        }

        public static void setAgentList(Dictionary<int, Hashtable> agents)
        {
            _agents = agents;
        }
        private static Dictionary<int, Hashtable> currentAppointments = new Dictionary<int, Hashtable>();
        public static Dictionary<int, Hashtable> getAppts()
        {
            return currentAppointments;
        }
        public static void setAppointments(Dictionary<int, Hashtable> appointments)
        {
            currentAppointments = appointments;
        }

        public bool deleteAppointment(int apptSelected)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);

                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                cmd.Parameters.AddWithValue("@appointmentId", apptSelected);
                cmd.Parameters.AddWithValue("@isDeleted", 1);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue occurred when deleting appointment: " + ex);
                return false;
            }

            return true;
        }

        public static int getID(string table, string id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            var query = $"SELECT max({id}) FROM {table}";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0] == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToInt32(reader[0]);
                conn.Close();
            }
            return 0;

        }

        public static void createAppointment(int custID, string location, string type, string description, int agentId, DateTime start, DateTime end)
        {
            int appointID = getID("appointment", "appointmentId") + 1;
            DateTime utc = getTime();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var query = $"INSERT into appointment (appointmentId, customerId, location, type, description, agentId,  start, end)" +
                $"VALUES ('{appointID}', '{custID}','{location}', '{type}', '{description}','{agentId}', '{DTSql(start)}', '{DTSql(end)}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Dictionary<string, object> getNextAppt()
        {
            Dictionary<string, object> nextAppt = new Dictionary<string, object>();
            string utcOffset = (TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).ToString().Substring(0, 6));
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var query = $"SELECT start, (SELECT agentName from agent where agentId = appointment.agentId) as 'Agent', (SELECT customerName from customer where customerId = appointment.customerId) as 'Customer Name' from appointment where start > now() order by start limit 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                nextAppt.Add("start", Convert.ToDateTime(reader[0]).ToLocalTime());
                nextAppt.Add("customerName", reader[1]);
                nextAppt.Add("agentName", reader[2]);
                conn.Close();
            }
            return nextAppt;

        }


        public static int overlap(DateTime start, DateTime end)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var query = $"SELECT count(*) FROM `appointment` WHERE (('{DTSql(start.ToUniversalTime())}' > start and '{DTSql(start.ToUniversalTime())}' < end) or ('{DTSql(end.ToUniversalTime())}'> start and '{DTSql(end.ToUniversalTime())}' < end)) and end > now() order by  start limit 1;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            if (reader.HasRows)
            {
                reader.Read();
                string count = reader[0].ToString();
                int result = count == "0" ? 0 : 1;
                return result;

            }
            return 0;

        }

        public static List<KeyValuePair<string, object>> getAppointmentList(int appointmentId)
        {
            var list = new List<KeyValuePair<string, object>>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var query = $"SELECT * FROM appointment WHERE appointmentId = {appointmentId}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    list.Add(new KeyValuePair<string, object>("appointmentId", reader[0]));
                    list.Add(new KeyValuePair<string, object>("customerId", reader[1]));
                    list.Add(new KeyValuePair<string, object>("description", reader[2]));
                    list.Add(new KeyValuePair<string, object>("location", reader[4]));
                    list.Add(new KeyValuePair<string, object>("type", reader[5]));
                    list.Add(new KeyValuePair<string, object>("start", reader[6]));
                    list.Add(new KeyValuePair<string, object>("end", reader[7]));
                    list.Add(new KeyValuePair<string, object>("agentId", reader[12]));
                    reader.Close();
                }
                else
                {
                    return null;
                }
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;

            }
            finally
            {
                    conn.Close();
            }
        }
        public static DateTime getTime()
        {
            return DateTime.Now.ToUniversalTime();
        }

        public static string DTSql(DateTime dateValue)
        {
            string sqlDT = dateValue.ToString("yyyy-MM-dd HH:mm");
            return sqlDT;
        }
        public static void updateAppointment(IDictionary<string, object> dictionary)
        {
            string user = getUserName();
            DateTime utc = getTime();
            DateTime start = Convert.ToDateTime(dictionary["start"]);
            DateTime end = Convert.ToDateTime(dictionary["end"]);

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            var query = $"UPDATE appointment SET appointmentID = '{dictionary["appointmentId"]}', customerId = '{dictionary["customerId"]}', description = '{dictionary["description"]}',  location = '{dictionary["location"]}', type = '{dictionary["type"]}',  start = '{DTSql(start.ToUniversalTime())}', end = '{DTSql(end.ToUniversalTime())}',  agentId = '{dictionary["agentId"]}' WHERE appointmentId = '{dictionary["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

        }

    }
}
