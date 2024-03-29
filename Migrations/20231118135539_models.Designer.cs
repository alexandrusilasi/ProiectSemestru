﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectSemestru.Data;

#nullable disable

namespace ProiectSemestru.Migrations
{
    [DbContext(typeof(ProiectSemestruContext))]
    [Migration("20231118135539_models")]
    partial class models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectSemestru.Models.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<string>("cnp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConsultationID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationID");

                    b.HasIndex("PatientId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Consultation", b =>
                {
                    b.HasOne("ProiectSemestru.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Patient", b =>
                {
                    b.HasOne("ProiectSemestru.Models.Consultation", null)
                        .WithMany("Patients")
                        .HasForeignKey("ConsultationId");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Visit", b =>
                {
                    b.HasOne("ProiectSemestru.Models.Consultation", "Consultation")
                        .WithMany()
                        .HasForeignKey("ConsultationID");

                    b.HasOne("ProiectSemestru.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Consultation");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ProiectSemestru.Models.Consultation", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
