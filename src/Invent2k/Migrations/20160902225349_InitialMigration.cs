using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Invent2k.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item_categories",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    descr = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_categories", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    descr = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "reasons",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    descr = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reasons", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    no = table.Column<string>(maxLength: 10, nullable: false),
                    descr = table.Column<string>(maxLength: 50, nullable: true),
                    item_category_code = table.Column<string>(maxLength: 10, nullable: false),
                    track_location = table.Column<bool>(nullable: false, defaultValue: false),
                    track_lot = table.Column<bool>(nullable: false, defaultValue: false),
                    track_serial = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.no);
                    table.ForeignKey(
                        name: "FK_items_item_categories_item_category_code",
                        column: x => x.item_category_code,
                        principalTable: "item_categories",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    item_no = table.Column<string>(maxLength: 10, nullable: false),
                    serial_no = table.Column<string>(maxLength: 50, nullable: false),
                    mac_address = table.Column<string>(maxLength: 17, nullable: true),
                    network_name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes", x => new { x.item_no, x.serial_no });
                    table.ForeignKey(
                        name: "FK_attributes_items_item_no",
                        column: x => x.item_no,
                        principalTable: "items",
                        principalColumn: "no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tech_specs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_no = table.Column<string>(maxLength: 10, nullable: false),
                    parameter = table.Column<string>(maxLength: 20, nullable: false),
                    value = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tech_specs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tech_specs_items_item_no",
                        column: x => x.item_no,
                        principalTable: "items",
                        principalColumn: "no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manipulations",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Local)),
                    item_no = table.Column<string>(maxLength: 10, nullable: false),
                    location_code = table.Column<string>(maxLength: 10, nullable: true),
                    lot_no = table.Column<string>(maxLength: 50, nullable: true),
                    qty = table.Column<decimal>(nullable: false),
                    reason_code = table.Column<string>(maxLength: 10, nullable: false),
                    serial_no = table.Column<string>(maxLength: 50, nullable: true),
                    unit_of_measure = table.Column<short>(nullable: false),
                    user = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manipulations", x => x.id);
                    table.ForeignKey(
                        name: "FK_manipulations_items_item_no",
                        column: x => x.item_no,
                        principalTable: "items",
                        principalColumn: "no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manipulations_locations_location_code",
                        column: x => x.location_code,
                        principalTable: "locations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manipulations_reasons_reason_code",
                        column: x => x.reason_code,
                        principalTable: "reasons",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manipulations_attributes_item_no_serial_no",
                        columns: x => new { x.item_no, x.serial_no },
                        principalTable: "attributes",
                        principalColumns: new[] { "item_no", "serial_no" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attributes_item_no",
                table: "attributes",
                column: "item_no");

            migrationBuilder.CreateIndex(
                name: "IX_items_item_category_code",
                table: "items",
                column: "item_category_code");

            migrationBuilder.CreateIndex(
                name: "IX_manipulations_item_no",
                table: "manipulations",
                column: "item_no");

            migrationBuilder.CreateIndex(
                name: "IX_manipulations_location_code",
                table: "manipulations",
                column: "location_code");

            migrationBuilder.CreateIndex(
                name: "IX_manipulations_reason_code",
                table: "manipulations",
                column: "reason_code");

            migrationBuilder.CreateIndex(
                name: "IX_manipulations_item_no_serial_no",
                table: "manipulations",
                columns: new[] { "item_no", "serial_no" });

            migrationBuilder.CreateIndex(
                name: "IX_tech_specs_item_no",
                table: "tech_specs",
                column: "item_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manipulations");

            migrationBuilder.DropTable(
                name: "tech_specs");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "reasons");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "item_categories");
        }
    }
}
