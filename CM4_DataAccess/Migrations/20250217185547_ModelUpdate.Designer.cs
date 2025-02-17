﻿// <auto-generated />
using System;
using CM4_DataAccess.DBV1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    [DbContext(typeof(WorldContext))]
    [Migration("20250217185547_ModelUpdate")]
    partial class ModelUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("CM4_Core.Models.Character", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDummy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Parent_Organizations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("CM4_Core.Models.Location", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDummy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CM4_Core.Models.Organization", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Child_Characters")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Child_Organizations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDummy")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("LocationID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Parent_Organizations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrimarySpeciesID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PrimarySpeciesID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("CM4_Core.Models.Species", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDummy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("CM4_Core.Models.Organization", b =>
                {
                    b.HasOne("CM4_Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("CM4_Core.Models.Species", "PrimarySpecies")
                        .WithMany()
                        .HasForeignKey("PrimarySpeciesID");

                    b.Navigation("Location");

                    b.Navigation("PrimarySpecies");
                });
#pragma warning restore 612, 618
        }
    }
}
