using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetHeritageGroupe8.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AyantDroit");

            migrationBuilder.AlterColumn<float>(
                name: "montant",
                table: "Heritage",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "montant",
                table: "Heritage",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.CreateTable(
                name: "AyantDroit",
                columns: table => new
                {
                    AyantDroitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    HeritierID = table.Column<int>(nullable: false),
                    ImageADr = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true)
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
    }
}
