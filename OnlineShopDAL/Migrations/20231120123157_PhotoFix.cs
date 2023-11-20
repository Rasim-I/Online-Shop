using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class PhotoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_PhotoEntity",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Reviews_PhotoEntity",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotoEntity",
                table: "Photos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoEntity",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemEntityId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewEntityId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ItemEntityId",
                table: "Photos",
                column: "ItemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ReviewEntityId",
                table: "Photos",
                column: "ReviewEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemEntityId",
                table: "Photos",
                column: "ItemEntityId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Reviews_ReviewEntityId",
                table: "Photos",
                column: "ReviewEntityId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemEntityId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Reviews_ReviewEntityId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ItemEntityId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ReviewEntityId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ItemEntityId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ReviewEntityId",
                table: "Photos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoEntity",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoEntity",
                table: "Photos",
                column: "PhotoEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_PhotoEntity",
                table: "Photos",
                column: "PhotoEntity",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Reviews_PhotoEntity",
                table: "Photos",
                column: "PhotoEntity",
                principalTable: "Reviews",
                principalColumn: "Id");
        }
    }
}
