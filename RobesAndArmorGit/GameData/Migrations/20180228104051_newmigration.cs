using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "Items",
                newName: "TypeId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Items",
                newName: "typeId");

            migrationBuilder.AlterColumn<int>(
                name: "typeId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
