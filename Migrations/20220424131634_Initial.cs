using Microsoft.EntityFrameworkCore.Migrations;

namespace GymApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "Bmi",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvgPulse",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "ExercisesDone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pulse",
                table: "ExercisesDone",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bmi",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AvgPulse",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "ExercisesDone");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "ExercisesDone");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Users",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
