using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class addpos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "tbl_UsersModel",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "tbl_UsersModel");
        }
    }
}
