using Microsoft.EntityFrameworkCore.Migrations;

namespace Kladionica.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<int>(type: "int", nullable: false),
                    ClubName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Multiplier1 = table.Column<double>(type: "float", nullable: false),
                    Multiplier2 = table.Column<double>(type: "float", nullable: false),
                    MultiplierX = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<int>(type: "int", nullable: false),
                    Stake = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    Payout = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameTicket",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    TicketsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTicket", x => new { x.GameID, x.TicketsID });
                    table.ForeignKey(
                        name: "FK_GameTicket_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTicket_Tickets_TicketsID",
                        column: x => x.TicketsID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketUser",
                columns: table => new
                {
                    TicketsID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketUser", x => new { x.TicketsID, x.UserID });
                    table.ForeignKey(
                        name: "FK_TicketUser_Tickets_TicketsID",
                        column: x => x.TicketsID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketUser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTicket_TicketsID",
                table: "GameTicket",
                column: "TicketsID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketUser_UserID",
                table: "TicketUser",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTicket");

            migrationBuilder.DropTable(
                name: "TicketUser");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
