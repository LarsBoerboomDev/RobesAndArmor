using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class ForeignKeytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Types",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_ItemId",
                table: "Types",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Items_ItemId",
                table: "Types",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_Items_ItemId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_ItemId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Types");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
