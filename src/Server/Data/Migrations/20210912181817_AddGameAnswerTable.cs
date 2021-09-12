using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class AddGameAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0401158a-915a-4814-89ce-483e2709373c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2f63ceca-d59f-48bc-a27b-172aa1b6751e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("723b6836-1911-4785-8cbb-c0f857de775e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8a2bb8f0-a0fa-4379-8d4e-f2ab5efd244c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8d2699ef-f3c0-4e80-9eea-6f7bda902ef1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("98744f94-53b6-469c-a9ec-da9fc3dd8838"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9ad81caa-abb3-44a7-a6cb-2dbb1bfb0279"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a4148812-875f-474d-8082-391ce3448fc5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("aed3ddfe-6ba1-48c9-9b08-042365e55954"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fae6ccda-cf87-476c-8261-5e31f7806a71"));

            migrationBuilder.AddColumn<double>(
                name: "FinalScore",
                table: "Games",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAnswerTime",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfQuestions",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpotifyTrackId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotifyArtistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotifyGuessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeGuessed = table.Column<double>(type: "float", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameAnswers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GameAnswers_GameId",
                table: "GameAnswers",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameAnswers");

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

            migrationBuilder.DropColumn(
                name: "FinalScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MaxAnswerTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberOfQuestions",
                table: "Games");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "SpotifyPlaylistId" },
                values: new object[,]
                {
                    { new Guid("aed3ddfe-6ba1-48c9-9b08-042365e55954"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("8d2699ef-f3c0-4e80-9eea-6f7bda902ef1"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("723b6836-1911-4785-8cbb-c0f857de775e"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("9ad81caa-abb3-44a7-a6cb-2dbb1bfb0279"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("8a2bb8f0-a0fa-4379-8d4e-f2ab5efd244c"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("2f63ceca-d59f-48bc-a27b-172aa1b6751e"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("a4148812-875f-474d-8082-391ce3448fc5"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("98744f94-53b6-469c-a9ec-da9fc3dd8838"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("fae6ccda-cf87-476c-8261-5e31f7806a71"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("0401158a-915a-4814-89ce-483e2709373c"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });
        }
    }
}
