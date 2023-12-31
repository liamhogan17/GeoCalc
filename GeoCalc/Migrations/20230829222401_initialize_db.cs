﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoCalc.Migrations
{
    /// <inheritdoc />
    public partial class initialize_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WholeGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Grade_WholeGradeId",
                        column: x => x.WholeGradeId,
                        principalTable: "Grade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Class_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_Id_Name_Subject_Grade_Description",
                table: "Class",
                columns: new[] { "Id", "Name", "Subject", "Grade", "Description" },
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Class_UserId",
                table: "Class",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_WholeGradeId",
                table: "Class",
                column: "WholeGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Id_Grade",
                table: "Grade",
                columns: new[] { "Id", "Grade" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id_Name",
                table: "User",
                columns: new[] { "Id", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
