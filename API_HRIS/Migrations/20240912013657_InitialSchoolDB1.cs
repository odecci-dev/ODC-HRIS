using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class InitialSchoolDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoursofWork",
                table: "tbl_TaskModel",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursofWork",
                table: "tbl_TaskModel");
        }
    }
}
