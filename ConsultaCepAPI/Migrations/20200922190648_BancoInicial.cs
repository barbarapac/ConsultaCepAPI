using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaCepAPI.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ceps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Localidade = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    Ibge = table.Column<long>(nullable: false),
                    Gia = table.Column<string>(nullable: true),
                    Ddd = table.Column<long>(nullable: false),
                    Siafi = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ceps");
        }
    }
}
