using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class AddRefreshTokenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2297f066-900f-4f89-bcb4-353313c21f82"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3bc1fc3c-e265-4c49-b1b7-fff6502dcd38"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("569b1118-7a45-4581-a042-4cd69c87d082"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6e881121-e92f-44ef-8237-a39c687b29d2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("82ece384-6b20-4f82-9c47-839efd95b500"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("95c26c11-7bd5-4928-b36e-d545d1ab0c9d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("abc31289-adfc-4d3d-a707-277d2717a1ab"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b75b7270-2e26-46a9-b622-81b0804c9f53"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c142c64c-618a-4f86-a304-19f781ee0da7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cb40d10f-f83a-483d-ba6e-fc02a1ae74bd"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("03b32e9a-eacf-4762-a9c1-73572d1ea519"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("7849aff8-87b0-4fbe-88e4-871ec35ed32b"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("85686fa8-b9d0-4de4-8e74-3fb46d878de7"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("0d44803d-ed47-40e2-973c-6f2230b2e2ba"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("b52b751f-fba2-4c37-bc3f-283689b9b3a8"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("1a4650ee-8b01-4e7d-8cfa-fa54a0582af3"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("0c8663ce-a669-43ed-90ff-022bb9197aa6"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("9b3540e0-e9cd-4e04-b46c-c0069d700bd6"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("785d11c9-5a34-488f-b9cf-a4152a7cc6da"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("9495252d-f1a4-4b62-9203-e60e5eaf04c6"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("03b32e9a-eacf-4762-a9c1-73572d1ea519"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c8663ce-a669-43ed-90ff-022bb9197aa6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0d44803d-ed47-40e2-973c-6f2230b2e2ba"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1a4650ee-8b01-4e7d-8cfa-fa54a0582af3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7849aff8-87b0-4fbe-88e4-871ec35ed32b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("785d11c9-5a34-488f-b9cf-a4152a7cc6da"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("85686fa8-b9d0-4de4-8e74-3fb46d878de7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9495252d-f1a4-4b62-9203-e60e5eaf04c6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9b3540e0-e9cd-4e04-b46c-c0069d700bd6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b52b751f-fba2-4c37-bc3f-283689b9b3a8"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "UserTokens");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("c142c64c-618a-4f86-a304-19f781ee0da7"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("95c26c11-7bd5-4928-b36e-d545d1ab0c9d"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("6e881121-e92f-44ef-8237-a39c687b29d2"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("abc31289-adfc-4d3d-a707-277d2717a1ab"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("2297f066-900f-4f89-bcb4-353313c21f82"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("569b1118-7a45-4581-a042-4cd69c87d082"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("3bc1fc3c-e265-4c49-b1b7-fff6502dcd38"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("cb40d10f-f83a-483d-ba6e-fc02a1ae74bd"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("82ece384-6b20-4f82-9c47-839efd95b500"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("b75b7270-2e26-46a9-b622-81b0804c9f53"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }
    }
}
