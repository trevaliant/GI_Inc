using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc.DAL
{
    public partial class customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public bool active { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public System.DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public System.DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        public string email { get; set; }
    }
}
