using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class pms5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportingPersonId",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "ReportingPersonUsername",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportingPersonUsername",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "ReportingPersonId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
