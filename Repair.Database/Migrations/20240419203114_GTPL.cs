using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class GTPL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModificationBy",
                table: "Dossiers",
                newName: "DerniereModification");

            migrationBuilder.RenameColumn(
                name: "IsEmergency",
                table: "Dossiers",
                newName: "Urgent");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Dossiers",
                newName: "DateCreation");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Dossiers",
                newName: "CreePar");

            migrationBuilder.AddColumn<DateTime>(
                name: "Debut",
                table: "Dossiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fin",
                table: "Dossiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debut",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Fin",
                table: "Dossiers");

            migrationBuilder.RenameColumn(
                name: "Urgent",
                table: "Dossiers",
                newName: "IsEmergency");

            migrationBuilder.RenameColumn(
                name: "DerniereModification",
                table: "Dossiers",
                newName: "LastModificationBy");

            migrationBuilder.RenameColumn(
                name: "DateCreation",
                table: "Dossiers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreePar",
                table: "Dossiers",
                newName: "CreatedBy");
        }
    }
}
