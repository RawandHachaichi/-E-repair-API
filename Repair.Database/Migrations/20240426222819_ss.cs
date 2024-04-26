using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "DerniereModification",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Option",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "TypeDocument",
                table: "Document",
                newName: "ExtensionDoc");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeDocumentId",
                table: "Document",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocument", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_TypeDocumentId",
                table: "Document",
                column: "TypeDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_TypeDocument_TypeDocumentId",
                table: "Document",
                column: "TypeDocumentId",
                principalTable: "TypeDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_TypeDocument_TypeDocumentId",
                table: "Document");

            migrationBuilder.DropTable(
                name: "TypeDocument");

            migrationBuilder.DropIndex(
                name: "IX_Document_TypeDocumentId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "TypeDocumentId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "ExtensionDoc",
                table: "Document",
                newName: "TypeDocument");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DerniereModification",
                table: "Document",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                table: "Document",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
