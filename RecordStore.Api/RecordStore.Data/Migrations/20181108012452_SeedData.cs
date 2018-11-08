using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordStore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Created", "FirstName", "LastName", "Modified" },
                values: new object[] { 1, DateTime.UtcNow, "David", "Bowie", DateTime.UtcNow });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 1, 1, DateTime.UtcNow, DateTime.UtcNow, 1973, "Aladdin Sane" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);
        }
    }
}
