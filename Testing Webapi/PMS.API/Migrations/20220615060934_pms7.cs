using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class pms7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    CountryCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Countrycode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.CountryCodeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_CountryCodeId",
                table: "users",
                column: "CountryCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_CountryCodes_CountryCodeId",
                table: "users",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "CountryCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_CountryCodes_CountryCodeId",
                table: "users");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropIndex(
                name: "IX_users_CountryCodeId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "users");
        }
    }
}
