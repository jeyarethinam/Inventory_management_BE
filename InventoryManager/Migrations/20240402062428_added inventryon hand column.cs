using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager.Migrations
{
    /// <inheritdoc />
    public partial class addedinventryonhandcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryOnHand",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryOnHand",
                table: "Products");
        }
    }
}
