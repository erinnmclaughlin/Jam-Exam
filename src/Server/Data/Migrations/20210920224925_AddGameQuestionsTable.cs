using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class AddGameQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameAnswers_Games_GameId",
                table: "GameAnswers");

            migrationBuilder.DropIndex(
                name: "IX_GameAnswers_GameId",
                table: "GameAnswers");

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
                name: "GameId",
                table: "GameAnswers");

            migrationBuilder.DropColumn(
                name: "SpotifyArtistId",
                table: "GameAnswers");

            migrationBuilder.DropColumn(
                name: "SpotifyTrackId",
                table: "GameAnswers");

            migrationBuilder.RenameColumn(
                name: "TimeGuessed",
                table: "GameAnswers",
                newName: "GuessedIn");

            migrationBuilder.AlterColumn<string>(
                name: "SpotifyGuessId",
                table: "GameAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GameQuestionId",
                table: "GameAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GameQuestionId1",
                table: "GameAnswers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpotifyTrackId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotifyArtistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameQuestions_Games_GameId",
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
                    { new Guid("b0aaca00-b148-4f89-8931-dc0167b3d8f2"), "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                    { new Guid("24473c5d-2722-4d1b-a006-afbd56d5573f"), "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                    { new Guid("6144c08e-00b9-45d0-8fa2-8ba3e1505d9c"), "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                    { new Guid("7c1aa3ec-36d3-45e7-8180-2813aa294241"), "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                    { new Guid("239dd819-bd02-43e1-bec0-6a7c0b0d1335"), "Country", "37i9dQZF1DX1lVhptIYRda" },
                    { new Guid("3796e900-4995-424f-a3fd-71aecefb38a8"), "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                    { new Guid("075525e1-99e1-4971-a83d-6e9bc26100db"), "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                    { new Guid("511e3718-0383-43cc-8eee-c0fc0423df2f"), "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                    { new Guid("0ccf0797-aeb4-4497-b309-ae21b17f7df4"), "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                    { new Guid("3a3abb17-1ccc-475e-a3ca-3e4a5eee7e78"), "2000s", "37i9dQZF1DX4o1oenSJRJd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAnswers_GameQuestionId1",
                table: "GameAnswers",
                column: "GameQuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameQuestions_GameId",
                table: "GameQuestions",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameAnswers_GameQuestions_GameQuestionId1",
                table: "GameAnswers",
                column: "GameQuestionId1",
                principalTable: "GameQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameAnswers_GameQuestions_GameQuestionId1",
                table: "GameAnswers");

            migrationBuilder.DropTable(
                name: "GameQuestions");

            migrationBuilder.DropIndex(
                name: "IX_GameAnswers_GameQuestionId1",
                table: "GameAnswers");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("075525e1-99e1-4971-a83d-6e9bc26100db"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0ccf0797-aeb4-4497-b309-ae21b17f7df4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("239dd819-bd02-43e1-bec0-6a7c0b0d1335"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("24473c5d-2722-4d1b-a006-afbd56d5573f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3796e900-4995-424f-a3fd-71aecefb38a8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3a3abb17-1ccc-475e-a3ca-3e4a5eee7e78"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("511e3718-0383-43cc-8eee-c0fc0423df2f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6144c08e-00b9-45d0-8fa2-8ba3e1505d9c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7c1aa3ec-36d3-45e7-8180-2813aa294241"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b0aaca00-b148-4f89-8931-dc0167b3d8f2"));

            migrationBuilder.DropColumn(
                name: "GameQuestionId",
                table: "GameAnswers");

            migrationBuilder.DropColumn(
                name: "GameQuestionId1",
                table: "GameAnswers");

            migrationBuilder.RenameColumn(
                name: "GuessedIn",
                table: "GameAnswers",
                newName: "TimeGuessed");

            migrationBuilder.AlterColumn<string>(
                name: "SpotifyGuessId",
                table: "GameAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "GameAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SpotifyArtistId",
                table: "GameAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpotifyTrackId",
                table: "GameAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_GameAnswers_GameId",
                table: "GameAnswers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameAnswers_Games_GameId",
                table: "GameAnswers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
