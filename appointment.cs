//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GI_Inc
{
    using System;
    using System.Collections.Generic;
    
    public partial class appointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        public int agentId { get; set; }
    }
}
