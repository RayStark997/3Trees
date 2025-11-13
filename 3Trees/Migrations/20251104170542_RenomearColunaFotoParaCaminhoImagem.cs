using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3Trees.Migrations
{
    /// <inheritdoc />
    public partial class RenomearColunaFotoParaCaminhoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Trilhas",
                newName: "CaminhoImagem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaminhoImagem",
                table: "Trilhas",
                newName: "Foto");
        }
    }
}
