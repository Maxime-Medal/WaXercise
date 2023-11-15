using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaXercise.Migrations
{
    /// <inheritdoc />
    public partial class ImLost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compagny_People_PeopleId",
                table: "Compagny");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Compagny",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JobPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    CompagnyId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPeriod_Compagny_CompagnyId",
                        column: x => x.CompagnyId,
                        principalTable: "Compagny",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPeriod_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_CompagnyId",
                table: "JobPeriod",
                column: "CompagnyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_PeopleId",
                table: "JobPeriod",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compagny_People_PeopleId",
                table: "Compagny",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compagny_People_PeopleId",
                table: "Compagny");

            migrationBuilder.DropTable(
                name: "JobPeriod");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Compagny",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compagny_People_PeopleId",
                table: "Compagny",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
