using GI_Inc.BusinessMethods;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class ReportSelector : Form
    {
        private enum reportMode { appointment = 0, consultant = 1, customer = 2 };
        int reportmode;
        string agentName;
        CustomerObject custObj;
        UserUtility userUtility;
        public ReportSelector()
        {
            InitializeComponent();
        }
        public ReportSelector(string agentName, int report)
        {
            this.agentName = agentName;
            userUtility = new UserUtility(this.agentName);
            custObj = new CustomerObject();
            setReportMode(report);
            InitializeComponent();
        }

        private void setupElements()
        {
            string format = "MM/dd/yyyy";
            datepickerReport.CustomFormat = format;
            datepickerReport.Hide();
            cbReports.Hide();

            if (reportmode == (int)reportMode.consultant || reportmode == (int)reportMode.customer)
            {
                cbReports.Show();
                if (reportmode == (int)reportMode.consultant)
                {
          
                }
                if (reportmode == (int)reportMode.customer)
                {
                    setCbValuesToCustomer();
                }
            }
            else
            {
                datepickerReport.Show();
            }
        }

        private void setCbValuesToCustomer()
        {
            var customerList = custObj.getCustomers();
            cbReports.ValueMember = "customerId";
            cbReports.DisplayMember = "customerName";
            cbReports.DataSource = customerList;
        }



        private void setReportMode(int report)
        {
            switch (report)
            {
                case 0:
                    this.reportmode = (int)reportMode.appointment;
                    break;
                case 1:
                    this.reportmode = (int)reportMode.consultant;
                    break;
                case 2:
                    this.reportmode = (int)reportMode.customer;
                    break;

                default:
                    break;
            }
        }

        private void ReportSelector_Load(object sender, EventArgs e)
        {
            setupElements();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Reports reportForm;

            if (reportmode == (int)reportMode.consultant || reportmode == (int)reportMode.customer)
            {
                reportForm = new Reports(agentName, reportmode, (int)cbReports.SelectedValue);
            }
            else
            {
                reportForm = new Reports(agentName, reportmode, datepickerReport.Value.Month);
            }

            reportForm.Show();
            this.Close();
        }
    }
}
