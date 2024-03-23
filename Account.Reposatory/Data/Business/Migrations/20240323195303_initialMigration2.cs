using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Data.Business.Migrations
{
    public partial class initialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumUrls_ServicesProviderd_ServicesProviderdModelId",
                table: "AlbumUrls");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ServicesProviderd_ServicesProviderdModelId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_ServicesProviderd_ServicesProviderdModelId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_ServicesProviderdModelId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ServicesProviderdModelId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_AlbumUrls_ServicesProviderdModelId",
                table: "AlbumUrls");

            migrationBuilder.DropColumn(
                name: "ServicesProviderdModelId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "ServicesProviderdModelId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ServicesProviderdModelId",
                table: "AlbumUrls");

            migrationBuilder.CreateTable(
                name: "ServiceProviderAlbumUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesProviderdModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAlbumUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderAlbumUrl_ServicesProviderd_ServicesProviderdModelId",
                        column: x => x.ServicesProviderdModelId,
                        principalTable: "ServicesProviderd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicesProviderdModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderContacts_ServicesProviderd_ServicesProviderdModelId",
                        column: x => x.ServicesProviderdModelId,
                        principalTable: "ServicesProviderd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderHoliday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicesProviderdModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderHoliday_ServicesProviderd_ServicesProviderdModelId",
                        column: x => x.ServicesProviderdModelId,
                        principalTable: "ServicesProviderd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderEmails_ServiceProviderContacts_ServiceProviderContactsId",
                        column: x => x.ServiceProviderContactsId,
                        principalTable: "ServiceProviderContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPhoneNumbers_ServiceProviderContacts_ServiceProviderContactsId",
                        column: x => x.ServiceProviderContactsId,
                        principalTable: "ServiceProviderContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderURLSites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderURLSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderURLSites_ServiceProviderContacts_ServiceProviderContactsId",
                        column: x => x.ServiceProviderContactsId,
                        principalTable: "ServiceProviderContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAlbumUrl_ServicesProviderdModelId",
                table: "ServiceProviderAlbumUrl",
                column: "ServicesProviderdModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderContacts_ServicesProviderdModelId",
                table: "ServiceProviderContacts",
                column: "ServicesProviderdModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderEmails_ServiceProviderContactsId",
                table: "ServiceProviderEmails",
                column: "ServiceProviderContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderHoliday_ServicesProviderdModelId",
                table: "ServiceProviderHoliday",
                column: "ServicesProviderdModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPhoneNumbers_ServiceProviderContactsId",
                table: "ServiceProviderPhoneNumbers",
                column: "ServiceProviderContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderURLSites_ServiceProviderContactsId",
                table: "ServiceProviderURLSites",
                column: "ServiceProviderContactsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceProviderAlbumUrl");

            migrationBuilder.DropTable(
                name: "ServiceProviderEmails");

            migrationBuilder.DropTable(
                name: "ServiceProviderHoliday");

            migrationBuilder.DropTable(
                name: "ServiceProviderPhoneNumbers");

            migrationBuilder.DropTable(
                name: "ServiceProviderURLSites");

            migrationBuilder.DropTable(
                name: "ServiceProviderContacts");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesProviderdModelId",
                table: "Holidays",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesProviderdModelId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesProviderdModelId",
                table: "AlbumUrls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_ServicesProviderdModelId",
                table: "Holidays",
                column: "ServicesProviderdModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ServicesProviderdModelId",
                table: "Contacts",
                column: "ServicesProviderdModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumUrls_ServicesProviderdModelId",
                table: "AlbumUrls",
                column: "ServicesProviderdModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumUrls_ServicesProviderd_ServicesProviderdModelId",
                table: "AlbumUrls",
                column: "ServicesProviderdModelId",
                principalTable: "ServicesProviderd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ServicesProviderd_ServicesProviderdModelId",
                table: "Contacts",
                column: "ServicesProviderdModelId",
                principalTable: "ServicesProviderd",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_ServicesProviderd_ServicesProviderdModelId",
                table: "Holidays",
                column: "ServicesProviderdModelId",
                principalTable: "ServicesProviderd",
                principalColumn: "Id");
        }
    }
}
