using GI_Inc.BusinessMethods;
using MySql.Data.MySqlClient;

using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public struct AgentScheduleView
    {
        public string Days;
        public string Shift;
        public string Department;
    }
    public partial class AgentSchedule : Form
    {
        public AgentSchedule()
        {
            InitializeComponent();
        }




        private void AgentSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet5.agentSchedules' table. You can move, or remove it, as needed.
            this.agentSchedulesTableAdapter.Fill(this.u06P8DDataSet5.agentSchedules);

            // TODO: This line of code loads data into the 'u06P8DDataSet5.agentSchedules' table. You can move, or remove it, as needed.
            this.agentSchedulesTableAdapter.Fill(this.u06P8DDataSet5.agentSchedules);
            txtViewSchedules.Text = "Agent Schedule View \r\n\r\n";
            string[] Days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach (string day in Days)
            {
                txtViewSchedules.Text = txtViewSchedules.Text + day + "\r\n";
                int numSales = 0;
                int numTechnical = 0;

                foreach (var row in from DataRow row in u06P8DDataSet5.agentSchedules

                                    where day != null
                                    select row)
                {
                    if (row["agentDepartment"].ToString() == "Technical")
                    {
                        numTechnical++;
                    }
                    if (row["agentDepartment"].ToString() == "Sales")
                    {
                        numSales++;
                    }

                }
                txtViewSchedules.Text = txtViewSchedules.Text + "\tSales\t\t" + numSales + "\r\n" + "\tTechnical\t\t" + numTechnical;
                txtViewSchedules.Select(0, 0);
            }
        }

        private void agentSchedulesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.agentSchedulesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DDataSet5);

        }

        private void agentSchedulesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.agentSchedulesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DDataSet5);

        }
    }
}
