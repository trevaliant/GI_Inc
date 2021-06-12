using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc.DAL
{
    public partial class agent
    {
        public int agentId { get; set; }
        public string agentName { get; set; }
        public string agentDepartment { get; set; }
        public string agentCountry { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int agentShift { get; set; }
        public string workDay1 { get; set; }
        public string workDay2 { get; set; }
        public string workDay3 { get; set; }
        public string workDay4 { get; set; }
        public string workDay5 { get; set; }
        public bool active { get; set; }
        public System.DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public System.DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }



        }
}
