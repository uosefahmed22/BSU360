using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Data.Business.Migrations
{
    public partial class initialMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobsModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyNameOrLocationArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameOrLocationEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDetailsArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDetailsEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRequirementsArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationRequirementsEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobsModelContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobsModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsModelContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsModelContacts_JobsModel_JobsModelId",
                        column: x => x.JobsModelId,
                        principalTable: "JobsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsModelEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobsModelContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsModelEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsModelEmails_JobsModelContacts_JobsModelContactsId",
                        column: x => x.JobsModelContactsId,
                        principalTable: "JobsModelContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsModelPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobsModelContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsModelPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsModelPhoneNumbers_JobsModelContacts_JobsModelContactsId",
                        column: x => x.JobsModelContactsId,
                        principalTable: "JobsModelContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsModelURLSites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobsModelContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsModelURLSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsModelURLSites_JobsModelContacts_JobsModelContactsId",
                        column: x => x.JobsModelContactsId,
                        principalTable: "JobsModelContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsModelContacts_JobsModelId",
                table: "JobsModelContacts",
                column: "JobsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsModelEmails_JobsModelContactsId",
                table: "JobsModelEmails",
                column: "JobsModelContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsModelPhoneNumbers_JobsModelContactsId",
                table: "JobsModelPhoneNumbers",
                column: "JobsModelContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsModelURLSites_JobsModelContactsId",
                table: "JobsModelURLSites",
                column: "JobsModelContactsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsModelEmails");

            migrationBuilder.DropTable(
                name: "JobsModelPhoneNumbers");

            migrationBuilder.DropTable(
                name: "JobsModelURLSites");

            migrationBuilder.DropTable(
                name: "JobsModelContacts");

            migrationBuilder.DropTable(
                name: "JobsModel");
        }
    }
}
