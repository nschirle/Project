using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "Account",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Interest",
                table: "Account",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentOfSalarySaved",
                table: "Account",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "YearsInPeriod",
                table: "Account",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PercentOfSalarySaved",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "YearsInPeriod",
                table: "Account");
        }
    }
}
