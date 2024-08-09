﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetProfile.Data;

#nullable disable

namespace PetProfile.Data.Migrations
{
    [DbContext(typeof(PetProfileContext))]
    partial class PetProfileContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("PetProfile.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("PetProfile.Entities.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dog"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bird"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hamster"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Snake"
                        });
                });

            modelBuilder.Entity("PetProfile.Entities.Pet", b =>
                {
                    b.HasOne("PetProfile.Entities.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });
#pragma warning restore 612, 618
        }
    }
}
