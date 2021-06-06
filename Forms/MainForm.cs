using GI_Inc.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc
{
    public partial class MainForm : Form
    {
        user currentUser;
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

        private void btnAgentSchedule_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnClientReports_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();

        }
    }
}
