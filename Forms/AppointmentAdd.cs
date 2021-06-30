using GI_Inc.BusinessMethods;
using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AppointmentAdd : Form
    {
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";
        U06P8DEntities entities11 = new U06P8DEntities();
        CalendarObject calObj = new CalendarObject();
        public AppointmentAdd()
        {
            InitializeComponent();
            populateCustomerList();
            populateAgentList();
            cbDefaultSettings();
            dtEnd.Value = dtEnd.Value.AddMinutes(30);

        }
        public void cbDefaultSettings()
        {

            cbAppointment.SelectedItem = null;
            cbAgent.SelectedItem = null;
            cbType.Text = "--Choose--";
            cbLocation.Text = "--Choose--";
            btnSave.Enabled = false;

        }

        public void populateAgentList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string query = "SELECT agentId, concat(agentName, ' --ID#:', agentId) as Display FROM agent ";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet1 = new DataSet();

                mySqlDataAdapter.Fill(dataSet1, "Agent");
                cbAgent.ValueMember = "agentId";
                cbAgent.DisplayMember = "Display";
                cbAgent.DataSource = dataSet1.Tables["Agent"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex);
            }

        }
        public void populateCustomerList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string query = "SELECT customerId, concat(customerName, ' --ID#: ', customerId) as Display FROM customer;";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Cust");


                cbAppointment.DisplayMember = "Display";
                cbAppointment.ValueMember = "customerId";
                cbAppointment.DataSource = dataSet.Tables["cust"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex);
            }

        }

        private bool checkFields()
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



        private bool validAppointment()
        {
            if (string.IsNullOrEmpty(cbAppointment.Text))
            {
                showError(lblCustomer.Text);
                return false;
            }
            if (string.IsNullOrEmpty(cbAgent.Text))
            {
                showError(lblAgent.Text);
                return false;
            }
            if (string.IsNullOrEmpty(cbLocation.Text))
            {
                showError(lblLocation.Text);
                return false;
            }
            if (string.IsNullOrEmpty(cbType.Text))
            {
                showError(lblType.Text);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                showError(lblDescription.Text);
                return false;
            }

            if (checkFields() == false)
            {
                MessageBox.Show("Please complete all Customer Information fields.");
            }

            return true;
        }

        private void showError(string item)
        {
            MessageBox.Show("Please enter valid information for " + item);

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
            if (calObj.overlap(start, end) == true)
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


        private void cbAppointment_SelectedValueChanged_1(object sender, EventArgs e)
        {
            cbLocation.Enabled = true;
            txtDescription.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            bool pass = validAppointment();
            if (pass)
            {
                if (cbAppointment.SelectedItem != null)
                {
                    DataRowView dataRowView = cbAppointment.SelectedItem as DataRowView;
                    int custID = Convert.ToInt32(cbAppointment.SelectedValue);
                    int agentID = Convert.ToInt32(cbAgent.SelectedValue);
                    DateTime start = dtStart.Value.ToUniversalTime();
                    DateTime end = dtEnd.Value.ToUniversalTime();

                    int available = AllowedAppt(start, end);

                    switch (available)
                    {
                        case 0:
                            CalendarObject.createAppointment(custID, cbLocation.SelectedItem.ToString(), cbType.SelectedItem.ToString(), txtDescription.Text, agentID, start, end); ;
                            MessageBox.Show("Appointment has been created, press ok to go back to Dashboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }



        private void btnBackToDash_Click_1(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            AppointmentAdd appointmentAdd = new AppointmentAdd();
            appointmentAdd.Show();
            Hide();
        }

        private void AppointmentAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
