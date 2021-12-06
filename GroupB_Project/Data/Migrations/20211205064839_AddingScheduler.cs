using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupB_Project.Data.Migrations
{
    public partial class AddingScheduler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "ScheduledSessions",
                newName: "ScheduledDateStart");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ScheduledSessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleDateEnd",
                table: "ScheduledSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "ScheduledSessions");

            migrationBuilder.DropColumn(
                name: "ScheduleDateEnd",
                table: "ScheduledSessions");

            migrationBuilder.RenameColumn(
                name: "ScheduledDateStart",
                table: "ScheduledSessions",
                newName: "ScheduledDate");
        }
    }
}
