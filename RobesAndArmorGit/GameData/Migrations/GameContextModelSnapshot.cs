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
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ClassId");

                    b.Property<int>("Exp");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.Property<int>("gold");

                    b.Property<string>("imageUrl");

                    b.Property<int?>("inventoryId");

                    b.Property<int>("str");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("inventoryId");

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

            modelBuilder.Entity("GameData.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("GameData.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Atk");

                    b.Property<int>("Def");

                    b.Property<string>("Name");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

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
                        .HasForeignKey("ClassId");

                    b.HasOne("GameData.Models.Inventory", "inventory")
                        .WithMany()
                        .HasForeignKey("inventoryId");
                });

            modelBuilder.Entity("GameData.Models.Item", b =>
                {
                    b.HasOne("GameData.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
