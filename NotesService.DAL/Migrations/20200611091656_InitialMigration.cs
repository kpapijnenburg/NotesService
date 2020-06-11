using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                column: "Id",
                value: new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25"));

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CreatedAt", "ImageData", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(2020, 6, 11, 11, 16, 56, 34, DateTimeKind.Local).AddTicks(4852), new byte[] {  }, "Test Notitie", new DateTime(2020, 6, 11, 11, 16, 56, 38, DateTimeKind.Local).AddTicks(117), new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25") });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
