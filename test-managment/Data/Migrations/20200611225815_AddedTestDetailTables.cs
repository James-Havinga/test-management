using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_managment.Data.Migrations
{
    public partial class AddedTestDetailTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTested = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAllocations_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAllocations_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingPatientId = table.Column<string>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: false),
                    TestTypeId = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    DateActioned = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestHistories_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestHistories_AspNetUsers_RequestingPatientId",
                        column: x => x.RequestingPatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestHistories_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAllocations_PatientId",
                table: "TestAllocations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAllocations_TestTypeId",
                table: "TestAllocations",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestHistories_ApprovedById",
                table: "TestHistories",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestHistories_RequestingPatientId",
                table: "TestHistories",
                column: "RequestingPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestHistories_TestTypeId",
                table: "TestHistories",
                column: "TestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAllocations");

            migrationBuilder.DropTable(
                name: "TestHistories");

            migrationBuilder.DropTable(
                name: "TestTypes");
        }
    }
}
