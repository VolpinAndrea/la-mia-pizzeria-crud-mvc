using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class correggi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriePizze",
                table: "CategoriePizze");

            migrationBuilder.RenameTable(
                name: "CategoriePizze",
                newName: "Categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "CategoriePizze");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriePizze",
                table: "CategoriePizze",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "CategoriePizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
