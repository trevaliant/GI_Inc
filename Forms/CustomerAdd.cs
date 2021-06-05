using GI_Inc.BusinessMethods;
using GI_Inc.Properties.DataSources;
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
    public partial class CustomerAdd : Form
    {
        user currentUser;
        public CustomerAdd(user user)
        {
            InitializeComponent();
            currentUser = new user();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool pass = validCustomer();
            if (pass)
            {


                customer customer = new customer();

                customer.customerName = txtName.Text;
                customer.createdBy = currentUser.userName;
                customer.address = txtAddress.Text;
                customer.address2 = txtAddress2.Text;
                customer.city = txtCity.Text;
                customer.state = txtState.Text;
                customer.postalCode = txtPostalCode.Text;
                customer.phone = txtPhone.Text;
                customer.country = txtCountry.Text;
                customer.email = txtEmail.Text;


                CustomerObject.addCustomer(customer);

                if (MessageBox.Show("Customer added successfully, would you like to add another customer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CustomerAdd customerAdd = new CustomerAdd(currentUser);
                    customerAdd.Show();
                    Hide();
                }

                else
                {

                }
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
            MessageBox.Show("Please enter a valid information for " + item);

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
