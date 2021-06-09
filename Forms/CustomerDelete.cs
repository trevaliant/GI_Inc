using GI_Inc.DataSources;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class CustomerDelete : Form
    {
        user currentUser;
        int custId;
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
            DialogResult deleteCustomer = MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer", MessageBoxButtons.YesNo);

            if (deleteCustomer == DialogResult.Yes)
            {


                MessageBox.Show("To delete customer, click on the delete button option");
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
    }
}
