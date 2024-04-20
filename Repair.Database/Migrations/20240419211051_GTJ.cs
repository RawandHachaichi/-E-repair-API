using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repair.Database.Migrations
{
    public partial class GTJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dossiers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
