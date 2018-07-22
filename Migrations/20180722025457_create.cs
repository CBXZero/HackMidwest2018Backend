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
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
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
                values: new object[] { 1, null, "Teddy", "Ivarock", "5555555555" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, null, "Charlie L", "Ivarock", "5555555555" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "Name", "OwnerContactId" },
                values: new object[] { 1, "I'm lonely and need a party", "Teddy's house warming", 1 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "Name", "OwnerContactId" },
                values: new object[] { 2, "Party!", "Charlie Board gaming", 2 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "EventDate", "EventId" },
                values: new object[] { 1, new DateTime(2018, 7, 21, 21, 54, 57, 225, DateTimeKind.Local), 1 });

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
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
