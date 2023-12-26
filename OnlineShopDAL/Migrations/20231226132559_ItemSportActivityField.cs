using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class ItemSportActivityField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Items");
        }
    }
}
