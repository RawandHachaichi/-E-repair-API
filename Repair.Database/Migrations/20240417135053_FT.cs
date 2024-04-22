using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class FT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "MaterielId",
                table: "Dossiers");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatiereId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers",
                column: "MatiereId",
                principalTable: "Matiere",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatiereId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MaterielId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Matiere_MatiereId",
                table: "Dossiers",
                column: "MatiereId",
                principalTable: "Matiere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
