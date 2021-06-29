using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms.CustReports
{
    public partial class CustomerByState : Form
    {
        MySqlConnection conn = new MySqlConnection("server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo = True; password =53688828432; database = U06P8D");

        public CustomerByState()
        {
            InitializeComponent();
        }

        private void btnBackToCustRep_Click(object sender, EventArgs e)
        {
            CustReportDashboard custReportDashboard = new CustReportDashboard();
            custReportDashboard.Show();
            Hide();
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void CustomerByState_Load(object sender, EventArgs e)
        {
            var query = "SELECT customerId, customerName, city, state FROM customer";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvCustByState.DataSource = dt;
            conn.Close();
        }
    }
}
