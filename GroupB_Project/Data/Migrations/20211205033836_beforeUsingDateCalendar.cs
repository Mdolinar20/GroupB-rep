using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupB_Project.Data.Migrations
{
    public partial class beforeUsingDateCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Plans");

            migrationBuilder.AddColumn<DateTime>(
                name: "StudyDate",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudyDate",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
