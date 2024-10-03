using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoWebAspL3.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commune",
                columns: table => new
                {
                    CommuneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commune", x => x.CommuneId);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etuNom = table.Column<string>(type: "varchar(50)", nullable: false),
                    etuPrenom = table.Column<string>(type: "varchar(50)", nullable: false),
                    etuSexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etuDateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false),
                    etuEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    etuCotisation = table.Column<int>(type: "int", nullable: false),
                    cheminImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    CommuneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.EtudiantId);
                    table.ForeignKey(
                        name: "FK_Etudiant_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiant_Commune_CommuneId",
                        column: x => x.CommuneId,
                        principalTable: "Commune",
                        principalColumn: "CommuneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quittance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quitLibelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quitMontantEmis = table.Column<int>(type: "int", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quittance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quittance_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiant",
                        principalColumn: "EtudiantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_CategorieId",
                table: "Etudiant",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_CommuneId",
                table: "Etudiant",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Quittance_EtudiantId",
                table: "Quittance",
                column: "EtudiantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quittance");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Commune");
        }
    }
}
