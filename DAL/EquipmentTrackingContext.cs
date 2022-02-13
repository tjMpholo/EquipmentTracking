using EquipmentTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EquipmentTracking.DAL
{
    public class EquipmentTrackingContext : DbContext
    {
        public EquipmentTrackingContext() : base("EquipmentTrackingContext")
        {
            // Enabling lazy loading....
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<EquipmentClassification> EquipmentClassifications { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentMovementLog> EquipmentMovementLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}