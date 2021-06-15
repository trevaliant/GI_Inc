using GI_Inc.BusinessMethods;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AppointmentModify : Form

    {
        public static List<KeyValuePair<string, object>> getAppts;
        public void setAppointList(List<KeyValuePair<string, object>> list)
        {
            getAppts = list;
        }

        public static List<KeyValuePair<string, object>> getAppointList()
        {
            return getAppts;
        }
        public AppointmentModify()
        {
            InitializeComponent();
            populateCustList();
            cbDefaultSettings();
        }

        public void cbDefaultSettings()
        {
            cbCustomer.SelectedItem = null;
            cbCustomer.Text = "--Choose--";
            cbAppointment.Enabled = false;
            //txtAgent.Enabled = false;
            txtType.Enabled = false;
            txtDescription.Enabled = false;
            txtLocation.Enabled = false;
            dtStart.Enabled = false;
            dtEnd.Enabled = false;
            btnSave.Enabled = false;
        }


        public void populateCustList()
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            try
            {
                string query = "SELECT customer.customerId, customer.customerName, concat(customerName, ' --ID#: ', customer.customerId) AS Display FROM customer INNER JOIN appointment ON customer.customerId = appointment.customerId";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Cust");
                cbCustomer.DisplayMember = "Display";
                cbCustomer.ValueMember = "customerId";
                cbCustomer.DataSource = dataSet.Tables["Cust"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with populating the customer list: " + ex);
            }
        }


        public void populateApptList()
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
            string offsetUTC = (TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).ToString().Substring(0, 6));
            try
            {
                string query = $"SELECT appointmentId, concat(type, ' -- ',  DATE_FORMAT(CONVERT_TZ(start, '+00:00', '{offsetUTC}'), '%M %D %Y %r')) " +
                    $"as DISPLAY FROM appointment WHERE customerId = '{cbCustomer.SelectedValue}' ;";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Appt");
                cbAppointment.DisplayMember = "DISPLAY";
                cbAppointment.ValueMember = "appointmentId";
                cbAppointment.DataSource = dataSet.Tables["Appt"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with populating the appointment list: " + ex);
            }
        }


        //this is needed to populate the fields when appt is changed    
        public void popFields(List<KeyValuePair<string, object>> ApptList)
        {
            //txtAgent.Text = ApptList.Find(kvp => kvp.Key == "agentId").Value.ToString();
            txtLocation.Text = ApptList.Find(kvp => kvp.Key == "location").Value.ToString();
            txtType.Text = ApptList.Find(kvp => kvp.Key == "type").Value.ToString();
            string start = ApptList.Find(kvp => kvp.Key == "start").Value.ToString();
            string end = ApptList.Find(kvp => kvp.Key == "end").Value.ToString();
            dtStart.Value = Convert.ToDateTime(start).ToLocalTime();
            dtEnd.Value = Convert.ToDateTime(end).ToLocalTime();
        }
        private void cbCustomer_SelectedValueChanged_1(object sender, EventArgs e)
        {
            populateApptList();
            //cbAppointment.Enabled = true;
            //txtAgent.Enabled = false;
            //txtLocation.Enabled = false;
            //txtType.Enabled = false;
            //txtDescription.Visible = false;
            //dtStart.Visible = false;
            //dtEnd.Visible = false;
            //btnSave.Visible = false;
        }
        private void cbAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dataRowView = cbAppointment.SelectedItem as DataRowView;
            int id = Convert.ToInt32(cbAppointment.SelectedValue);
            var ApptList = CalendarObject.getAppointmentList(id);
            setAppointList(ApptList);

            if (cbAppointment.SelectedIndex != -1)
            {
                //txtAgent.Enabled = true;
                txtType.Enabled = true;
                dtStart.Enabled = true;
                dtEnd.Enabled = true;
                btnSave.Enabled = true;
                cbAppointment.Enabled = true;
                cbAppointment.Text = null;
                txtDescription.Enabled = true;
                txtLocation.Enabled = true;
                cbCustomer.Enabled = true;
                popFields(ApptList);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool pass = CheckFields();

            if (pass == true)
            {
                try
                {
                    DateTime start = dtStart.Value.ToUniversalTime();
                    DateTime end = dtEnd.Value.ToUniversalTime();
                    int available = AllowedAppt(start, end);
                    switch (available)
                    {
                        case 0:
                            var list = getAppointList();
                            //lambda expression to convert the appointment list to a dictionary
                            IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                            dictionary["appointmentId"] = cbAppointment.SelectedValue;
                            dictionary["customerId"] = cbCustomer.SelectedValue;
                            dictionary["description"] = txtDescription.Text;
                            dictionary["location"] = txtLocation.Text;
                            dictionary["type"] = txtType.Text;
                            dictionary["start"] = dtStart.Value;
                            dictionary["end"] = dtEnd.Value;
                            //dictionary["agentName"] = txtAgent.Text;
                            CalendarObject.updateAppointment(dictionary);


                            MessageBox.Show("Customer appointment has been modified!");
                            MainForm mf = new MainForm();
                            mf.Show();
                            Close();
                            break;
                        case 1:
                            MessageBox.Show("You have chosen an appointment outside of business hours. Please choose between 8am and 5pm."); ;
                            break;
                        case 2:
                            MessageBox.Show("You have chosen an overlapping appointment time.");
                            break;
                        case 3:
                            MessageBox.Show("The appointment start is after the end time.");
                            break;
                        case 4:
                            MessageBox.Show("The appointments start and end date are on different dates.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (pass == false)
            {
                MessageBox.Show("Please enter a value for all fields.");
            }
        }

        private bool CheckFields()
        {
            foreach (Control ac in this.Controls)
            {
                if (ac is TextBox)
                {
                    TextBox textBox = ac as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int AllowedAppt(DateTime start, DateTime end)
        {
            DateTime firstStart = start.ToLocalTime();
            DateTime lastStart = end.ToLocalTime();
            DateTime SOD = DateTime.Today.AddHours(8);
            DateTime EOD = DateTime.Today.AddHours(17);

            if (firstStart.TimeOfDay < SOD.TimeOfDay || lastStart.TimeOfDay > EOD.TimeOfDay)
            {
                return 1;
            }
            if (CalendarObject.overlap(start, end) > 0)
            {
                return 2;
            }
            if (firstStart.TimeOfDay > lastStart.TimeOfDay)
            {
                return 3;
            }
            if (firstStart.Date != lastStart.Date)
            {
                return 4;
            }
            return 0;
        }
    private void button1_Click(object sender, EventArgs e)
    {
        string searchValue = txtSearchAgent.Text;
        dgvAgent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        try
        {
            foreach (DataGridViewRow row in dgvAgent.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(searchValue))
                {
                    row.Selected = true;

                    break;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            AppointmentModify appointmentMod = new AppointmentModify();
            appointmentMod.Show();
            Hide();
        }
    }
}
