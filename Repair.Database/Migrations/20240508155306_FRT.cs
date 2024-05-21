using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class FRT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_UtilisateurId",
                table: "Event",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Utilisateurs_UtilisateurId",
                table: "Event",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Utilisateurs_UtilisateurId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_UtilisateurId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Event");
        }
    }
}
