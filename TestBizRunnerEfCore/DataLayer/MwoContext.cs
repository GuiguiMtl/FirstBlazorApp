using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Config;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MwoContext : DbContext
    {

        public DbSet<MaintenanceWorkOrder> MaintenanceWorkOrders { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public MwoContext(DbContextOptions<MwoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
        }
    }
}
