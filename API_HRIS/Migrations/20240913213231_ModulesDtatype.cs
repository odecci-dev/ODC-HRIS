using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class ModulesDtatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TblModulesModel",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "TblModulesModel",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "TblModulesModel",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "TblModulesModel",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TblModulesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "TblModulesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "TblModulesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "TblModulesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);
        }
    }
}
