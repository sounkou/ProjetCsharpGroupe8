using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetHeritageGroupe8.Migrations
{
    public partial class HeritageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biens",
                columns: table => new
                {
                    BiensID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biens", x => x.BiensID);
                });

            migrationBuilder.CreateTable(
                name: "Heritier",
                columns: table => new
                {
                    HeritierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    code = table.Column<int>(nullable: false),
                    illustration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heritier", x => x.HeritierID);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    SourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    designation = table.Column<string>(nullable: true),
                    commentaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.SourceID);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    UtilisateurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    passWord = table.Column<string>(nullable: true),
                    typeUtilisateur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.UtilisateurID);
                });

            migrationBuilder.CreateTable(
                name: "AyantDroit",
                columns: table => new
                {
                    AyantDroitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    designation = table.Column<string>(nullable: true),
                    ImageADr = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    HeritierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AyantDroit", x => x.AyantDroitID);
                    table.ForeignKey(
                        name: "FK_AyantDroit_Heritier_HeritierID",
                        column: x => x.HeritierID,
                        principalTable: "Heritier",
                        principalColumn: "HeritierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regle",
                columns: table => new
                {
                    RegleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    commentaire = table.Column<string>(nullable: true),
                    SourceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regle", x => x.RegleID);
                    table.ForeignKey(
                        name: "FK_Regle_Source_SourceID",
                        column: x => x.SourceID,
                        principalTable: "Source",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ecole",
                columns: table => new
                {
                    EcoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    RegleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecole", x => x.EcoleID);
                    table.ForeignKey(
                        name: "FK_Ecole_Regle_RegleID",
                        column: x => x.RegleID,
                        principalTable: "Regle",
                        principalColumn: "RegleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heritage",
                columns: table => new
                {
                    HeritageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    DateDeces = table.Column<DateTime>(nullable: false),
                    DateHeritage = table.Column<DateTime>(nullable: false),
                    EcoleID = table.Column<int>(nullable: false),
                    montant = table.Column<decimal>(nullable: false),
                    BiensID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heritage", x => x.HeritageID);
                    table.ForeignKey(
                        name: "FK_Heritage_Biens_BiensID",
                        column: x => x.BiensID,
                        principalTable: "Biens",
                        principalColumn: "BiensID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heritage_Ecole_EcoleID",
                        column: x => x.EcoleID,
                        principalTable: "Ecole",
                        principalColumn: "EcoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AyantDroit_HeritierID",
                table: "AyantDroit",
                column: "HeritierID");

            migrationBuilder.CreateIndex(
                name: "IX_Ecole_RegleID",
                table: "Ecole",
                column: "RegleID");

            migrationBuilder.CreateIndex(
                name: "IX_Heritage_BiensID",
                table: "Heritage",
                column: "BiensID");

            migrationBuilder.CreateIndex(
                name: "IX_Heritage_EcoleID",
                table: "Heritage",
                column: "EcoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Regle_SourceID",
                table: "Regle",
                column: "SourceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AyantDroit");

            migrationBuilder.DropTable(
                name: "Heritage");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Heritier");

            migrationBuilder.DropTable(
                name: "Biens");

            migrationBuilder.DropTable(
                name: "Ecole");

            migrationBuilder.DropTable(
                name: "Regle");

            migrationBuilder.DropTable(
                name: "Source");
        }
    }
}
