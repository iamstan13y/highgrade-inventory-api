using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighGradeInventory.API.Migrations
{
    public partial class AlertLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AlertLevel",
                table: "Inventories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertLevel",
                table: "Inventories");
        }
    }
}
