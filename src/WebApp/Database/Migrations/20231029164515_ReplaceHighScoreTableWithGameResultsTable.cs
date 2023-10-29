using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Database.Migrations;

/// <inheritdoc />
public partial class ReplaceHighScoreTableWithGameResultsTable : Migration
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
                PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                PlaylistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TotalCorrect = table.Column<int>(type: "int", nullable: false),
                TotalGuessed = table.Column<int>(type: "int", nullable: false),
                Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GameResults", x => x.Id);
            });

        // At this point in migration history, preserving id column is not a concern
        migrationBuilder.Sql("""
                INSERT INTO GameResults(PlayerName, PlaylistId, TotalCorrect, TotalGuessed, Timestamp)
                SELECT Name, PlaylistId, Correct, Total, Timestamp
                FROM HighScores
                """);

        migrationBuilder.CreateIndex(
            name: "IX_GameResults_PlayerName",
            table: "GameResults",
            column: "PlayerName");

        migrationBuilder.CreateIndex(
            name: "IX_GameResults_Timestamp",
            table: "GameResults",
            column: "Timestamp");

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


        // At this point in migration history, preserving id column is not a concern
        migrationBuilder.Sql("""
                INSERT INTO HighScores(Name, PlaylistId, Correct, Total, Timestamp)
                SELECT PlayerName, PlaylistId, TotalCorrect, TotalGuessed, Timestamp
                FROM GameResults
                """);

        migrationBuilder.DropTable(
            name: "GameResults");

    }
}
