using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class AddUserTokensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");

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
    }
}
