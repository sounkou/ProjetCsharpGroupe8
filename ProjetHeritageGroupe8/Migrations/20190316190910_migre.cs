using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetHeritageGroupe8.Migrations
{
    public partial class migre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AyantDroit",
                columns: table => new
                {
                    AyantDroitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true),
                    sexe = table.Column<string>(nullable: true),
                    dateNaissance = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_AyantDroit_HeritierID",
                table: "AyantDroit",
                column: "HeritierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AyantDroit");
        }
    }
}
