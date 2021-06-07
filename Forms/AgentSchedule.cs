using GI_Inc.BusinessMethods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AgentSchedule : Form
    {



        public AgentSchedule()
        {
            InitializeComponent();
            agentList();
    
        }

        public void agentList()
        {
            MySqlConnection conn = new MySqlConnection("server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo = True; password =53688828432; database = U06P8D");

            try
            {
                var query = "select agentId, agentName as 'Display' from agent";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Agent");
                cbAgent.DisplayMember = "Display";
                cbAgent.ValueMember = "agentId";
                cbAgent.DataSource = dataSet.Tables["Agent"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void agentSchedulesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();


        }

        private void AgentSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet4.agentSchedules' table. You can move, or remove it, as needed.
            this.agentSchedulesTableAdapter.Fill(this.u06P8DDataSet5.agentSchedules);

        }


        private void cbAgent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UserUtility userUtility = new UserUtility();
            DataRowView dataRowView = cbAgent.SelectedItem as DataRowView;
            int id = Convert.ToInt32(cbAgent.SelectedValue);

            DataTable dataTable = userUtility.schedule(id.ToString());
            dgvAgentAppts.DataSource = dataTable;

        }
    }
}
