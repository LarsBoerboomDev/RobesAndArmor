using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Inventory_has_Item_Id",
                table: "Inventory_has_Item");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inventory_has_Item",
                newName: "Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Inventory_has_Item",
                newName: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Inventory_has_Item_Id",
                table: "Inventory_has_Item",
                column: "Id");
        }
    }
}
