using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class SeedDbWithGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("bdba9497-15f2-4bab-a77f-6890606d590a"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("0c976168-092f-46e8-8793-c9203761a9a7"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("40a3e349-7bcd-430e-b09a-e0ee798655a3"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("220130da-e7a3-469d-aee3-e066bb03a868"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("2c6e0ea7-5c56-4501-966f-0c7e624b4444"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("89518d23-4046-4d0a-aeec-9672cfcae5cb"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("ad552299-a5d0-4258-b6e3-a91ea0e953fb"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("71efb072-1c82-4735-bd15-b20e71adeb41"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("8fd662ae-1cab-4063-838d-eb2ee9a7f47c"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("9767f1c3-07e2-4089-a4d3-be57e1033897"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c976168-092f-46e8-8793-c9203761a9a7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("220130da-e7a3-469d-aee3-e066bb03a868"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2c6e0ea7-5c56-4501-966f-0c7e624b4444"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("40a3e349-7bcd-430e-b09a-e0ee798655a3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("71efb072-1c82-4735-bd15-b20e71adeb41"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("89518d23-4046-4d0a-aeec-9672cfcae5cb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8fd662ae-1cab-4063-838d-eb2ee9a7f47c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9767f1c3-07e2-4089-a4d3-be57e1033897"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ad552299-a5d0-4258-b6e3-a91ea0e953fb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bdba9497-15f2-4bab-a77f-6890606d590a"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genres");
        }
    }
}
