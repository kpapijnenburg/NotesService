using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class UpdatedHandwritingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "HandwrittenTexts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "HandwrittenTexts");

            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 4, 15, 15, 14, 58, 694, DateTimeKind.Local).AddTicks(8180), new DateTime(2020, 4, 15, 15, 14, 58, 694, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 4, 15, 15, 14, 58, 688, DateTimeKind.Local).AddTicks(2471), new DateTime(2020, 4, 15, 15, 14, 58, 691, DateTimeKind.Local).AddTicks(6315) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "HandwrittenTexts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "HandwrittenTexts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HandwrittenTexts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "State", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 26, 11, 5, 27, 800, DateTimeKind.Local).AddTicks(8708), "Pending", new DateTime(2020, 3, 26, 11, 5, 27, 800, DateTimeKind.Local).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 26, 11, 5, 27, 791, DateTimeKind.Local).AddTicks(1251), new DateTime(2020, 3, 26, 11, 5, 27, 794, DateTimeKind.Local).AddTicks(4631) });
        }
    }
}
