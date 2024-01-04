using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundingApplication.Migrations
{
    public partial class NewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spending",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    MonthSalaryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spending_monthSalaries_MonthSalaryId",
                        column: x => x.MonthSalaryId,
                        principalTable: "monthSalaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_spending_MonthSalaryId",
                table: "spending",
                column: "MonthSalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spending");
        }
    }
}
