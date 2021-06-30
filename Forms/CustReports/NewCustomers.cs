using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms.CustReports
{
    public partial class NewCustomers : Form
    {
        MySqlConnection conn = new MySqlConnection("server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo = True; password =53688828432; database = U06P8D");
        DataTable dt = new DataTable();
        public NewCustomers()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(7);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var query = "SELECT customerId AS CustomerID, customerName AS Name, createDate AS Date_Created, createdBy AS Agent FROM `customer` WHERE `createDate` BETWEEN @start and @end order by createdDate";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvNewCustomers.DataSource = dt;

            if (dateTimePicker2.Value >= dateTimePicker1.Value)
            {
                return;
            }
            else
            {
                MessageBox.Show("End date cannot be equal to or before start date, please select again!");
            }
            conn.Close();
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
    }
}
