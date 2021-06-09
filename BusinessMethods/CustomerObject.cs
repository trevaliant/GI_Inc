
using GI_Inc.DataSources;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GI_Inc.BusinessMethods
{
    public class CustomerObject
    {
        private static int agentID;
        private static string userName;
        string username;
        MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
        U06P8DEntities entities = new U06P8DEntities();
        public CustomerObject(string username)
        {
            this.username = username;
        }
        public CustomerObject()
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


        public int verifyUser(user userInfo)
        {
            int agentID = -1;

            string returnedUserName;
            string returnedPassword;

            try
            {
                conn.Open();
                MySqlCommand checkUserNameCmd = conn.CreateCommand();
                checkUserNameCmd.CommandText = "SELECT EXISTS(SELECT userName FROM user WHERE userName = @userName)";
                checkUserNameCmd.Parameters.AddWithValue("@userName", userInfo.userName);
                returnedUserName = checkUserNameCmd.ExecuteScalar().ToString();

                MySqlCommand checkPasswordCmd = conn.CreateCommand();
                checkPasswordCmd.CommandText = "SELECT EXISTS(SELECT password FROM user WHERE password = @password AND userName = @userName)";
                checkPasswordCmd.Parameters.AddWithValue("@password", userInfo.password);
                checkPasswordCmd.Parameters.AddWithValue("@userName", userInfo.userName);
                returnedPassword = checkPasswordCmd.ExecuteScalar().ToString();


                if (returnedUserName == "1" && returnedPassword == "1")
                {
                    MySqlCommand returnUserIdCmd = conn.CreateCommand();
                    returnUserIdCmd.CommandText = "SELECT userId FROM user WHERE  password = @password AND userName = @userName";
                    returnUserIdCmd.Parameters.AddWithValue("@password", userInfo.password);
                    returnUserIdCmd.Parameters.AddWithValue("@userName", userInfo.userName);
                    agentID = (int)returnUserIdCmd.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception thrown verifying user: " + ex);
            }
            finally
            {
                conn.Close();
            }

            return agentID;
        }
        public static DateTime getDateTime()
        {
            return DateTime.Now.ToUniversalTime();

        }
        public List<appointment> getAllAppointmentsForACustomer(int customerID)
        {
            var appointment = entities.appointments.Where(a => a.customerId == customerID);
            return appointment.ToList();
        }

        public CustomerInfo getCustomerInfo(int customerId)
        {
            conn.Open();
            CustomerInfo customerInfo = new CustomerInfo();
            string query = "SELECT customer.customerId, customer.customerName, customer.address, customer.address2, customer.city, customer.state, customer.postalCode, customer.phone, customer.country, customer.email FROM customer";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@customerId", customerId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())

                {
                    customerInfo.customerId = reader.GetInt32(reader["customerId"].ToString());
                    customerInfo.customerName = reader["customerName"].ToString();
                    customerInfo.address = reader["address"].ToString();
                    customerInfo.address2 = reader["address2"].ToString();
                    customerInfo.city = reader["city"].ToString();
                    customerInfo.state = reader["state"].ToString();
                    customerInfo.postalCode = reader["postalCode"].ToString();
                    customerInfo.phone = reader["phone"].ToString();
                    customerInfo.country = reader["country"].ToString();
                    customerInfo.email = reader["email"].ToString();

                }
                conn.Close();

            }
            return customerInfo;
        }
        public bool saveCustomerObject(CustomerInfo customerInfo)
        {
            bool success = false;
            try
            {
                conn.Open();
                string updateObject = "UPDATE customer SET customerName = @customerName WHERE customerId = @customerId, " +
                                      "address = @address, address2 = @address2, city = @city, state = @state, postalCode = @postalCode, phone = @phone, country=@country, email=@email";



                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = updateObject;
                cmd.Parameters.AddWithValue("@customerId", customerInfo.customerId);
                cmd.Parameters.AddWithValue("@customerName", customerInfo.customerName);
                cmd.Parameters.AddWithValue("@address", customerInfo.address);
                cmd.Parameters.AddWithValue("@address2", customerInfo.address2);
                cmd.Parameters.AddWithValue("@city", customerInfo.city);
                cmd.Parameters.AddWithValue("@state", customerInfo.state);
                cmd.Parameters.AddWithValue("@postalCode", customerInfo.postalCode);
                cmd.Parameters.AddWithValue("@phone", customerInfo.phone);
                cmd.Parameters.AddWithValue("@country", customerInfo.country);
                cmd.Parameters.AddWithValue("@email", customerInfo.email);

                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer Object not saved: ", ex.Message);
                success = false;
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public DataTable getCustomers()
        {
            DataTable customersDataTable = new DataTable();
            try
            {


                if (!customersDataTable.Columns.Contains("customerId")) { customersDataTable.Columns.Add("customerId", typeof(int)); }
                if (!customersDataTable.Columns.Contains("customerName")) { customersDataTable.Columns.Add("customerName", typeof(string)); }
                if (!customersDataTable.Columns.Contains("address")) { customersDataTable.Columns.Add("address", typeof(string)); }
                if (!customersDataTable.Columns.Contains("address2")) { customersDataTable.Columns.Add("address2", typeof(string)); }
                if (!customersDataTable.Columns.Contains("city")) { customersDataTable.Columns.Add("city", typeof(string)); }
                if (!customersDataTable.Columns.Contains("postalCode")) { customersDataTable.Columns.Add("postalCode", typeof(string)); }
                if (!customersDataTable.Columns.Contains("phone")) { customersDataTable.Columns.Add("phone", typeof(string)); }
                if (!customersDataTable.Columns.Contains("country")) { customersDataTable.Columns.Add("country", typeof(string)); }
                if (!customersDataTable.Columns.Contains("email")) { customersDataTable.Columns.Add("email", typeof(string)); }

                conn.Open();
                string query = "SELECT customer.customerId, customer.customerName,customer.address, customer.address2, customer.city, customer.state, customer.phone, customer.postalCode,  customer.country, customer.email FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customersDataTable.Rows.Add(reader["customerId"], reader["customerName"], reader["address"],
                            reader["address2"], reader["city"], reader["state"], reader["postalCode"], reader["phone"], reader["country"], reader["email"]);
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

        public static void addCustomer(customer customer)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO customer(customerName, active, address, address2, city, state, postalCode, country, phone, email)" +
                    " VALUES(@customerName, @active, @address, @address2, @city, @state, @postalCode, @country, @phone, @email)";
                cmd.Parameters.AddWithValue("@customerName", customer.customerName);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.Parameters.AddWithValue("@address", customer.address);
                cmd.Parameters.AddWithValue("@address2", customer.address2);
                cmd.Parameters.AddWithValue("@city", customer.city);
                cmd.Parameters.AddWithValue("@state", customer.state);
                cmd.Parameters.AddWithValue("@postalCode", customer.postalCode);
                cmd.Parameters.AddWithValue("@country", customer.country);
                cmd.Parameters.AddWithValue("@phone", customer.phone);
                cmd.Parameters.AddWithValue("@email", customer.email);


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

            conn.Open();

            string query = "SELECT (select customerName from customer where customerId = appointment.customerId) as 'Customer',  start as 'Start', end as 'End', type as 'Type' FROM appointment where appointment.agentId = agentId order by start; ";
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


        public bool deleteCustomer(int custSelected)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM customer WHERE customerId = @customerId";
                cmd.Parameters.AddWithValue("@customerId", custSelected);
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
        public static int getID(string table, string id)
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            conn.Open();
            var query = $"SELECT max({id}) FROM {table}";
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

        public static void updateCustomer(IDictionary<string, object> dictionary)
        {
            int customerId = getCustomerId();

            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
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
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
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
    }


}

