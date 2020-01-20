using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeListRazor.Migrations
{
    public partial class AddPositionToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employee");
        }
    }
}
