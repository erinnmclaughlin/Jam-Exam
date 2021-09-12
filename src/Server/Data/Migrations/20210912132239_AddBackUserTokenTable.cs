using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class AddBackUserTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
    }
}
