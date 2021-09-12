using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class RemoveUserFromTokenTableForNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0dc30e8f-cb63-4529-a8c3-28b9d3b1989f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3b749fe0-670a-4cac-9011-79beeddad10d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("48791fb6-3f37-4d5c-b53f-d17aa6cbd0de"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b97be12-5b08-4e00-a58a-d61156bb76af"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("546318a6-07d4-480f-b2b8-16aa48c9751e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ac092197-62a2-4080-bd29-e5d47fc70257"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("babdb4d0-9e06-4fcd-be9c-936a95d265da"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bee6ef2b-14ec-4ce6-8da3-a07e4e8cbb08"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("db843015-c517-40ef-b64c-1dee3cbcd8c9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f4bc73ac-11f9-4d19-85a2-14a7440f4836"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTokens");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "UserTokens",
                newName: "Value");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "UserTokens",
                newName: "Token");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("48791fb6-3f37-4d5c-b53f-d17aa6cbd0de"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("0dc30e8f-cb63-4529-a8c3-28b9d3b1989f"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("f4bc73ac-11f9-4d19-85a2-14a7440f4836"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("db843015-c517-40ef-b64c-1dee3cbcd8c9"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("546318a6-07d4-480f-b2b8-16aa48c9751e"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("3b749fe0-670a-4cac-9011-79beeddad10d"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("ac092197-62a2-4080-bd29-e5d47fc70257"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("bee6ef2b-14ec-4ce6-8da3-a07e4e8cbb08"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("babdb4d0-9e06-4fcd-be9c-936a95d265da"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("4b97be12-5b08-4e00-a58a-d61156bb76af"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
