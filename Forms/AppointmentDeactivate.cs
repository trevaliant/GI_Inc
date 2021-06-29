using GI_Inc.BusinessMethods;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AppointmentDeactivate : Form
    {

        public AppointmentDeactivate()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }

        private void AppointmentDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet2.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.u06P8DDataSet2.appointment);
            dgvAppointments.DefaultCellStyle.NullValue = false;

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

