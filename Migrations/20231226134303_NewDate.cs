using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundingApplication.Migrations
{
    public partial class NewDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfTransaction",
                table: "monthSalaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfTransaction",
                table: "monthSalaries");
        }
    }
}
