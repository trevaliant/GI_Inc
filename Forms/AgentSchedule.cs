using GI_Inc.BusinessMethods;
using System;
using System.Collections;
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
        }

        private void AgentSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet6.agent' table. You can move, or remove it, as needed.
            this.agentTableAdapter.Fill(this.u06P8DDataSet6.agent);

        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
