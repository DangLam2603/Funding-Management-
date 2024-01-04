using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundingApplication.Migrations
{
    public partial class fixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spending_monthSalaries_MonthSalaryId",
                table: "spending");

            migrationBuilder.RenameColumn(
                name: "MonthSalaryId",
                table: "spending",
                newName: "SalaryId");

            migrationBuilder.RenameIndex(
                name: "IX_spending_MonthSalaryId",
                table: "spending",
                newName: "IX_spending_SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_spending_salaries_SalaryId",
                table: "spending",
                column: "SalaryId",
                principalTable: "salaries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spending_salaries_SalaryId",
                table: "spending");

            migrationBuilder.RenameColumn(
                name: "SalaryId",
                table: "spending",
                newName: "MonthSalaryId");

            migrationBuilder.RenameIndex(
                name: "IX_spending_SalaryId",
                table: "spending",
                newName: "IX_spending_MonthSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_spending_monthSalaries_MonthSalaryId",
                table: "spending",
                column: "MonthSalaryId",
                principalTable: "monthSalaries",
                principalColumn: "Id");
        }
    }
}
