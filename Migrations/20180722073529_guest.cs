using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackMidwest2018Backend.Migrations
{
    public partial class guest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventGuests",
                columns: table => new
                {
                    EventGuestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(nullable: false),
                    contactGuestId = table.Column<int>(nullable: false),
                    Attending = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuests", x => x.EventGuestId);
                    table.ForeignKey(
                        name: "FK_EventGuests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuests_Contacts_contactGuestId",
                        column: x => x.contactGuestId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventGuests",
                columns: new[] { "EventGuestId", "Attending", "EventId", "contactGuestId" },
                values: new object[] { 1, false, 1, 1 });

            migrationBuilder.InsertData(
                table: "EventGuests",
                columns: new[] { "EventGuestId", "Attending", "EventId", "contactGuestId" },
                values: new object[] { 2, false, 3, 1 });

            migrationBuilder.InsertData(
                table: "EventGuests",
                columns: new[] { "EventGuestId", "Attending", "EventId", "contactGuestId" },
                values: new object[] { 3, false, 2, 2 });

            migrationBuilder.InsertData(
                table: "EventGuests",
                columns: new[] { "EventGuestId", "Attending", "EventId", "contactGuestId" },
                values: new object[] { 4, false, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2018, 7, 22, 2, 35, 28, 965, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_EventGuests_EventId",
                table: "EventGuests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuests_contactGuestId",
                table: "EventGuests",
                column: "contactGuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGuests");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2018, 7, 22, 0, 51, 46, 304, DateTimeKind.Local));
        }
    }
}
