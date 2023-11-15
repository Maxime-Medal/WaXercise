using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaXercise.Migrations
{
    /// <inheritdoc />
    public partial class updateCompagny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPeriod_Work_WorkId",
                table: "JobPeriod");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropIndex(
                name: "IX_JobPeriod_WorkId",
                table: "JobPeriod");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "JobPeriod",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CompagnyId",
                table: "JobPeriod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compagny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagny", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compagny_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_CompagnyId",
                table: "JobPeriod",
                column: "CompagnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Compagny_PeopleId",
                table: "Compagny",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPeriod_Compagny_CompagnyId",
                table: "JobPeriod",
                column: "CompagnyId",
                principalTable: "Compagny",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPeriod_Compagny_CompagnyId",
                table: "JobPeriod");

            migrationBuilder.DropTable(
                name: "Compagny");

            migrationBuilder.DropIndex(
                name: "IX_JobPeriod_CompagnyId",
                table: "JobPeriod");

            migrationBuilder.DropColumn(
                name: "CompagnyId",
                table: "JobPeriod");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "JobPeriod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPeriod_WorkId",
                table: "JobPeriod",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_PeopleId",
                table: "Work",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPeriod_Work_WorkId",
                table: "JobPeriod",
                column: "WorkId",
                principalTable: "Work",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
