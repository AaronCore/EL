using Microsoft.EntityFrameworkCore.Migrations;

namespace EL.EntityFrameworkCore.Migrations
{
    public partial class sys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityValidationError",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityValidationError",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
