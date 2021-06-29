using System;
using System.Windows.Forms;

namespace GI_Inc.Forms.CustReports
{
    public partial class CustReportDashboard : Form
    {
        public CustReportDashboard()
        {
            InitializeComponent();
        }

        private void btnCustByState_Click(object sender, EventArgs e)
        {
            CustomerByState byState = new CustomerByState();
            byState.Show();
            Hide();
        }

        private void btnCustEmails_Click(object sender, EventArgs e)
        {
            CustomerEmail email = new CustomerEmail();
            email.Show();
            Hide();
        }

        private void btnNewCust_Click(object sender, EventArgs e)
        {
            NewCustomers newCustomers = new NewCustomers();
            newCustomers.Show();
            Hide();
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }
    }
}
