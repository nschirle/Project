using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "InvestmentTracker");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "InvestmentTracker");

            migrationBuilder.DropColumn(
                name: "YearsInPeriod",
                table: "InvestmentTracker");

            migrationBuilder.RenameColumn(
                name: "PercentOfSalarySaved",
                table: "InvestmentTracker",
                newName: "TotalSaved");

            migrationBuilder.RenameColumn(
                name: "TrackerID",
                table: "InvestmentTracker",
                newName: "TrackingNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSaved",
                table: "InvestmentTracker",
                newName: "PercentOfSalarySaved");

            migrationBuilder.RenameColumn(
                name: "TrackingNumber",
                table: "InvestmentTracker",
                newName: "TrackerID");

            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "InvestmentTracker",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Interest",
                table: "InvestmentTracker",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "YearsInPeriod",
                table: "InvestmentTracker",
                nullable: false,
                defaultValue: 0);
        }
    }
}
