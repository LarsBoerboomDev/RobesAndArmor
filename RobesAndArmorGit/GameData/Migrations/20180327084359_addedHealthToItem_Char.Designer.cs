﻿// <auto-generated />
using GameData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GameData.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20180327084359_addedHealthToItem_Char")]
    partial class addedHealthToItem_Char
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameData.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("ClassId");

                    b.Property<int>("Exp");

                    b.Property<int>("Health");

                    b.Property<int>("INT");

                    b.Property<int>("InventoryId");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.Property<int>("gold");

                    b.Property<string>("imageUrl");

                    b.Property<int>("str");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("GameData.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("Int");

                    b.Property<string>("Name");

                    b.Property<int>("Str");

                    b.Property<string>("imageUrl");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GameData.Models.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Atk");

                    b.Property<int>("Def");

                    b.Property<int>("Health");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("imageUrl");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("GameData.Models.Enemy_has_Item", b =>
                {
                    b.Property<int>("EnemyId");

                    b.Property<int>("ItemId");

                    b.HasKey("EnemyId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Enemy_has_Item");
                });

            modelBuilder.Entity("GameData.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("GameData.Models.Inventory_has_Item", b =>
                {
                    b.Property<int>("InventoryId");

                    b.Property<int>("ItemId");

                    b.HasKey("InventoryId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Inventory_has_Item");
                });

            modelBuilder.Entity("GameData.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Atk");

                    b.Property<int>("Def");

                    b.Property<string>("Description");

                    b.Property<int>("Health");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("imgeUrl");

                    b.Property<int>("typeId");

                    b.HasKey("Id");

                    b.HasIndex("typeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GameData.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Title");

                    b.Property<DateTime>("postDate");

                    b.HasKey("Id");

                    b.ToTable("theNews");
                });

            modelBuilder.Entity("GameData.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("GameData.Models.Character", b =>
                {
                    b.HasOne("GameData.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameData.Models.Inventory", "inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameData.Models.Enemy_has_Item", b =>
                {
                    b.HasOne("GameData.Models.Enemy", "Enemy")
                        .WithMany()
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameData.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameData.Models.Inventory_has_Item", b =>
                {
                    b.HasOne("GameData.Models.Inventory", "Inventory")
                        .WithMany("Inventory_Has_Item")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameData.Models.Item", "Item")
                        .WithMany("Inventory_Has_Item")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameData.Models.Item", b =>
                {
                    b.HasOne("GameData.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
