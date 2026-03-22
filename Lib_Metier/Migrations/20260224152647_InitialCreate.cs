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
                    superficie = table.Column<int>(type: "INTEGER", nullable: false),
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
                    id_plateforme = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    libelle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plateforme", x => x.id_plateforme);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id_role);
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
                    id_plateforme = table.Column<int>(type: "INTEGER", nullable: false),
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
                        name: "FK_Poste_Jeu_Plateforme_id_plateforme",
                        column: x => x.id_plateforme,
                        principalTable: "Plateforme",
                        principalColumn: "id_plateforme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisateur",
                columns: table => new
                {
                    login = table.Column<string>(type: "TEXT", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: false),
                    motPasse = table.Column<string>(type: "TEXT", nullable: false),
                    id_role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisateur", x => x.login);
                    table.ForeignKey(
                        name: "FK_Organisateur_Role_id_role",
                        column: x => x.id_role,
                        principalTable: "Role",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    libelle = table.Column<string>(type: "TEXT", nullable: false),
                    valeurTotale = table.Column<float>(type: "REAL", nullable: false),
                    rangAttribution = table.Column<int>(type: "INTEGER", nullable: false),
                    estAttribue = table.Column<bool>(type: "INTEGER", nullable: false),
                    numeroTournoi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Lot_Tournoi_Numero",
                        column: x => x.Numero,
                        principalTable: "Tournoi",
                        principalColumn: "numeroTournoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotComposant",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    libelle = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<int>(type: "INTEGER", nullable: false),
                    valeur = table.Column<int>(type: "INTEGER", nullable: false),
                    numero_lot = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotComposant", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_LotComposant_Lot_Numero",
                        column: x => x.Numero,
                        principalTable: "Lot",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organisateur_id_role",
                table: "Organisateur",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_Jeu_id_espace",
                table: "Poste_Jeu",
                column: "id_espace");

            migrationBuilder.CreateIndex(
                name: "IX_Poste_Jeu_id_plateforme",
                table: "Poste_Jeu",
                column: "id_plateforme");

            migrationBuilder.CreateIndex(
                name: "IX_Tournoi_id_espace",
                table: "Tournoi",
                column: "id_espace");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotComposant");

            migrationBuilder.DropTable(
                name: "Organisateur");

            migrationBuilder.DropTable(
                name: "Poste_Jeu");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Plateforme");

            migrationBuilder.DropTable(
                name: "Tournoi");

            migrationBuilder.DropTable(
                name: "Espace");
        }
    }
}
