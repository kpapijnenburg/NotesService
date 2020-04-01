using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HandwrittenTextId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HandwrittenTexts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandwrittenTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HandwrittenTexts_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedAt", "HandwrittenTextId", "Title", "UpdatedAt" },
                values: new object[] { 1, "Test Content", new DateTime(2020, 3, 23, 11, 9, 14, 444, DateTimeKind.Local).AddTicks(2579), 1, "Test Title", new DateTime(2020, 3, 23, 11, 9, 14, 447, DateTimeKind.Local).AddTicks(4592) });

            migrationBuilder.InsertData(
                table: "HandwrittenTexts",
                columns: new[] { "Id", "CreatedAt", "Image", "NoteId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7904), null, 1, new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.CreateIndex(
                name: "IX_HandwrittenTexts_NoteId",
                table: "HandwrittenTexts",
                column: "NoteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandwrittenTexts");

            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
