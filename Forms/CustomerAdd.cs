using GI_Inc.BusinessMethods;
using GI_Inc.DAL;
using System;
using System.Windows.Forms;

namespace GI_Inc.Forms
{
    public partial class CustomerAdd : Form
    {
        agent currentUser;
        public CustomerAdd(agent user)
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool pass = validCustomer();
            if (pass)
            {


                customer customer = new customer();

                customer.customerName = txtName.Text;
                customer.address = txtAddress.Text;
                customer.address2 = txtAddress2.Text;
                customer.city = txtCity.Text;
                customer.state = txtState.Text;
                customer.postalCode = txtPostalCode.Text;
                customer.phone = txtPhone.Text;
                customer.country = txtCountry.Text;
                customer.email = txtEmail.Text;
                customer.createDate = DateTime.Now;
                customer.lastUpdate = DateTime.Now;



                CustomerObject.addCustomer(customer);

                if (MessageBox.Show("Customer added successfully, would you like to add another customer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MainForm customerAdd = new MainForm();
                    customerAdd.Show();
                    Hide();
                }

                else
                {
                    ClearTextboxes(Controls);

                }
            }
        }
        void ClearTextboxes(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearTextboxes(ctrl.Controls);
            }
        }

        private bool validCustomer()
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                showError(lblName.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                showError(lblAddress.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                showError(lblCity.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                showError(lblState.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                showError(lblPostalCode.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                showError(lblPhone.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                showError(lblEmail.Text);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                showError(lblCountry.Text);
                return false;
            }


            if (blankdCheck() == false)
            {
                MessageBox.Show("Please complete all Customer Information fields.");
            }

            return true;
        }

        private bool blankdCheck()
        {
            foreach (Control m in this.Controls)
            {
                if (m is TextBox)
                {
                    TextBox textBox = m as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void showError(string item)
        {
            MessageBox.Show("Please enter valid information for " + item);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CustomerAdd customerAdd = new CustomerAdd(currentUser);
            customerAdd.Show();
            Hide();

        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
