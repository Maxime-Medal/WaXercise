﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaXercise.Data;

#nullable disable

namespace WaXercise.Migrations
{
    [DbContext(typeof(WaXerciseContext))]
    partial class WaXerciseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WaXercise.Models.Compagny", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Compagny");
                });

            modelBuilder.Entity("WaXercise.Models.JobPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompagnyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompagnyId");

                    b.HasIndex("PeopleId");

                    b.ToTable("JobPeriod");
                });

            modelBuilder.Entity("WaXercise.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WaXercise.Models.Compagny", b =>
                {
                    b.HasOne("WaXercise.Models.People", null)
                        .WithMany("Compagnies")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WaXercise.Models.JobPeriod", b =>
                {
                    b.HasOne("WaXercise.Models.Compagny", "Compagny")
                        .WithMany()
                        .HasForeignKey("CompagnyId");

                    b.HasOne("WaXercise.Models.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compagny");

                    b.Navigation("People");
                });

            modelBuilder.Entity("WaXercise.Models.People", b =>
                {
                    b.Navigation("Compagnies");
                });
#pragma warning restore 612, 618
        }
    }
}
