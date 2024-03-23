using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Data.Business.Migrations
{
    public partial class initialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertiesModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactsOfProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertiesModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsOfProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactsOfProperties_PropertiesModel_PropertiesModelId",
                        column: x => x.PropertiesModelId,
                        principalTable: "PropertiesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesAlbumUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertiesModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesAlbumUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertiesAlbumUrl_PropertiesModel_PropertiesModelId",
                        column: x => x.PropertiesModelId,
                        principalTable: "PropertiesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailsofProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactsOfPropertiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsofProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailsofProperties_ContactsOfProperties_ContactsOfPropertiesId",
                        column: x => x.ContactsOfPropertiesId,
                        principalTable: "ContactsOfProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbersOfProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactsOfPropertiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbersOfProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbersOfProperties_ContactsOfProperties_ContactsOfPropertiesId",
                        column: x => x.ContactsOfPropertiesId,
                        principalTable: "ContactsOfProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "URLSitesOfProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactsOfPropertiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLSitesOfProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLSitesOfProperties_ContactsOfProperties_ContactsOfPropertiesId",
                        column: x => x.ContactsOfPropertiesId,
                        principalTable: "ContactsOfProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactsOfProperties_PropertiesModelId",
                table: "ContactsOfProperties",
                column: "PropertiesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsofProperties_ContactsOfPropertiesId",
                table: "EmailsofProperties",
                column: "ContactsOfPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbersOfProperties_ContactsOfPropertiesId",
                table: "PhoneNumbersOfProperties",
                column: "ContactsOfPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesAlbumUrl_PropertiesModelId",
                table: "PropertiesAlbumUrl",
                column: "PropertiesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_URLSitesOfProperties_ContactsOfPropertiesId",
                table: "URLSitesOfProperties",
                column: "ContactsOfPropertiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsofProperties");

            migrationBuilder.DropTable(
                name: "PhoneNumbersOfProperties");

            migrationBuilder.DropTable(
                name: "PropertiesAlbumUrl");

            migrationBuilder.DropTable(
                name: "URLSitesOfProperties");

            migrationBuilder.DropTable(
                name: "ContactsOfProperties");

            migrationBuilder.DropTable(
                name: "PropertiesModel");
        }
    }
}
