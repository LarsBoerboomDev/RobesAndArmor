using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Characters_characterId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_characterId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "characterId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Equipment_EquipmentId",
                table: "Characters",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Equipment_EquipmentId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "characterId",
                table: "Equipment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_characterId",
                table: "Equipment",
                column: "characterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Characters_characterId",
                table: "Equipment",
                column: "characterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
