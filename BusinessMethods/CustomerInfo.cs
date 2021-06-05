using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc.BusinessMethods
{
    public class CustomerInfo
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public CustomerInfo()
        {

        }
        public CustomerInfo(string _customerName, string _address, string _address2, string _city, string _state, string _postalCode, string _phone, string _country, string _email)
        {
            customerName = _customerName;
            address = _address;
            address2 = _address2;
            city = _city;
            state = _state;
            postalCode = _postalCode;
            phone = _phone;
            country = _country;
            email = _email;
        }
    }
}
