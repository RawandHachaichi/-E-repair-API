using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class E3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroTelephone1",
                table: "Utilisateurs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DossierStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRendezVous",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRendezVous", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DossierNumber = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DossierStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategorieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CauseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObjetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeBatimentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeDomageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterielId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocalisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RendezVousId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeRendezVousId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: true),
                    DateIncident = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_DossierStatus_DossierStatusId",
                        column: x => x.DossierStatusId,
                        principalTable: "DossierStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_Localisations_LocalisationId",
                        column: x => x.LocalisationId,
                        principalTable: "Localisations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_Materiels_MaterielId",
                        column: x => x.MaterielId,
                        principalTable: "Materiels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_Objets_ObjetId",
                        column: x => x.ObjetId,
                        principalTable: "Objets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_TypeBatiment_TypeBatimentId",
                        column: x => x.TypeBatimentId,
                        principalTable: "TypeBatiment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_TypeDomage_TypeDomageId",
                        column: x => x.TypeDomageId,
                        principalTable: "TypeDomage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dossiers_TypeRendezVous_TypeRendezVousId",
                        column: x => x.TypeRendezVousId,
                        principalTable: "TypeRendezVous",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dossiers_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_CategorieId",
                table: "Dossiers",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_CauseId",
                table: "Dossiers",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DossierStatusId",
                table: "Dossiers",
                column: "DossierStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_LocalisationId",
                table: "Dossiers",
                column: "LocalisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_MaterielId",
                table: "Dossiers",
                column: "MaterielId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_ObjetId",
                table: "Dossiers",
                column: "ObjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_TypeBatimentId",
                table: "Dossiers",
                column: "TypeBatimentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_TypeDomageId",
                table: "Dossiers",
                column: "TypeDomageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_TypeRendezVousId",
                table: "Dossiers",
                column: "TypeRendezVousId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_UtilisateurId",
                table: "Dossiers",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "DossierStatus");

            migrationBuilder.DropTable(
                name: "TypeRendezVous");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroTelephone1",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
