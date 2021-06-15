﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GI_Inc.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class U06P8DEntities1 : DbContext
    {
        public U06P8DEntities1()
            : base("name=U06P8DEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<agent> agents { get; set; }
        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<customer> customers { get; set; }
    
        public virtual int AddUser(Nullable<int> agentId, string agentName, string agentDepartment, string agentTimeZone, string agentCountry, string userName, string password)
        {
            var agentIdParameter = agentId.HasValue ?
                new ObjectParameter("agentId", agentId) :
                new ObjectParameter("agentId", typeof(int));
    
            var agentNameParameter = agentName != null ?
                new ObjectParameter("agentName", agentName) :
                new ObjectParameter("agentName", typeof(string));
    
            var agentDepartmentParameter = agentDepartment != null ?
                new ObjectParameter("agentDepartment", agentDepartment) :
                new ObjectParameter("agentDepartment", typeof(string));
    
            var agentTimeZoneParameter = agentTimeZone != null ?
                new ObjectParameter("agentTimeZone", agentTimeZone) :
                new ObjectParameter("agentTimeZone", typeof(string));
    
            var agentCountryParameter = agentCountry != null ?
                new ObjectParameter("agentCountry", agentCountry) :
                new ObjectParameter("agentCountry", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", agentIdParameter, agentNameParameter, agentDepartmentParameter, agentTimeZoneParameter, agentCountryParameter, userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<AgentSchedule_Result> AgentSchedule()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AgentSchedule_Result>("AgentSchedule");
        }
    }
}
