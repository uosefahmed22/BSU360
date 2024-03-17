using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Data.Business.Migrations
{
    public partial class initialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Businesses_BusinessModelId",
                table: "Holiday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holiday",
                table: "Holiday");

            migrationBuilder.RenameTable(
                name: "Holiday",
                newName: "Holidays");

            migrationBuilder.RenameIndex(
                name: "IX_Holiday_BusinessModelId",
                table: "Holidays",
                newName: "IX_Holidays_BusinessModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Businesses_BusinessModelId",
                table: "Holidays",
                column: "BusinessModelId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Businesses_BusinessModelId",
                table: "Holidays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays");

            migrationBuilder.RenameTable(
                name: "Holidays",
                newName: "Holiday");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_BusinessModelId",
                table: "Holiday",
                newName: "IX_Holiday_BusinessModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holiday",
                table: "Holiday",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Businesses_BusinessModelId",
                table: "Holiday",
                column: "BusinessModelId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }
    }
}
