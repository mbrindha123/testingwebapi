using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class pms8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Countrycode",
                table: "CountryCodes",
                newName: "CountryCodeName");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AchievementType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AchievementType");

            migrationBuilder.RenameColumn(
                name: "CountryCodeName",
                table: "CountryCodes",
                newName: "Countrycode");
        }
    }
}
