using GI_Inc.DataSources;
using GI_Inc.Forms;
using GI_Inc.Forms.ApptReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc
{
    public partial class MainForm : Form
    {
        agent currentUser;
        int customerId;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TimeZoneInfo currentTime = TimeZoneInfo.Local;
            DataTable dt = new DataTable();
            TimeZoneInfo loginTime1 = TimeZoneInfo.Local;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerAdd customerAdd = new CustomerAdd(currentUser);
            customerAdd.Show();
            Hide();

        }

        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            CustomerModify customerModify = new CustomerModify(currentUser, customerId);
            customerModify.Show();
            Hide();

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            CustomerDelete customerDelete = new CustomerDelete();
            customerDelete.Show();
            Hide();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentAdd appointmentAdd = new AppointmentAdd();
            appointmentAdd.Show();
            Hide();
        }

        private void btnModifyAppointment_Click(object sender, EventArgs e)
        {
            AppointmentModify appointmentModify = new AppointmentModify();
            appointmentModify.Show();
            Hide();

        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            AppointmentDelete appointmentDelete = new AppointmentDelete();
            appointmentDelete.Show();
            Hide();
        }



        private void btnAgentSchedules_Click(object sender, EventArgs e)
        {
            AgentSchedule agentSchedule = new AgentSchedule();
            agentSchedule.Show();
            Hide();
        }

        private void btnApptReports_Click(object sender, EventArgs e)
        {
            ApptReportDashboard dashboard = new ApptReportDashboard();
            dashboard.Show();
            Hide();
        }

        private void btnCustomerReports_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
