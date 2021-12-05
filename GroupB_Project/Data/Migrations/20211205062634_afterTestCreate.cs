ateusing Microsoft.EntityFrameworkCore.Migrations;

namespace GroupB_Project.Data.Migrations
{
    public partial class afterTestCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Plans",
                newName: "dtmDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dtmDate",
                table: "Plans",
                newName: "DateTime");
        }
    }
}
