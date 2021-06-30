using GI_Inc.DAL;
using GI_Inc.Forms;
using GI_Inc.Forms.ApptReports;
using GI_Inc.Forms.CustReports;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc
{
    public partial class MainForm : Form
    {
        
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";
        private BindingSource bindingSource1 = new BindingSource();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TimeZoneInfo currentTime = TimeZoneInfo.Local;
            DataTable dt = new DataTable();
            TimeZoneInfo loginTime1 = TimeZoneInfo.Local;
            dgvApptList.DataSource = bindingSource1;
            getData("SELECT appointment.customerId As Customer, type AS Type, appointment.start AS Start, appointment.agentId AS AgentID, agent.agentName AS Agent FROM appointment JOIN agent ON appointment.agentId = agent.agentId WHERE start BETWEEN NOW() AND DATE_ADD(NOW(), INTERVAL 7 day) order by appointment.start");
        }
        readonly agent currentUser;
        private readonly int customerId;

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
            CustomerDeactivate customerDelete = new CustomerDeactivate();
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
            AppointmentDeactivate appointmentDelete = new AppointmentDeactivate();
            appointmentDelete.Show();
            Hide();
        }



        private void btnAgentSchedules_Click(object sender, EventArgs e)
        {
            AgentByDept agentSchedule = new AgentByDept();
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
            CustReportDashboard custRport = new CustReportDashboard();
            custRport.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void getData(string selectCommand)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(selectCommand, conn);
            MySqlCommandBuilder cmb = new MySqlCommandBuilder(da);
            DataTable dt = new DataTable
            {
                Locale = System.Globalization.CultureInfo.InvariantCulture
            };
            da.Fill(dt);
            bindingSource1.DataSource = dt;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
