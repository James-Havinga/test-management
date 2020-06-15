using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_managment.Data.Migrations
{
    public partial class changedDateCreatedForTestAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTested",
                table: "TestAllocations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TestAllocations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "DetailsTestTypeVM",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TestAllocations");

            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "DetailsTestTypeVM");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTested",
                table: "TestAllocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
