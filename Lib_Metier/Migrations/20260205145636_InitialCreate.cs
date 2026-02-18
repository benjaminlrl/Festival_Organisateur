using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_Metier.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espace",
                columns: table => new
                {
                    id_espace = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    superficie = table.Column<double>(type: "REAL", nullable: false),
                    capaciteMaxi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espace", x => x.id_espace);
                });

            migrationBuilder.CreateTable(
                name: "Plateforme",
                columns: table => new
                {
                    id_plateform = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    libelle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plateforme", x => x.id_plateform);
                });

            migrationBuilder.CreateTable(
                name: "Tournoi",
                columns: table => new
                {
                    numeroTournoi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dateHeure = table.Column<DateTime>(type: "TEXT", nullable: false),
                    nbParticipants = table.Column<int>(type: "INTEGER", nullable: false),
                    dureePrevue = table.Column<int>(type: "INTEGER", nullable: false),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    statut = table.Column<string>(type: "TEXT", nullable: false),
                    id_espace = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournoi", x => x.numeroTournoi);
                    table.ForeignKey(
                        name: "FK_Tournoi_Espace_id_espace",
                        column: x => x.id_espace,
                        principalTable: "Espace",
                        principalColumn: "id_espace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poste_Jeu",
                columns: table => new
                {
                    numero_poste = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reference = table.Column<string>(type: "TEXT", nullable: false),
                    fonctionnel = table.Column<string>(type: "TEXT", nullable: false),
                    id_plateform = table.Column<int>(type: "INTEGER", nullable: false),
                    id_espace = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poste_Jeu", x => x.numero_poste);
                    table.ForeignKey(
                        name: "FK_Poste_Jeu_Espace_id_espace",
                        column: x => x.id_espace,
                        principalTable: "Espace",
                        principalColumn: "id_espace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poste_Jeu_Plateforme_id_plateform",
                        column: x => x.id_plateform,
                        principalTable: "Plateforme",
                        principalColumn: "id_plateform",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poste_Jeu_id_espace",
                table: "Poste_Jeu",
                column: "id_espace");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_Jeu_id_plateform",
                table: "Poste_Jeu",
                column: "id_plateform");

            migrationBuilder.CreateIndex(
                name: "IX_Tournoi_id_espace",
                table: "Tournoi",
                column: "id_espace");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poste_Jeu");

            migrationBuilder.DropTable(
                name: "Tournoi");

            migrationBuilder.DropTable(
                name: "Plateforme");

            migrationBuilder.DropTable(
                name: "Espace");
        }
    }
}
