using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class anotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "classId",
                table: "Characters",
                newName: "ClassId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_inventoryId",
                table: "Characters",
                column: "inventoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_inventoryId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClassId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_inventoryId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Characters",
                newName: "classId");

            migrationBuilder.AlterColumn<int>(
                name: "inventoryId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "classId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
