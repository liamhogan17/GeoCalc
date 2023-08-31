﻿// <auto-generated />
using System;
using GeoCalc.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeoCalc.Migrations
{
    [DbContext(typeof(GeoCalcContext))]
    partial class GeoCalcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeoCalc.Data.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WholeGradeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WholeGradeId");

                    b.HasIndex("Id", "Name", "Subject", "Grade", "Description")
                        .IsUnique()
                        .HasFilter("[Description] IS NOT NULL");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("GeoCalc.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("GeoCalc.Data.Entities.WholeGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Grade")
                        .IsUnique();

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("GeoCalc.Data.Entities.Class", b =>
                {
                    b.HasOne("GeoCalc.Data.Entities.User", null)
                        .WithMany("Classes")
                        .HasForeignKey("UserId");

                    b.HasOne("GeoCalc.Data.Entities.WholeGrade", null)
                        .WithMany("Classes")
                        .HasForeignKey("WholeGradeId");
                });

            modelBuilder.Entity("GeoCalc.Data.Entities.User", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("GeoCalc.Data.Entities.WholeGrade", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}