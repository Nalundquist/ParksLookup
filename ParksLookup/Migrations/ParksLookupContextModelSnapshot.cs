﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksLookup.Models;

namespace ParksLookup.Migrations
{
    [DbContext(typeof(ParksLookupContext))]
    partial class ParksLookupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ParksLookup.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NatlOrState")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Description = "Cool Rocks abounds",
                            Name = "Yosemite",
                            NatlOrState = "National"
                        },
                        new
                        {
                            ParkId = 2,
                            Description = "Theres a bridge made of naturally formed rock candy, wow",
                            Name = "Fake State Park",
                            NatlOrState = "State"
                        },
                        new
                        {
                            ParkId = 3,
                            Description = "This majestic waterfall is actually a bigscreen tv",
                            Name = "False Falls",
                            NatlOrState = "National"
                        },
                        new
                        {
                            ParkId = 4,
                            Description = "It's on the ocean, nice breeze",
                            Name = "Jean Genet Memorial State Park",
                            NatlOrState = "State"
                        },
                        new
                        {
                            ParkId = 5,
                            Description = "All the rocks here are actually rubbery cushions, you can bounce around.  It rules.",
                            Name = "Floppy Canyon",
                            NatlOrState = "National"
                        });
                });

            modelBuilder.Entity("ParksLookup.Models.Tokens", b =>
                {
                    b.Property<int>("TokensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TokensId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("ParksLookup.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
