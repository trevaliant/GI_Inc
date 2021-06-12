using GI_Inc.DAL;
using GI_Inc.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc.Forms.AppointmentReports
{
    public struct AppointmentReportTypes    
    {
        public string Month;
        public string appointmentType;
        public int quantity;

    }
    public partial class AppointmentTypes : Form
    {
        agent currentUser;
        public AppointmentTypes()
        {
            InitializeComponent();
        }

        private void AppointmentTypes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet2.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.u06P8DDataSet2.appointment);
            txtApptTypes.Text = "Number of Appointments Per Month  \r\n\r\n";
            string[] Months = new string[] { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };

            foreach (string month in Months)
            {
                txtApptTypes.Text = txtApptTypes.Text + month + "\r\n";
                int numSales = 0;
                int numTech = 0;

                foreach (var row in from DataRow row in u06P8DDataSet2.appointment.Rows
                                    where month == Months[((DateTime)row["start"]).Month - 1]
                                    select row)
                {
                    if (row["type"].ToString() == "Sales")
                    {
                        numSales++;
                    }
                    if (row["type"].ToString() == "Technical")
                    {
                        numTech++;
                    }
                }
                txtApptTypes.Text = txtApptTypes.Text + "\tTechnical\t\t" + numTech + "\r\n" +
                    "\tSales\t\t" + numSales + "\r\n";
                txtApptTypes.Select(0, 0);
            }
        }

        private void appointmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DDataSet2);

        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }
    }
}
