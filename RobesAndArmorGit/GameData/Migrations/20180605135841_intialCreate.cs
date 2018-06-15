using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameData.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "battles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    characterID = table.Column<int>(nullable: false),
                    enemyHealth = table.Column<int>(nullable: false),
                    enemyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_battles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agility = table.Column<int>(nullable: false),
                    Int = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Str = table.Column<int>(nullable: false),
                    imageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atk = table.Column<int>(nullable: false),
                    Def = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "itemArchives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atk = table.Column<int>(nullable: false),
                    Def = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rarity = table.Column<string>(nullable: true),
                    imgeUrl = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "theNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    postDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atk = table.Column<int>(nullable: false),
                    Def = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rarity = table.Column<string>(nullable: true),
                    imgeUrl = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    typeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Types_typeId",
                        column: x => x.typeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy_has_Item",
                columns: table => new
                {
                    EnemyId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy_has_Item", x => new { x.EnemyId, x.ItemId });
                    table.UniqueConstraint("AK_Enemy_has_Item_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemy_has_Item_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enemy_has_Item_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bodyId = table.Column<int>(nullable: false),
                    bodyItemId = table.Column<int>(nullable: true),
                    feetId = table.Column<int>(nullable: false),
                    feetItemId = table.Column<int>(nullable: true),
                    gloveId = table.Column<int>(nullable: false),
                    gloveItemId = table.Column<int>(nullable: true),
                    headId = table.Column<int>(nullable: false),
                    headItemId = table.Column<int>(nullable: true),
                    legsId = table.Column<int>(nullable: false),
                    legsItemId = table.Column<int>(nullable: true),
                    shieldId = table.Column<int>(nullable: false),
                    shieldItemId = table.Column<int>(nullable: true),
                    weaponId = table.Column<int>(nullable: false),
                    weaponItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_bodyItemId",
                        column: x => x.bodyItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_feetItemId",
                        column: x => x.feetItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_gloveItemId",
                        column: x => x.gloveItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_headItemId",
                        column: x => x.headItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_legsItemId",
                        column: x => x.legsItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_shieldItemId",
                        column: x => x.shieldItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Items_weaponItemId",
                        column: x => x.weaponItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_has_Item",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_has_Item", x => new { x.InventoryId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Inventory_has_Item_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_has_Item_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agility = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    INT = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    gold = table.Column<int>(nullable: false),
                    imageUrl = table.Column<string>(nullable: true),
                    str = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemy_has_Item_ItemId",
                table: "Enemy_has_Item",
                column: "ItemId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_has_Item_ItemId",
                table: "Inventory_has_Item",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_typeId",
                table: "Items",
                column: "typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "battles");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Enemy_has_Item");

            migrationBuilder.DropTable(
                name: "Inventory_has_Item");

            migrationBuilder.DropTable(
                name: "itemArchives");

            migrationBuilder.DropTable(
                name: "theNews");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
