using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{

    public partial class ReportPicker : Form
    {
        private string agentName;
        public ReportPicker()
        {
            InitializeComponent();
        }
        public ReportPicker(string agentName)
        {
            this.agentName = agentName;
            InitializeComponent();
        }
        private void goToReports(int reports)
        {
            ReportSelector report = new ReportSelector(agentName, reports);
            report.Show();
            Close();
        }
        private void btnApptTypeReport_Click(object sender, EventArgs e)
        {
            goToReports(0);
        }
        private void btnConsultantSchedules_Click(object sender, EventArgs e)
        {
            goToReports(1);
        }
        private void btnCustomerAppts_Click(object sender, EventArgs e)
        {
            goToReports(2);
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
