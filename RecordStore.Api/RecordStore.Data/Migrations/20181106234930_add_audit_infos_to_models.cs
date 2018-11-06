using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordStore.Data.Migrations
{
    public partial class add_audit_infos_to_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Records",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Records",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Artists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Artists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Artists");
        }
    }
}
