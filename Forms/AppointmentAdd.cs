using GI_Inc.BusinessMethods;
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
    public partial class AppointmentAdd : Form
    {
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
            cbAgent.Text = "--Choose--";
            cbAppointment.Text = "--Choose--";
            cbAppointment.Text = "--Choose--";
            cbLocation.Text   = "--Choose--";
            btnSave.Enabled = false;

        }

        public void populateAgentList()
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");
            try
            {
                string query = "SELECT agentId, concat(agentName, ' --ID#:', agentId) as Display FROM agent ";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataTable dt1 = new DataTable();

                mySqlDataAdapter.Fill(dt1);
                cbAgent.ValueMember = dt1.Columns[0].ToString();
                cbAgent.DisplayMember = "Display";
                cbAgent.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the appointment! " + ex);
            }

        }
        public void populateCustomerList()
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            try
            {
                string query = "SELECT customerId, concat(customerName, ' --ID#: ', customerId) as Display FROM customer;";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Cust");
                cbAppointment.DisplayMember = "Display";
                cbAppointment.ValueMember = "customerId";
                cbAppointment.DataSource = dataSet.Tables["Cust"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the appointment! " + ex);
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
            if (CalendarObject.overlappingAppts(start, end) == true)
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
            tbDescription.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            bool pass = checkFields();
            if (pass == true)
            {
                if (cbAppointment.SelectedItem != null)
                {
                    DataRowView dataRowView = cbAppointment.SelectedItem as DataRowView;
                    int custID = Convert.ToInt32(cbAppointment.SelectedValue);
                    DateTime start = dtStart.Value.ToUniversalTime();
                    DateTime end = dtEnd.Value.ToUniversalTime();

                    int available = AllowedAppt(start, end);
                    switch (available)
                    {
                        case 0:
                            CalendarObject.createAppointment(custID, cbType.SelectedItem.ToString(), cbLocation.SelectedItem.ToString(), start, end, cbAgent.SelectedItem.ToString()); ;
                            MessageBox.Show("Appointment has been created, press ok to go back to Dashboard.", "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            if (pass == false)
            {
                MessageBox.Show("Please enter a value for all fields.");
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


    }
}
