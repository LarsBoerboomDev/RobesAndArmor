using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class Addedidsforchartersrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_inventoryId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "inventoryId",
                table: "Characters",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_inventoryId",
                table: "Characters",
                newName: "IX_Characters_InventoryId");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Inventories_InventoryId",
                table: "Characters",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_InventoryId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "Characters",
                newName: "inventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                newName: "IX_Characters_inventoryId");

            migrationBuilder.AlterColumn<int>(
                name: "inventoryId",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Inventories_inventoryId",
                table: "Characters",
                column: "inventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
