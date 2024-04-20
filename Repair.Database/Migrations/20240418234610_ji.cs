using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class ji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Dossiers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Dossiers",
                type: "bit",
                nullable: true);
        }
    }
}
