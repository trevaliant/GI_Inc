using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc.DAL
{
    public partial class appointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public System.DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public System.DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        public int agentId { get; set; }
        public string title { get; set; }
        public decimal salesAmount { get; set; }
    }
}
