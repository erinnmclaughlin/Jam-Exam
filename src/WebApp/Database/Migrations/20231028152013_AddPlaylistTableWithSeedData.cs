using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylistTableWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    TotalGuessed = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotifyId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Name", "SpotifyId" },
                values: new object[,]
                {
                    { 1, "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { 2, "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { 3, "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { 4, "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { 5, "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { 6, "1960's", "37i9dQZF1DWWzBc3TOlaAV" },
                    { 7, "1970's", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { 8, "1980's", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { 9, "1990's", "37i9dQZF1DXbTxeAdrVG2l" },
                    { 10, "2000's", "37i9dQZF1DX4o1oenSJRJd" },
                    { 11, "All Time Hits", "6i2Qd6OpeRBAzxfscNXeWp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_PlayerName",
                table: "GameResults",
                column: "PlayerName");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_Timestamp",
                table: "GameResults",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SpotifyId",
                table: "Playlists",
                column: "SpotifyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResults");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
