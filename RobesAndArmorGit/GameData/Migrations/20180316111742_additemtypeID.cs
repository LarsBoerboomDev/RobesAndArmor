using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class additemtypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Items",
                newName: "typeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                newName: "IX_Items_typeId");

            migrationBuilder.AlterColumn<int>(
                name: "typeId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_typeId",
                table: "Items",
                column: "typeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_typeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "Items",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_typeId",
                table: "Items",
                newName: "IX_Items_TypeId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));

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
