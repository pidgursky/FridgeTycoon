﻿// <auto-generated />
using System;
using FT.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FT.Persistence.Migrations
{
    [DbContext(typeof(FTDBContext))]
    [Migration("20211008142010_EntitiesConfiguration")]
    partial class EntitiesConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FT.Domain.Entities.FridgeAggregate.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Fridge");
                });

            modelBuilder.Entity("FT.Domain.Entities.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FridgeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Refrigeratory")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FT.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FT.Domain.Entities.FridgeAggregate.Fridge", b =>
                {
                    b.HasOne("FT.Domain.Entities.Users.User", "User")
                        .WithMany("Fridges")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FT.Domain.Entities.ProductAggregate.Product", b =>
                {
                    b.HasOne("FT.Domain.Entities.FridgeAggregate.Fridge", "Fridge")
                        .WithMany("Products")
                        .HasForeignKey("FridgeId");
                });
#pragma warning restore 612, 618
        }
    }
}
