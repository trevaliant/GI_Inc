using GI_Inc.DAL;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class CustomerDeactivate : Form
    {
        agent currentUser;
        int custId;

        CustomerObject customerObject = new CustomerObject();
        public CustomerDeactivate()
        {
            InitializeComponent();
            btnDelete.Enabled = false;

        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.u06P8DDataSet3);
        }

        private void CustomerDelete_Load(object sender, EventArgs e)
        {
      
            dgvCustomerList.DataSource = customerObject.getActiveCustomerList();

            dgvCustomerList.DefaultCellStyle.NullValue = false;
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int custSelected = Convert.ToInt32(dgvCustomerList.Rows[dgvCustomerList.CurrentCell.RowIndex].Cells[0].Value);

            customerObject.deactivateCustomer(custSelected);
            dgvCustomerList.DataSource = u06P8DDataSet3.customer;
            dgvCustomerList.Update();

            MessageBox.Show("Customer was deactivated");
            dgvCustomerList.Refresh();
            dgvCustomerList.DataSource = customerObject.getActiveCustomerList();


        }


        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                DialogResult deleteCustomer = MessageBox.Show("Are you sure you want to deactivate this customer? If so, click on the deactivate button option ", "Deactivate Customer", MessageBoxButtons.YesNo);

                if (deleteCustomer == DialogResult.Yes)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please choose a customer to deactivate.", "Message");
                }
            }

        }
    }
}
