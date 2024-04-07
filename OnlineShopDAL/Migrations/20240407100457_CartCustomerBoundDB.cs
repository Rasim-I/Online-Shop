using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class CartCustomerBoundDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntity",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerEntity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerEntity",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerEntity",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerEntity",
                table: "Carts",
                column: "CustomerEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomerEntity",
                table: "Carts",
                column: "CustomerEntity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomerEntity",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerEntity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerEntity",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerEntity",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntity",
                table: "Orders",
                column: "CustomerEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntity",
                table: "Orders",
                column: "CustomerEntity",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
