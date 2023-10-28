using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    TotalGuessed = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameResults_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_PlayerName",
                table: "GameResults",
                column: "PlayerName");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_PlaylistId",
                table: "GameResults",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_Timestamp",
                table: "GameResults",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SpotifyId",
                table: "Playlists",
                column: "SpotifyId",
                unique: true);

            migrationBuilder.Sql("""
                INSERT INTO GameResults(PlayerName, TotalCorrect, TotalGuessed, Timestamp, PlaylistId)
                SELECT [hs].[Name], [hs].[Correct], [hs].[Total], [hs].[Timestamp], [p].[Id]
                FROM HighScores [hs]
                LEFT JOIN Playlists [p] ON [p].[SpotifyId] = [hs].[PlaylistId]
                """);

            migrationBuilder.DropTable(
                name: "HighScores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HighScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correct = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlaylistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighScores", x => x.Id);
                });

            migrationBuilder.Sql("""
                INSERT INTO HighScores(Name, Correct, Total, Timestamp, PlaylistId)
                SELECT [g].[PlayerName], [g].[TotalCorrect], [g].[TotalGuessed], [g].[Timestamp], [p].[SpotifyId]
                FROM GameResults [g]
                LEFT JOIN Playlists [p] on [p].[Id] = [g].[PlaylistId]
                """);

            migrationBuilder.DropTable(
                name: "GameResults");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
