using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class RootCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryEntity",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryEntity",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryEntity",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsRoot",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RootCategory",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRoot",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RootCategory",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryEntity",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryEntity",
                table: "Categories",
                column: "CategoryEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryEntity",
                table: "Categories",
                column: "CategoryEntity",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
