﻿// <auto-generated />
using System;
using Crime_Solving1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crime_Solving1.Migrations
{
    [DbContext(typeof(CrimeContext))]
    [Migration("20241205111525_afterCrime3")]
    partial class afterCrime3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crime_Solving1.Models.CrimeEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrimeStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CrimeTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrimeTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InForest")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("SuspectId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ReportId");

                    b.HasIndex("SuspectId");

                    b.ToTable("CrimeEvents");
                });

            modelBuilder.Entity("Crime_Solving1.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderP")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAlibi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonHouseNum")
                        .HasColumnType("int");

                    b.Property<string>("PersonStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersonalFolder")
                        .HasColumnType("bit");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Crime_Solving1.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("PastReports")
                        .HasColumnType("bit");

                    b.Property<string>("ReportPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReportTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportedId")
                        .HasColumnType("int");

                    b.Property<string>("ReporterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Crime_Solving1.Models.Suspect", b =>
                {
                    b.Property<int>("SuspectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuspectId"));

                    b.Property<bool>("CriminalFolder")
                        .HasColumnType("bit");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("SAlibi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuspectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuspectFname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuspectHouseNum")
                        .HasColumnType("int");

                    b.Property<string>("SuspectLname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuspectStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuspectTown")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuspectId");

                    b.ToTable("Suspets");
                });

            modelBuilder.Entity("Crime_Solving1.Models.CrimeEvent", b =>
                {
                    b.HasOne("Crime_Solving1.Models.Person", "Person")
                        .WithMany("Events")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crime_Solving1.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crime_Solving1.Models.Suspect", "Suspect")
                        .WithMany("CrimeEvents")
                        .HasForeignKey("SuspectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Report");

                    b.Navigation("Suspect");
                });

            modelBuilder.Entity("Crime_Solving1.Models.Person", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Crime_Solving1.Models.Suspect", b =>
                {
                    b.Navigation("CrimeEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
