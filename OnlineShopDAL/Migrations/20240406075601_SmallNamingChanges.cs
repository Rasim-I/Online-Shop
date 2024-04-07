using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class SmallNamingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartItemEntity",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartItemEntity",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartItemEntity",
                table: "CartItem");

            migrationBuilder.AddColumn<Guid>(
                name: "CartEntity",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartEntity",
                table: "CartItem",
                column: "CartEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartEntity",
                table: "CartItem",
                column: "CartEntity",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartEntity",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartEntity",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartEntity",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItem");

            migrationBuilder.AddColumn<Guid>(
                name: "CartItemEntity",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartItemEntity",
                table: "CartItem",
                column: "CartItemEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartItemEntity",
                table: "CartItem",
                column: "CartItemEntity",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
