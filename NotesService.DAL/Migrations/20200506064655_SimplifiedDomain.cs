using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class SimplifiedDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandwrittenTexts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "HandwrittenTextId",
                table: "Notes");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Notes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageData", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 5, 6, 8, 46, 54, 921, DateTimeKind.Local).AddTicks(8343), new byte[] {  }, null, new DateTime(2020, 5, 6, 8, 46, 54, 924, DateTimeKind.Local).AddTicks(7562) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HandwrittenTextId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HandwrittenTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                table: "HandwrittenTexts",
                columns: new[] { "Id", "CreatedAt", "NoteId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 4, 15, 15, 14, 58, 694, DateTimeKind.Local).AddTicks(8180), 1, new DateTime(2020, 4, 15, 15, 14, 58, 694, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedAt", "HandwrittenTextId", "Title", "UpdatedAt" },
                values: new object[] { "Test Content", new DateTime(2020, 4, 15, 15, 14, 58, 688, DateTimeKind.Local).AddTicks(2471), 1, "Test Title", new DateTime(2020, 4, 15, 15, 14, 58, 691, DateTimeKind.Local).AddTicks(6315) });

            migrationBuilder.CreateIndex(
                name: "IX_HandwrittenTexts_NoteId",
                table: "HandwrittenTexts",
                column: "NoteId",
                unique: true);
        }
    }
}
