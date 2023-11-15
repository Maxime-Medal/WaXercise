using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaXercise.Migrations
{
    /// <inheritdoc />
    public partial class addJobPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPeriod_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPeriod_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_PeopleId",
                table: "JobPeriod",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_WorkId",
                table: "JobPeriod",
                column: "WorkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPeriod");
        }
    }
}
