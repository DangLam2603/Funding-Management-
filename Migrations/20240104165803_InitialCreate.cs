using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundingApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salaries_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "monthSalaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    dateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monthSalaries_salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "spending",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    SalaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spending_salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_monthSalaries_SalaryId",
                table: "monthSalaries",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_salaries_UserId",
                table: "salaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_spending_SalaryId",
                table: "spending",
                column: "SalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "monthSalaries");

            migrationBuilder.DropTable(
                name: "spending");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
