using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtAuthentication.Migrations
{
    public partial class ajustdoLancamentoEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Lancamentos",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Situacao",
                table: "Lancamentos",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
