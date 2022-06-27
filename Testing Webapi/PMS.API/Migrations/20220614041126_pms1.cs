using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class pms1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportingPerson",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProfileStatus",
                table: "profile");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByHRId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportingPersonId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileStatusId",
                table: "profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    HRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.HRId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_CreatedByHRId",
                table: "users",
                column: "CreatedByHRId");

            migrationBuilder.CreateIndex(
                name: "IX_profile_ProfileStatusId",
                table: "profile",
                column: "ProfileStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_ProfileStatuss_ProfileStatusId",
                table: "profile",
                column: "ProfileStatusId",
                principalTable: "ProfileStatuss",
                principalColumn: "ProfileStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_HR_CreatedByHRId",
                table: "users",
                column: "CreatedByHRId",
                principalTable: "HR",
                principalColumn: "HRId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profile_ProfileStatuss_ProfileStatusId",
                table: "profile");

            migrationBuilder.DropForeignKey(
                name: "FK_users_HR_CreatedByHRId",
                table: "users");

            migrationBuilder.DropTable(
                name: "HR");

            migrationBuilder.DropIndex(
                name: "IX_users_CreatedByHRId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_profile_ProfileStatusId",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "CreatedByHRId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ReportingPersonId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProfileStatusId",
                table: "profile");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportingPerson",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileStatus",
                table: "profile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
