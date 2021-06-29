
using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc
{
    public class CustomerObject
    {

        agent currentUser;

        string username;
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";
        public CustomerObject(string username)
        {
            this.username = username;
        }
        public CustomerObject()
        {
            this.associatedAppointments = new List<appointment>();

        }
        public List<appointment> associatedAppointments { get; set; }
        public DataTable getCustomers()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            DataTable customersDataTable = new DataTable();
            try
            {
                if (!customersDataTable.Columns.Contains("customerId")) { customersDataTable.Columns.Add("customerId", typeof(int)); }
                if (!customersDataTable.Columns.Contains("customerName")) { customersDataTable.Columns.Add("customerName", typeof(string)); }
                if (!customersDataTable.Columns.Contains("active")) { customersDataTable.Columns.Add("active", typeof(bool)); }
                if (!customersDataTable.Columns.Contains("address")) { customersDataTable.Columns.Add("address", typeof(string)); }
                if (!customersDataTable.Columns.Contains("address2")) { customersDataTable.Columns.Add("address2", typeof(string)); }
                if (!customersDataTable.Columns.Contains("city")) { customersDataTable.Columns.Add("city", typeof(string)); }
                if (!customersDataTable.Columns.Contains("postalCode")) { customersDataTable.Columns.Add("postalCode", typeof(string)); }
                if (!customersDataTable.Columns.Contains("phone")) { customersDataTable.Columns.Add("phone", typeof(string)); }
                if (!customersDataTable.Columns.Contains("country")) { customersDataTable.Columns.Add("country", typeof(string)); }
                if (!customersDataTable.Columns.Contains("createDate")) { customersDataTable.Columns.Add("createDate", typeof(DateTime)); }
                if (!customersDataTable.Columns.Contains("createdBy")) { customersDataTable.Columns.Add("createdBy", typeof(string)); }
                if (!customersDataTable.Columns.Contains("lastUpdate")) { customersDataTable.Columns.Add("lastUpdate", typeof(DateTime)); }
                if (!customersDataTable.Columns.Contains("lastUpdateBy")) { customersDataTable.Columns.Add("lastUpdateBy", typeof(string)); }
                if (!customersDataTable.Columns.Contains("email")) { customersDataTable.Columns.Add("email", typeof(string)); }

                conn.Open();
                string query = "SELECT customer.customerId, customer.customerName,customer.address, customer.address2, customer.city, customer.state, customer.phone, customer.postalCode,  customer.country, customer.email FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customersDataTable.Rows.Add(reader["customerId"], reader["customerName"], reader["active"], reader["address"],
                            reader["address2"], reader["city"], reader["state"], reader["postalCode"], reader["phone"], reader["country"],
                            reader["createDate"], reader["createdBy"], reader["lastUpdate"], reader["lastUpdateBy"], reader["email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting customer: " + ex);
            }
            conn.Close();
            return customersDataTable;
        }
        public static void addCustomer(customer customer1)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO customer(customerName, active, address, address2, city, state, postalCode, country, phone, email, createDate, createdBy)" +
                    " VALUES(@customerName, @active, @address, @address2, @city, @state, @postalCode, @country, @phone, @email, @createDate, @createdBy)";
                cmd.Parameters.AddWithValue("@customerName", customer1.customerName);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.Parameters.AddWithValue("@address", customer1.address);
                cmd.Parameters.AddWithValue("@address2", customer1.address2);
                cmd.Parameters.AddWithValue("@city", customer1.city);
                cmd.Parameters.AddWithValue("@state", customer1.state);
                cmd.Parameters.AddWithValue("@postalCode", customer1.postalCode);
                cmd.Parameters.AddWithValue("@country", customer1.country);
                cmd.Parameters.AddWithValue("@phone", customer1.phone);
                cmd.Parameters.AddWithValue("@email", customer1.email);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@createdBy", "admin");

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex);
            }
        }

        public DataTable schedule(string agentID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT (select customerName from customer where customerId = appointment.customerId) as 'Customer',  start as 'Start', end as 'End', type as 'Type', agentId as 'Agent ID' FROM appointment where appointment.agentId = agentId order by start; ";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            DataTable datatable = new DataTable();
            datatable.Load(cmd.ExecuteReader());

            foreach (DataRow row in datatable.Rows)

            {
                agentID = Convert.ToString("agentId");
                DateTime utcStart = Convert.ToDateTime(row["start"]);
                DateTime utcEnd = Convert.ToDateTime(row["end"]);

                row["Start"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                row["End"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);

            }

            conn.Close();
            return datatable;
        }
        public bool deactivateCustomer(int custSelected)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE customer SET active = {0} WHERE customerId = {custSelected}";

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue occurred when deleting customer: " + ex);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public static void updateCustomer(IDictionary<string, object> dictionary)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int customerId = getCustomerId();

            conn.Open();

            var query = $"UPDATE customer SET customerName = '{dictionary["customerName"]}', " +
                $"address ='{dictionary["address"]}', address2 = '{dictionary["address2"]}', " +
                $"city = '{dictionary["city"]}', state = '{dictionary["state"]}', " +
                $"postalCode = '{dictionary["postalCode"]}', country = '{dictionary["country"]}', " +
                $"phone = '{dictionary["phone"]}', email = '{dictionary["email"]}'WHERE customerId = '{dictionary["customerId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private static int customerId;
        public static int getCustomerId()
        {
            return customerId;
        }
        public static List<KeyValuePair<string, object>> getCustomerList(int customerId)
        {
            var list = new List<KeyValuePair<string, object>>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            var query = $"SELECT * FROM customer WHERE customerId = {customerId}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    list.Add(new KeyValuePair<string, object>("customerId", reader[0]));
                    list.Add(new KeyValuePair<string, object>("customerName", reader[1]));
                    list.Add(new KeyValuePair<string, object>("address", reader[3]));
                    list.Add(new KeyValuePair<string, object>("address2", reader[4]));
                    list.Add(new KeyValuePair<string, object>("city", reader[5]));
                    list.Add(new KeyValuePair<string, object>("state", reader[6]));
                    list.Add(new KeyValuePair<string, object>("postalCode", reader[7]));
                    list.Add(new KeyValuePair<string, object>("phone", reader[8]));
                    list.Add(new KeyValuePair<string, object>("country", reader[9]));
                    list.Add(new KeyValuePair<string, object>("email", reader[14]));
                    list.Add(new KeyValuePair<string, object>("active", reader[3]));
                    reader.Close();
                    conn.Close();
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
        }

        public DataTable getActiveCustomerList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = $"SELECT * from customer WHERE active ={1}";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            DataTable datatable = new DataTable();
            datatable.Load(cmd.ExecuteReader());
            conn.Close();
            return datatable;
        }

    }

}

