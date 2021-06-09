using GI_Inc.BusinessMethods;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AppointmentDelete : Form
    {

        public AppointmentDelete()
        {
            InitializeComponent();
        }

        private void AppointmentDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet2.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.u06P8DDataSet2.appointment);


        }

        private void bthnDelete_Click(object sender, EventArgs e)
        {
            DialogResult deleteAppointment = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo);

            if (deleteAppointment == DialogResult.Yes)
            {
                CalendarObject calObj = new CalendarObject();
                int apptSelected = Convert.ToInt32(dgvAppointments.Rows[dgvAppointments.CurrentCell.RowIndex].Cells[0].Value);
                if (apptSelected != -1)
                {

                    calObj.deleteAppointment(apptSelected);

                    MessageBox.Show("Appointment was deleted.");
                    AppointmentDelete appointmentDelete = new AppointmentDelete();
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
    }
}

