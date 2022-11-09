using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crypto.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crypto",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    current_price = table.Column<double>(type: "float", nullable: false),
                    high_24h = table.Column<double>(type: "float", nullable: false),
                    low_24h = table.Column<double>(type: "float", nullable: false),
                    total_volume = table.Column<double>(type: "float", nullable: false),
                    market_cap = table.Column<double>(type: "float", nullable: false),
                    market_cap_rank = table.Column<double>(type: "float", nullable: false),
                    price_change_24h = table.Column<double>(type: "float", nullable: false),
                    price_change_percentage_24h = table.Column<double>(type: "float", nullable: false),
                    market_cap_change_24h = table.Column<double>(type: "float", nullable: false),
                    market_cap_change_percentage_24h = table.Column<double>(type: "float", nullable: false),
                    total_supply = table.Column<double>(type: "float", nullable: false),
                    max_supply = table.Column<double>(type: "float", nullable: false),
                    ath = table.Column<double>(type: "float", nullable: false),
                    ath_change_percentage = table.Column<double>(type: "float", nullable: false),
                    ath_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crypto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "market_data",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    current_price = table.Column<int>(type: "int", nullable: true),
                    high_24h = table.Column<int>(type: "int", nullable: true),
                    low_24h = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_market_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    asset_platform_id = table.Column<int>(type: "int", nullable: true),
                    block_time_in_minutes = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hashing_algorithm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market_cap_rank = table.Column<int>(type: "int", nullable: true),
                    _market_Dataid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.id);
                    table.ForeignKey(
                        name: "FK_Details_market_data__market_Dataid",
                        column: x => x._market_Dataid,
                        principalTable: "market_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Coin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details__market_Dataid",
                table: "Details",
                column: "_market_Dataid");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_UserId",
                table: "WatchList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crypto");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropTable(
                name: "market_data");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
