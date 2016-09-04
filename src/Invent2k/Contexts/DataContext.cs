using Invent2k.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Contexts
{
    public class DataContext : DbContext
    {

        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manipulation> Manipulations { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<TechSpec> TechSpecs { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=(local);Database=Invent2k;Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(i => i.TrackLocation)
                .HasDefaultValue(false);
            modelBuilder.Entity<Item>()
                .Property(i => i.TrackSerial)
                .HasDefaultValue(false);
            modelBuilder.Entity<Item>()
                .Property(i => i.TrackLot)
                .HasDefaultValue(false);
            modelBuilder.Entity<Item>()
                .HasMany<Manipulation>()
                .WithOne(m => m.Item)
                .HasForeignKey(m => m.ItemNo)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();     

            modelBuilder.Entity<TechSpec>()
                .HasOne(ts => ts.Item)
                .WithMany(i => i.TechSpecs)
                .HasForeignKey(ts => ts.ItemNo)
                .IsRequired();

            modelBuilder.Entity<Manipulation>()
                .Property(m => m.Date)
                .HasDefaultValue(DateTime.Today);
            modelBuilder.Entity<Manipulation>()
                .HasOne(m => m.Location)
                .WithMany()
                .HasForeignKey(m => m.LocationCode);
            modelBuilder.Entity<Manipulation>()
                .HasOne(m => m.Reason)
                .WithMany()
                .HasForeignKey(m => m.ReasonCode)
                .IsRequired();

            modelBuilder.Entity<Models.Attribute>()
                .HasKey(a => new { a.ItemNo, a.SerialNo });
            modelBuilder.Entity<Models.Attribute>()
                .HasOne(a => a.Item)
                .WithMany()
                .HasForeignKey(a => a.ItemNo);
            modelBuilder.Entity<Models.Attribute>()
                .HasMany<Manipulation>()
                .WithOne(m => m.Attribute);
            
            modelBuilder.Entity<ItemCategory>()
                .HasMany<Item>()
                .WithOne(i => i.ItemCategory)
                .HasForeignKey(i => i.ItemCategoryCode)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
