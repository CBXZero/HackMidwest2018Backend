using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackMidwest2018Backend.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.UniqueConstraint("AltKey_Contact_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    BringAFriend = table.Column<bool>(nullable: false),
                    DressCode = table.Column<string>(nullable: true),
                    PublicEvent = table.Column<bool>(nullable: false),
                    OwnerContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Contacts_OwnerContactId",
                        column: x => x.OwnerContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    ContributionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Contributer = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.ContributionId);
                    table.ForeignKey(
                        name: "FK_Contributions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Chosen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "ItsMeATeddy@gmail.com", "Teddy", "Ivarock", "5555555555" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "tripleTheCharliTripleTheFun@gmail.com", "Charlie L", "Ivarock", "5555555555" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, "cbesalke@gmail.com", "Charlie", "Besalke", "5555555555" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BringAFriend", "Description", "DressCode", "Location", "OwnerContactId", "PublicEvent", "Title", "Website" },
                values: new object[] { 2, false, "I'm lonely and need a party", null, null, 1, false, "Teddy's house warming", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BringAFriend", "Description", "DressCode", "Location", "OwnerContactId", "PublicEvent", "Title", "Website" },
                values: new object[] { 1, false, "Party!", null, null, 2, false, "Charlie Board gaming", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BringAFriend", "Description", "DressCode", "Location", "OwnerContactId", "PublicEvent", "Title", "Website" },
                values: new object[] { 3, false, "Charlie will likely win!", null, null, 3, false, "Charlie Cube Tournament!", null });

            migrationBuilder.InsertData(
                table: "Contributions",
                columns: new[] { "ContributionId", "Contributer", "Description", "EventId" },
                values: new object[] { 1, null, "10 pounds of ground beef", 1 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "Chosen", "EventDate", "EventId" },
                values: new object[] { 1, false, new DateTime(2018, 7, 22, 1, 42, 44, 263, DateTimeKind.Local), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_EventId",
                table: "Contributions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerContactId",
                table: "Events",
                column: "OwnerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EventId",
                table: "Schedules",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
