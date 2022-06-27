using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class pms3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByHRId",
                table: "users",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_users_HR_CreatedByHRId",
                table: "users",
                column: "CreatedByHRId",
                principalTable: "HR",
                principalColumn: "HRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_HR_CreatedByHRId",
                table: "users");

            migrationBuilder.DropTable(
                name: "HR");

            migrationBuilder.DropIndex(
                name: "IX_users_CreatedByHRId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatedByHRId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
