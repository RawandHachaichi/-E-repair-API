using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class A4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparateurCompetences_Competences_CompetanceId",
                table: "ReparateurCompetences");

            migrationBuilder.RenameColumn(
                name: "CompetanceId",
                table: "ReparateurCompetences",
                newName: "CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReparateurCompetences_CompetanceId",
                table: "ReparateurCompetences",
                newName: "IX_ReparateurCompetences_CompetenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparateurCompetences_Competences_CompetenceId",
                table: "ReparateurCompetences",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparateurCompetences_Competences_CompetenceId",
                table: "ReparateurCompetences");

            migrationBuilder.RenameColumn(
                name: "CompetenceId",
                table: "ReparateurCompetences",
                newName: "CompetanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ReparateurCompetences_CompetenceId",
                table: "ReparateurCompetences",
                newName: "IX_ReparateurCompetences_CompetanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparateurCompetences_Competences_CompetanceId",
                table: "ReparateurCompetences",
                column: "CompetanceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
