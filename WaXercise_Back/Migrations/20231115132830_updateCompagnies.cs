﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaXercise.Migrations
{
    /// <inheritdoc />
    public partial class updateCompagnies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Compagny",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Compagny",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Compagny");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Compagny");
        }
    }
}
