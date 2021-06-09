using GI_Inc.BusinessMethods;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class Reports : Form
    {
        private enum reportMode { appointment = 0, consultant = 1, customer = 2 };
        string username;
        int reportmode;
        int dataId;
        DateTime monthData;
        CalendarObject calendarObject;
        CustomerObject customerObject;
        UserUtility userUtility;

        public Reports()
        {
            InitializeComponent();
        }

        public Reports(string username, int report, int id)
        {
            initData(username, report);
            dataId = id;
            InitializeComponent();
        }

        public Reports(string username, int report, DateTime month)
        {
            initData(username, report);
            monthData = month;
            InitializeComponent();
        }

        private void initData(string username, int report)
        {
            this.username = username;
            setReportMode(report);
            userUtility = new UserUtility(this.username);
            customerObject = new CustomerObject(this.username);
            calendarObject = new CalendarObject(this.username);

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
        private void Reports_Load(object sender, EventArgs e)
        {
            txtReportInfo.ReadOnly = true;
            if (reportmode == (int)reportMode.appointment)
            {
                mapAppointments();
            }
            if (reportmode == (int)reportMode.consultant)
            {
                mapConsultants();
            }
            if (reportmode == (int)reportMode.customer)
            {
                mapCustomers();
            }
        }

        private void mapConsultants()
        {
            var appointments = calendarObject.getAllAppointmentsForAUser(userUtility.getUserNameById(dataId));

            foreach (var a in appointments)
            {
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine + a.type;
                txtReportInfo.Text += Environment.NewLine + "Start" + a.start;
                txtReportInfo.Text += Environment.NewLine + "End" + a.end;
            }
        }

        private void mapAppointments()
        {
            var appointments = calendarObject.GetAppointmentTypeandCountByMonth(dataId);

            foreach (var a in appointments)
            {
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine + a.Type;
                txtReportInfo.Text += Environment.NewLine + "Count: " + a.Count;
            }

        }

        public void mapCustomers()
        {

            var appointments = customerObject.getAllAppointmentsForACustomer(dataId);

            foreach (var a in appointments)
            {
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine;
                txtReportInfo.Text += Environment.NewLine + a.type;
                txtReportInfo.Text += Environment.NewLine + "Start" + a.start;
                txtReportInfo.Text += Environment.NewLine + "End" + a.end;
            }
        }
    }
}
