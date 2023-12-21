using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopDAL.Migrations
{
    /// <inheritdoc />
    public partial class AfterAutoMapperImpl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemEntityId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Reviews_ReviewEntityId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "ReviewEntityId",
                table: "Photos",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "ItemEntityId",
                table: "Photos",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ReviewEntityId",
                table: "Photos",
                newName: "IX_Photos_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ItemEntityId",
                table: "Photos",
                newName: "IX_Photos_ItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoEntity",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Reviews_ReviewId",
                table: "Photos",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Items_ItemId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Reviews_ReviewId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Photos",
                newName: "ReviewEntityId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Photos",
                newName: "ItemEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ReviewId",
                table: "Photos",
                newName: "IX_Photos_ReviewEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ItemId",
                table: "Photos",
                newName: "IX_Photos_ItemEntityId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoEntity",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Items_ItemEntityId",
                table: "Photos",
                column: "ItemEntityId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Reviews_ReviewEntityId",
                table: "Photos",
                column: "ReviewEntityId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
