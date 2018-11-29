using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    YearsInPeriod = table.Column<int>(nullable: false),
                    Income = table.Column<decimal>(nullable: false),
                    Interest = table.Column<decimal>(nullable: false),
                    PercentOfSalarySaved = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentTracker",
                columns: table => new
                {
                    TrackingNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalSaved = table.Column<decimal>(nullable: false),
                    AccountNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TrackingNumber);
                    table.ForeignKey(
                        name: "FK_InvestmentTracker_Account_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Account",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearTracker",
                columns: table => new
                {
                    YearTrackingNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    TrackingNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearTrackingNumber", x => x.YearTrackingNumber);
                    table.ForeignKey(
                        name: "FK_YearTracker_InvestmentTracker_TrackingNumber",
                        column: x => x.TrackingNumber,
                        principalTable: "InvestmentTracker",
                        principalColumn: "TrackingNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentTracker_AccountNumber",
                table: "InvestmentTracker",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_YearTracker_TrackingNumber",
                table: "YearTracker",
                column: "TrackingNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearTracker");

            migrationBuilder.DropTable(
                name: "InvestmentTracker");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
