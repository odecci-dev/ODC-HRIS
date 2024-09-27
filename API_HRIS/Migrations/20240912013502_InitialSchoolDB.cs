using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class InitialSchoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "tbl_TimeLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "tbl_TimeLogs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "tbl_TimeLogs");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "tbl_TimeLogs");
        }
    }
}
