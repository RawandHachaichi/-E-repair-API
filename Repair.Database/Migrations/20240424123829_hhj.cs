using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class hhj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeRendezVousId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomFichier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContenuFichier = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TypeDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DerniereModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DossierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_TypeRendezVousId",
                table: "Event",
                column: "TypeRendezVousId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DossierId",
                table: "Document",
                column: "DossierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_TypeRendezVous_TypeRendezVousId",
                table: "Event",
                column: "TypeRendezVousId",
                principalTable: "TypeRendezVous",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_TypeRendezVous_TypeRendezVousId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Event_TypeRendezVousId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "TypeRendezVousId",
                table: "Event");
        }
    }
}
