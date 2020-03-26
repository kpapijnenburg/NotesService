using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class SetNotesCascadeDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 26, 11, 5, 27, 800, DateTimeKind.Local).AddTicks(8708), new DateTime(2020, 3, 26, 11, 5, 27, 800, DateTimeKind.Local).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 26, 11, 5, 27, 791, DateTimeKind.Local).AddTicks(1251), new DateTime(2020, 3, 26, 11, 5, 27, 794, DateTimeKind.Local).AddTicks(4631) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 13, 10, 5, 397, DateTimeKind.Local).AddTicks(345), new DateTime(2020, 3, 23, 13, 10, 5, 397, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 13, 10, 5, 386, DateTimeKind.Local).AddTicks(7718), new DateTime(2020, 3, 23, 13, 10, 5, 390, DateTimeKind.Local).AddTicks(5935) });
        }
    }
}
