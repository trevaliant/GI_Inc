using GI_Inc.Forms.AppointmentReports;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms.ApptReports
{
    public partial class ApptReportDashboard : Form
    {
        public ApptReportDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentTypes appointmentTypes = new AppointmentTypes();
            appointmentTypes.Show();
            Hide();
        }

        private void btnApptsByWeek_Click(object sender, EventArgs e)
        {
            AppointmentsByWeek byWeek = new AppointmentsByWeek();
            byWeek.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppointmentSales appointmentSales = new AppointmentSales();
            appointmentSales.Show();
            Hide();
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
