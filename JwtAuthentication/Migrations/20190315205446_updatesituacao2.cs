using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtAuthentication.Migrations
{
    public partial class updatesituacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Lancamentos",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Lancamentos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}
