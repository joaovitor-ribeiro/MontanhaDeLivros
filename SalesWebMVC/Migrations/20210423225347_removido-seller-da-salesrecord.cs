using Microsoft.EntityFrameworkCore.Migrations;

namespace MontanhaDeLivros.Migrations
{
    public partial class removidosellerdasalesrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SalesRecord",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SalesRecord");
        }
    }
}
