using Invent2k.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Contexts
{
    [DbConfigurationType(typeof(EfConfig))]
    public class DataContext : DbContext
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manipulation> Manipulations { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<TechSpec> TechSpecs { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TechSpec>()
                .HasRequired(ts => ts.Item)
                .WithMany(i => i.TechSpecs)
                .HasForeignKey(ts => ts.ItemNo);

            modelBuilder.Entity<Item>()
                .HasOptional(i => i.ItemCategory)
                .WithMany()
                .HasForeignKey(i => i.ItemCategoryCode);

            modelBuilder.Entity<Manipulation>()
                .HasRequired(m => m.Item)
                .WithMany()
                .HasForeignKey(m => m.ItemNo)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Manipulation>()
                .HasOptional(m => m.Location)
                .WithMany()
                .HasForeignKey(m => m.LocationCode);
            modelBuilder.Entity<Manipulation>()
                .HasRequired(m => m.Reason)
                .WithMany()
                .HasForeignKey(m => m.ReasonCode);
            modelBuilder.Entity<Manipulation>()
                .HasOptional(m => m.Attribute)
                .WithMany()
                .HasForeignKey(m => new { m.ItemNo, m.SerialNo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Attribute>()
                .HasKey(a => new { a.ItemNo, a.SerialNo });
            modelBuilder.Entity<Models.Attribute>()
                .HasRequired(a => a.Item)
                .WithMany()
                .HasForeignKey(a => a.ItemNo);
        }
    }
}
