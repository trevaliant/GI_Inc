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
    public partial class CustomerModify : Form
    {
        user currentUser;
        int custId;
        public CustomerModify(user users, int modCustId)
        {
            InitializeComponent();
            populateCustomerList();
        }
        public static List<KeyValuePair<string, object>> CustomerList;
        public void setCustomerList(List<KeyValuePair<string, object>> list)
        {
            CustomerList = list;
        }

        public static List<KeyValuePair<string, object>> getCustomerList()
        {
            return CustomerList;
        }


        private void populateCustomerList()
        {
            MySqlConnection conn = new MySqlConnection("server=wgudb.ucertify.com;user id=U06P8D;persistsecurityinfo=True;password=53688828432;database=U06P8D");

            try
            {
                string query = "SELECT customerId, concat(customerName,  ' --Id#: ', customerId) as Display FROM customer;";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Cust");
                cbCustomerName.DisplayMember = "Display";
                cbCustomerName.ValueMember = "customerId";
                cbCustomerName.DataSource = dataSet.Tables["Cust"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with populating the customer list: " + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool pass = validCustomer();
            if (pass)
            {
                try
                {

                    var list = getCustomerList();
                    IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                    dictionary["address"] = txtAddress.Text;
                    dictionary["address2"] = txtAddress2.Text;
                    dictionary["city"] = txtCity.Text;
                    dictionary["state"] = txtState.Text;
                    dictionary["postalCode"] = txtPostalCode.Text;
                    dictionary["country"] = txtCountry.Text;
                    dictionary["phone"] = txtPhone.Text;
                    dictionary["email"] = txtEmail.Text;
                    CustomerObject.updateCustomer(dictionary);
                    
                    
                    MessageBox.Show("Customer information has been updated!");
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             }
            
        }

        private bool validCustomer()
        {

            if (string.IsNullOrWhiteSpace(cbCustomerName.Text))
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

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CustomerModify customerModify = new CustomerModify(currentUser, custId);
            customerModify.Show();
            Hide();
        }

        private void cbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dataRowView = cbCustomerName.SelectedItem as DataRowView;
            int id = Convert.ToInt32(cbCustomerName.SelectedValue);
            var CustomerList = CustomerObject.getCustomerList(id);
            setCustomerList(CustomerList);

            if (cbCustomerName.SelectedIndex != -1)
            {
                txtAddress.Enabled = true;
                txtAddress2.Enabled = true;
                txtCity.Enabled = true;
                txtState.Enabled = true;
                txtCountry.Enabled = true;
                txtPostalCode.Enabled = true;
                txtPhone.Enabled = true;
                txtEmail.Enabled = true;
                populateFields(CustomerList);
            }
        }


        public void populateFields(List<KeyValuePair<string, object>> CustomerList)
        {
            cbCustomerName.Text = CustomerList.Find(kvp => kvp.Key == "customerName").Value.ToString();
            txtAddress.Text = CustomerList.Find(kvp => kvp.Key == "address").Value.ToString();
            txtAddress2.Text = CustomerList.Find(kvp => kvp.Key == "address2").Value.ToString();
            txtCity.Text = CustomerList.Find(kvp => kvp.Key == "city").Value.ToString();
            txtState.Text = CustomerList.Find(kvp => kvp.Key == "state").Value.ToString();
            txtPostalCode.Text = CustomerList.Find(kvp => kvp.Key == "postalCode").Value.ToString();
            txtCountry.Text = CustomerList.Find(kvp => kvp.Key == "country").Value.ToString();
            txtPhone.Text = CustomerList.Find(kvp => kvp.Key == "phone").Value.ToString();
            txtEmail.Text = CustomerList.Find(kvp => kvp.Key == "email").Value.ToString();

        }
    }
}
