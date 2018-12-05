using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class newvariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValueInflated",
                table: "YearTracker",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSavedInflated",
                table: "InvestmentTracker",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ExpectedInflation",
                table: "Account",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueInflated",
                table: "YearTracker");

            migrationBuilder.DropColumn(
                name: "TotalSavedInflated",
                table: "InvestmentTracker");

            migrationBuilder.DropColumn(
                name: "ExpectedInflation",
                table: "Account");
        }
    }
}
