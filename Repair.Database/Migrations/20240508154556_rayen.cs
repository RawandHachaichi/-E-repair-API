using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class rayen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Utilisateurs_UtilisateurId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Event",
                newName: "DossierId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_UtilisateurId",
                table: "Event",
                newName: "IX_Event_DossierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Dossiers_DossierId",
                table: "Event",
                column: "DossierId",
                principalTable: "Dossiers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Dossiers_DossierId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "DossierId",
                table: "Event",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_DossierId",
                table: "Event",
                newName: "IX_Event_UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Utilisateurs_UtilisateurId",
                table: "Event",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }
    }
}
