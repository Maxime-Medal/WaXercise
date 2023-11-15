using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaXercise.Migrations
{
    /// <inheritdoc />
    public partial class updateSomeThing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPeriod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompagnyId = table.Column<int>(type: "int", nullable: true),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
        }
    }
}
