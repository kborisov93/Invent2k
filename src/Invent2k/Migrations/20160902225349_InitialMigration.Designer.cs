using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Invent2k.Contexts;

namespace Invent2k.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160902225349_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Invent2k.Models.Attribute", b =>
                {
                    b.Property<string>("ItemNo")
                        .HasColumnName("item_no")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("SerialNo")
                        .HasColumnName("serial_no")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MacAddress")
                        .HasColumnName("mac_address")
                        .HasAnnotation("MaxLength", 17);

                    b.Property<string>("NetworkName")
                        .HasColumnName("network_name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ItemNo", "SerialNo");

                    b.HasIndex("ItemNo");

                    b.ToTable("attributes");
                });

            modelBuilder.Entity("Invent2k.Models.Item", b =>
                {
                    b.Property<string>("No")
                        .HasColumnName("no")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Description")
                        .HasColumnName("descr")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ItemCategoryCode")
                        .IsRequired()
                        .HasColumnName("item_category_code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool>("TrackLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("track_location")
                        .HasDefaultValue(false);

                    b.Property<bool>("TrackLot")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("track_lot")
                        .HasDefaultValue(false);

                    b.Property<bool>("TrackSerial")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("track_serial")
                        .HasDefaultValue(false);

                    b.HasKey("No");

                    b.HasIndex("ItemCategoryCode");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Invent2k.Models.ItemCategory", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Description")
                        .HasColumnName("descr")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Code");

                    b.ToTable("item_categories");
                });

            modelBuilder.Entity("Invent2k.Models.Location", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Description")
                        .HasColumnName("descr")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Code");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("Invent2k.Models.Manipulation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("date")
                        .HasDefaultValue(new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("ItemNo")
                        .IsRequired()
                        .HasColumnName("item_no")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("LocationCode")
                        .HasColumnName("location_code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("LotNo")
                        .HasColumnName("lot_no")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("Quantity")
                        .HasColumnName("qty");

                    b.Property<string>("ReasonCode")
                        .IsRequired()
                        .HasColumnName("reason_code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("SerialNo")
                        .HasColumnName("serial_no")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<short>("UnitOfMeasure")
                        .HasColumnName("unit_of_measure");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnName("user")
                        .HasAnnotation("MaxLength", 300);

                    b.HasKey("Id");

                    b.HasIndex("ItemNo");

                    b.HasIndex("LocationCode");

                    b.HasIndex("ReasonCode");

                    b.HasIndex("ItemNo", "SerialNo");

                    b.ToTable("manipulations");
                });

            modelBuilder.Entity("Invent2k.Models.Reason", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Description")
                        .HasColumnName("descr")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Code");

                    b.ToTable("reasons");
                });

            modelBuilder.Entity("Invent2k.Models.TechSpec", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemNo")
                        .IsRequired()
                        .HasColumnName("item_no")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Parameter")
                        .IsRequired()
                        .HasColumnName("parameter")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("ItemNo");

                    b.ToTable("tech_specs");
                });

            modelBuilder.Entity("Invent2k.Models.Attribute", b =>
                {
                    b.HasOne("Invent2k.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invent2k.Models.Item", b =>
                {
                    b.HasOne("Invent2k.Models.ItemCategory", "ItemCategory")
                        .WithMany()
                        .HasForeignKey("ItemCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Invent2k.Models.Manipulation", b =>
                {
                    b.HasOne("Invent2k.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemNo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Invent2k.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationCode");

                    b.HasOne("Invent2k.Models.Reason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Invent2k.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("ItemNo", "SerialNo");
                });

            modelBuilder.Entity("Invent2k.Models.TechSpec", b =>
                {
                    b.HasOne("Invent2k.Models.Item", "Item")
                        .WithMany("TechSpecs")
                        .HasForeignKey("ItemNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
