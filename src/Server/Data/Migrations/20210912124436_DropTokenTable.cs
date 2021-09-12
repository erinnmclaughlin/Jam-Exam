using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class DropTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("038a916f-7e7d-4c4e-9c87-d176dfaa545f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("11f1e328-1aab-482c-b1d4-72cd4bb45fba"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("125552d6-7091-49d6-90ae-36d64841a5a4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b0bbed6-c5d9-4710-b6ba-d5b1a78513f1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b5f36b2-7cf6-4031-bd54-635eeae951d7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8a1e698a-910d-48c1-ad88-eca415d741f1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b7f42f01-477b-4c2c-ba92-0d22f8347369"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cfa58cf7-8613-46e6-91d6-cb5fa8593489"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d97f0a31-108e-4531-8bac-dce7d3509b8c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("da5fbab6-7f98-4278-9cb9-7d45119d059e"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("47f2fa78-78e8-4ea0-b11f-1ee832cdad75"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("580b858f-508a-41cb-82eb-98fced1084be"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("1f5a9ab5-accf-431e-9e8c-3e053d6eedf2"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("ffd580b2-45a2-4448-9b6a-0c8eefa5f921"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("348870e7-40ec-4749-a886-7b1ade7f1a1c"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("37f74247-2065-49b2-81dd-427a1a8097e5"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("38a9b33d-f2eb-4351-96ac-a0e3f1ddd8a4"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("413a7ff3-b311-4ddf-8190-74b393414a90"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("f52c26b4-73bf-499e-bdfb-6d5b7904cb3d"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("f66ab338-41ab-49f0-969b-e052ab614877"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1f5a9ab5-accf-431e-9e8c-3e053d6eedf2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("348870e7-40ec-4749-a886-7b1ade7f1a1c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("37f74247-2065-49b2-81dd-427a1a8097e5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("38a9b33d-f2eb-4351-96ac-a0e3f1ddd8a4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("413a7ff3-b311-4ddf-8190-74b393414a90"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("47f2fa78-78e8-4ea0-b11f-1ee832cdad75"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("580b858f-508a-41cb-82eb-98fced1084be"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f52c26b4-73bf-499e-bdfb-6d5b7904cb3d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f66ab338-41ab-49f0-969b-e052ab614877"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ffd580b2-45a2-4448-9b6a-0c8eefa5f921"));

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("4b5f36b2-7cf6-4031-bd54-635eeae951d7"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("11f1e328-1aab-482c-b1d4-72cd4bb45fba"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("125552d6-7091-49d6-90ae-36d64841a5a4"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("038a916f-7e7d-4c4e-9c87-d176dfaa545f"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("8a1e698a-910d-48c1-ad88-eca415d741f1"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("4b0bbed6-c5d9-4710-b6ba-d5b1a78513f1"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("d97f0a31-108e-4531-8bac-dce7d3509b8c"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("da5fbab6-7f98-4278-9cb9-7d45119d059e"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("b7f42f01-477b-4c2c-ba92-0d22f8347369"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("cfa58cf7-8613-46e6-91d6-cb5fa8593489"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }
    }
}
