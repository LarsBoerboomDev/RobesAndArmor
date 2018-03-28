using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class addeforeignkeys_equipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "weapongId",
                table: "Equipment",
                newName: "weaponId");

            migrationBuilder.AddColumn<int>(
                name: "bodyItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "feetItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gloveItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "headItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legsItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "shieldItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "weaponItemId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_bodyItemId",
                table: "Equipment",
                column: "bodyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_feetItemId",
                table: "Equipment",
                column: "feetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_gloveItemId",
                table: "Equipment",
                column: "gloveItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_headItemId",
                table: "Equipment",
                column: "headItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_legsItemId",
                table: "Equipment",
                column: "legsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_shieldItemId",
                table: "Equipment",
                column: "shieldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_weaponItemId",
                table: "Equipment",
                column: "weaponItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_bodyItemId",
                table: "Equipment",
                column: "bodyItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_feetItemId",
                table: "Equipment",
                column: "feetItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_gloveItemId",
                table: "Equipment",
                column: "gloveItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_headItemId",
                table: "Equipment",
                column: "headItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_legsItemId",
                table: "Equipment",
                column: "legsItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_shieldItemId",
                table: "Equipment",
                column: "shieldItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Items_weaponItemId",
                table: "Equipment",
                column: "weaponItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_bodyItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_feetItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_gloveItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_headItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_legsItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_shieldItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Items_weaponItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_bodyItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_feetItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_gloveItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_headItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_legsItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_shieldItemId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_weaponItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "bodyItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "feetItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "gloveItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "headItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "legsItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "shieldItemId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "weaponItemId",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "weaponId",
                table: "Equipment",
                newName: "weapongId");
        }
    }
}
