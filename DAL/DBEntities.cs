using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GI_Inc.DAL
{
    public partial class DBEntities:DbContext  
    {
        public DBEntities()
            : base()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<appointment> Appointments { get; set; }
        public virtual DbSet<agent> Agents { get; set; }
        public virtual DbSet<customer> Customers { get; set; }

    }
}
