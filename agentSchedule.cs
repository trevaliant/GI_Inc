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
    
    public partial class agentSchedule
    {
        public int scheduleId { get; set; }
        public int agentId { get; set; }
        public string agentName { get; set; }
        public string agentDepartment { get; set; }
        public string agentTimeZone { get; set; }
        public string workDays { get; set; }
        public System.TimeSpan startTime { get; set; }
        public System.TimeSpan endTime { get; set; }
    }
}
