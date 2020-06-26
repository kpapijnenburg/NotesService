using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesService.DAL.Migrations
{
    public partial class AddKeyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_User_UserId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25"));

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "User",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserKey",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Key");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 59, 17, 145, DateTimeKind.Local).AddTicks(1125), new DateTime(2020, 6, 17, 11, 59, 17, 148, DateTimeKind.Local).AddTicks(3567) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Key", "Id" },
                values: new object[] { 1, new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25") });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserKey",
                table: "Notes",
                column: "UserKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_User_UserKey",
                table: "Notes",
                column: "UserKey",
                principalTable: "User",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_User_UserKey",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserKey",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "Notes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 11, 16, 56, 34, DateTimeKind.Local).AddTicks(4852), new DateTime(2020, 6, 11, 11, 16, 56, 38, DateTimeKind.Local).AddTicks(117) });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_User_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
