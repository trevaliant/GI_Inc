using GI_Inc.BusinessMethods;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AppointmentDeactivate : Form
    {
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";

        public AppointmentDeactivate()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }

        private void AppointmentDelete_Load(object sender, EventArgs e)
        {
            
            dgvAppointments.DataSource = populateFutureAppointments();
            dgvAppointments.DefaultCellStyle.NullValue = false;

        }

        public DataTable populateFutureAppointments()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string offsetUTC = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).ToString().Substring(0, 6);


                string query = "SELECT appointmentId AS AppointmentID, customerId AS CustomerID, description AS Description,  location AS Location, " +
                "type AS Type, start AS Start, end AS End, agentId AS AgentID FROM appointment WHERE start > now() ORDER by start";
                conn.Open();
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

        private void bthnDelete_Click(object sender, EventArgs e)
        {
            DialogResult deleteAppointment = MessageBox.Show("Are you absolutely sure you want to deactivate this appointment?", "Deactivate Appointment", MessageBoxButtons.YesNo);

            if (deleteAppointment == DialogResult.Yes)
            {
                CalendarObject calObj = new CalendarObject();
                int apptSelected = Convert.ToInt32(dgvAppointments.Rows[dgvAppointments.CurrentCell.RowIndex].Cells[0].Value);
                if (apptSelected != -1)
                {

                    calObj.deleteAppointment(apptSelected);

                    MessageBox.Show("Appointment was deactivated.");
                    AppointmentDeactivate appointmentDelete = new AppointmentDeactivate();
                    appointmentDelete.Show();
                    Hide();
                }
            }
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                DialogResult deleteAppointment = MessageBox.Show("Are you sure you want to deactivate this appointment? If so, click on the deactivate button option ", "Deactivate Appointment", MessageBoxButtons.YesNo);

                if (deleteAppointment == DialogResult.Yes)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please choose an appointment to deactivate.", "Message");
                }
            }
        }
    }
}

