using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordStore.Data.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Created", "FirstName", "LastName", "Modified" },
                values: new object[] { 1, new DateTime(2018, 11, 23, 22, 38, 1, 980, DateTimeKind.Utc), "David", "Bowie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Created", "FirstName", "LastName", "Modified" },
                values: new object[] { 2, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), "Chet", "Atkins", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 1, 1, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1969, "Space Oddity" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 2, 1, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1970, "The Man Who Sold The World" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 3, 1, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1971, "Hunky Dory" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 4, 1, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1972, "The Rise and Fall of Ziggy Stardust and the Spiders from Mars" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 5, 1, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1973, "Aladdin Sane" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "ArtistId", "Created", "Modified", "ReleaseYear", "Title" },
                values: new object[] { 6, 2, new DateTime(2018, 11, 23, 22, 38, 1, 982, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1964, "My Favorite Guitars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "RecordId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);
        }
    }
}
