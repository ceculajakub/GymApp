using Microsoft.EntityFrameworkCore.Migrations;

namespace GymApp.Migrations
{
    public partial class GymAppv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Bmi",
                table: "Users",
                nullable: false,
                computedColumnSql: "ROUND([Weight] / ([Height] * [Height]), 2)",
                oldClrType: typeof(double),
                oldType: "float",
                oldComputedColumnSql: "[Weight] / ([Height] * [Height]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Bmi",
                table: "Users",
                type: "float",
                nullable: false,
                computedColumnSql: "[Weight] / ([Height] * [Height]",
                oldClrType: typeof(double),
                oldComputedColumnSql: "ROUND([Weight] / ([Height] * [Height]), 2)");
        }
    }
}
