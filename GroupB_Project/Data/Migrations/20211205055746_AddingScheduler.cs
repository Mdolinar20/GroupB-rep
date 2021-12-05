using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupB_Project.Data.Migrations
{
    public partial class AddingScheduler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "ScheduledSessions",
                newName: "ScheduledDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "ScheduledSessions",
                newName: "DateTime");
        }
    }
}
