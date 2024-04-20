using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class GT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRDV",
                table: "Dossiers");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeRDVId",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRDVId",
                table: "Dossiers");

            migrationBuilder.AddColumn<string>(
                name: "TypeRDV",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
