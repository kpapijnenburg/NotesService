using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class AddedStateToHandwriting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "HandwrittenTexts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "State", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 13, 10, 5, 397, DateTimeKind.Local).AddTicks(345), "Pending", new DateTime(2020, 3, 23, 13, 10, 5, 397, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 13, 10, 5, 386, DateTimeKind.Local).AddTicks(7718), new DateTime(2020, 3, 23, 13, 10, 5, 390, DateTimeKind.Local).AddTicks(5935) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "HandwrittenTexts");

            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7904), new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 23, 11, 9, 14, 444, DateTimeKind.Local).AddTicks(2579), new DateTime(2020, 3, 23, 11, 9, 14, 447, DateTimeKind.Local).AddTicks(4592) });
        }
    }
}
