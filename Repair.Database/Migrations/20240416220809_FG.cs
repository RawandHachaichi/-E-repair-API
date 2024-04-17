using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class FG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_Materiels_MaterielId",
                table: "Dossiers");

            migrationBuilder.DropTable(
                name: "Materiels");

            migrationBuilder.DropIndex(
                name: "IX_Dossiers_MaterielId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "DateIncident",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "RendezVousId",
                table: "Dossiers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MatiereId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TypeRDV",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_MatiereId",
                table: "Dossiers",
                column: "MatiereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers",
                column: "MatiereId",
                principalTable: "Matiere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropIndex(
                name: "IX_Dossiers_MatiereId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "MatiereId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "TypeRDV",
                table: "Dossiers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIncident",
                table: "Dossiers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RendezVousId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Materiels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_MaterielId",
                table: "Dossiers",
                column: "MaterielId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Materiels_MaterielId",
                table: "Dossiers",
                column: "MaterielId",
                principalTable: "Materiels",
                principalColumn: "Id");
        }
    }
}
