using GI_Inc.BusinessMethods;
using GI_Inc.DAL;
using GI_Inc.DataSources;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class CustomerDelete : Form
    {
        agent currentUser;
        int custId;
        CustomerObject customerObject = new CustomerObject();
        public static string connectionString = "server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo=True;password=53688828432;database=U06P8D";
        public CustomerDelete()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DDataSet3);
        }

        private void CustomerDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'u06P8DDataSet3.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.u06P8DDataSet3.customer);

        }

        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult deleteCustomer = MessageBox.Show("Are you sure you want to delete this customer? If so, click on the delete button option ", "Delete Customer", MessageBoxButtons.YesNo);

            if (deleteCustomer == DialogResult.Yes)
            {
               
            }
            else
            {
                MessageBox.Show("Please choose a customer to delete.", "Message");
            }
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        //checks if customer has future appointments when deleting customer. 
        public bool checkAssociatedAppts(int custSelected)

        {   MySqlConnection conn = new MySqlConnection(connectionString);
                
                conn.Open();
                var query = $"SELECT  distinct * FROM appointment  left JOIN customer on " +
                $"DATE(appointment.start) > current_timestamp and appointment.customerId = {custSelected}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var associatedAppts = cmd.ExecuteNonQuery();
                conn.Close();

            if (associatedAppts == 1)
                return true;
            else
                return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int custSelected = Convert.ToInt32(dgvCustomerList.Rows[dgvCustomerList.CurrentCell.RowIndex].Cells[0].Value);
            if (custSelected >=0)
            {
                checkAssociatedAppts(custSelected);
                MessageBox.Show("This customer has appointments, please delete those first before deleteing the customer.");
            }
            else
            {
                customerObject.deleteCustomer(custSelected);
                dgvCustomerList.DataSource = u06P8DDataSet3.customer;

                MessageBox.Show("Customer was deleted");
            }    
        }

        private void customerBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
