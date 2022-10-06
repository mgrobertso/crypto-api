using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crypto_api.Migrations
{
    public partial class crypto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Last_update = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Current_price = table.Column<double>(type: "float", nullable: false),
                    High_24h = table.Column<double>(type: "float", nullable: false),
                    Low_24h = table.Column<double>(type: "float", nullable: false),
                    Total_volume = table.Column<double>(type: "float", nullable: false),
                    market_cap = table.Column<double>(type: "float", nullable: false),
                    market_cap_rank = table.Column<double>(type: "float", nullable: false),
                    fully_diluted_valuation = table.Column<double>(type: "float", nullable: false),
                    price_change_24h = table.Column<double>(type: "float", nullable: false),
                    price_change_percentage_24h = table.Column<double>(type: "float", nullable: false),
                    market_cap_change_24h = table.Column<double>(type: "float", nullable: false),
                    market_cap_change_percentage_24h = table.Column<double>(type: "float", nullable: false),
                    total_supply = table.Column<double>(type: "float", nullable: false),
                    max_supply = table.Column<double>(type: "float", nullable: false),
                    ath = table.Column<double>(type: "float", nullable: false),
                    ath_change_percentage = table.Column<double>(type: "float", nullable: false),
                    ath_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    roi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "WatchList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WatchId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WatchList");
        }
    }
}
