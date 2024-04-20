using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class GTJR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_TypeRendezVous_TypeRendezVousId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "TypeRDVId",
                table: "Dossiers");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeRendezVousId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_TypeRendezVous_TypeRendezVousId",
                table: "Dossiers",
                column: "TypeRendezVousId",
                principalTable: "TypeRendezVous",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_TypeRendezVous_TypeRendezVousId",
                table: "Dossiers");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeRendezVousId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeRDVId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_TypeRendezVous_TypeRendezVousId",
                table: "Dossiers",
                column: "TypeRendezVousId",
                principalTable: "TypeRendezVous",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
