using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_managment.Data.Migrations
{
    public partial class changedTestHistoriesToTestRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsTestTypeVM");

            migrationBuilder.DropTable(
                name: "TestHistories");

            migrationBuilder.CreateTable(
                name: "TestRequests",
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
                    table.PrimaryKey("PK_TestRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRequests_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequests_AspNetUsers_RequestingPatientId",
                        column: x => x.RequestingPatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRequests_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_ApprovedById",
                table: "TestRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_RequestingPatientId",
                table: "TestRequests",
                column: "RequestingPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRequests_TestTypeId",
                table: "TestRequests",
                column: "TestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestRequests");

            migrationBuilder.CreateTable(
                name: "DetailsTestTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DefaultDays = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsTestTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateActioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestingPatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestTypeId = table.Column<int>(type: "int", nullable: false)
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
    }
}
