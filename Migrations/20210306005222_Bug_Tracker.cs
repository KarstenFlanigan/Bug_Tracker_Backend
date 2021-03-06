using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bug_Tracker_Backend.Migrations
{
    public partial class Bug_Tracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDeveloper",
                columns: table => new
                {
                    ApplicationsApplicationID = table.Column<int>(type: "int", nullable: false),
                    DevelopersDeveloperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDeveloper", x => new { x.ApplicationsApplicationID, x.DevelopersDeveloperID });
                    table.ForeignKey(
                        name: "FK_ApplicationDeveloper_Applications_ApplicationsApplicationID",
                        column: x => x.ApplicationsApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDeveloper_Developers_DevelopersDeveloperID",
                        column: x => x.DevelopersDeveloperID,
                        principalTable: "Developers",
                        principalColumn: "DeveloperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    DeveloperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Developers",
                        principalColumn: "DeveloperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeveloper_DevelopersDeveloperID",
                table: "ApplicationDeveloper",
                column: "DevelopersDeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicationID",
                table: "Tickets",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DeveloperID",
                table: "Tickets",
                column: "DeveloperID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDeveloper");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
