using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtAuthentication.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "AutorId", "Grupo", "Nome" },
                values: new object[,]
                {
                    { 1, null, 0, "A Categorizar" },
                    { 26, null, 6, "Cuidados Pessoais" },
                    { 27, null, 6, "Despesas do Trabalho" },
                    { 28, null, 6, "Presentes/Doações" },
                    { 29, null, 7, "Pensão Mariah" },
                    { 30, null, 8, "Impostos" },
                    { 31, null, 8, "Multa/Juros" },
                    { 32, null, 8, "Taxas Bancárias" },
                    { 33, null, 8, "Cheque Especial" },
                    { 34, null, 8, "Pagamento de Empréstimo" },
                    { 25, null, 6, "Compras" },
                    { 35, null, 9, "Remuneração" },
                    { 37, null, 9, "Rendimento" },
                    { 38, null, 9, "Empréstimo" },
                    { 48, null, 9, "Vale Refeição" },
                    { 39, null, 9, "Outras Rendas" },
                    { 40, null, 9, "Indenização - Despesa do Trabalho" },
                    { 42, null, 10, "Saque" },
                    { 43, null, 10, "Aplicação" },
                    { 44, null, 10, "Resgate" },
                    { 45, null, 10, "Transfência" },
                    { 36, null, 9, "Bônus" },
                    { 46, null, 10, "Pagamento de cartão" },
                    { 24, null, 6, "Lanches / Saidinhas" },
                    { 22, null, 5, "Outros" },
                    { 2, null, 1, "Aluguel" },
                    { 3, null, 1, "Luz" },
                    { 4, null, 1, "Água" },
                    { 5, null, 1, "TV/Internet/Telefone Residêncial" },
                    { 6, null, 1, "Manutenção/Melhorias" },
                    { 7, null, 1, "Seguros" },
                    { 8, null, 1, "Segurança" },
                    { 9, null, 2, "Mercado Dispensa/Essencial" },
                    { 10, null, 2, "Mercado Filhas" },
                    { 23, null, 4, "Educação" },
                    { 11, null, 2, "Mercado não essencial" },
                    { 13, null, 3, "Higiêne Filhas" },
                    { 14, null, 3, "Plano de saúde" },
                    { 15, null, 3, "Farmácia" },
                    { 16, null, 3, "Farmácia Filhas" },
                    { 17, null, 5, "Moto - Abastecimento" },
                    { 18, null, 5, "Moto - Manutenção/Melhorias" },
                    { 19, null, 5, "Uber - Essencial" },
                    { 20, null, 5, "Uber - Escola Laura" },
                    { 21, null, 5, "Uber - Saidinhas e Outros" },
                    { 12, null, 3, "Higiêne Geral" },
                    { 47, null, 11, "Lançamento subcategorizado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 48);
        }
    }
}
