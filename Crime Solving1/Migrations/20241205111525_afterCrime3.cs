﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crime_Solving1.Migrations
{
    /// <inheritdoc />
    public partial class afterCrime3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonHouseNum = table.Column<int>(type: "int", nullable: false),
                    PersonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalFolder = table.Column<bool>(type: "bit", nullable: false),
                    PAlibi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedId = table.Column<int>(type: "int", nullable: false),
                    ReportPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PastReports = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suspets",
                columns: table => new
                {
                    SuspectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuspectFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectHouseNum = table.Column<int>(type: "int", nullable: false),
                    SAlibi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CriminalFolder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspets", x => x.SuspectId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InForest = table.Column<bool>(type: "bit", nullable: false),
                    CrimeTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SuspectId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_CrimeEvents_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeEvents_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeEvents_Suspets_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "Suspets",
                        principalColumn: "SuspectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvents_PersonId",
                table: "CrimeEvents",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvents_ReportId",
                table: "CrimeEvents",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvents_SuspectId",
                table: "CrimeEvents",
                column: "SuspectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEvents");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Suspets");
        }
    }
}
