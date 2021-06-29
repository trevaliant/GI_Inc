using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class AgentByDept : Form
    {
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";
        U06P8DEntities u06P8DEntities = new U06P8DEntities();

        public AgentByDept()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }


        private void agentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.agentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DAgentDept);
            

        }

        private void AgentByDept_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                var query = "SELECT agentId, agentName, agentDepartment FROM agent WHERE active = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAgent.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue occurred when returning agent list: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int agentSelected = Convert.ToInt32(dgvAgent.Rows[dgvAgent.CurrentCell.RowIndex].Cells[0].Value);
            agentDeactivate(agentSelected);
            dgvAgent.DataSource = u06P8DAgentDept.agent;
            dgvAgent.Update();

            MessageBox.Show("Agent was deactivated");
            AgentByDept agentByDept = new AgentByDept();
            agentByDept.Show();
            Hide();
        }


        public bool agentDeactivate(int agentSelected)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE agent SET active = 0 WHERE agentId = {agentSelected}";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue occurred when deactivating agent: " + ex);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        private void dgvAgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                DialogResult deactivateAgent = MessageBox.Show("Are you sure you want to deactivate this agent? If so, click on the deactivate button option ", "Deactivate Agent", MessageBoxButtons.YesNo);

                if (deactivateAgent == DialogResult.Yes)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please choose an agent to deactivate.", "Message");
                }
            }
        }
    }
}
