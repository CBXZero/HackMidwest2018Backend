using Microsoft.EntityFrameworkCore.Migrations;

namespace HackMidwest2018Backend.Migrations
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, null, "Teddy", "Ivarock", "5555555555" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "Name", "OwnerContactId" },
                values: new object[] { 1, "I'm lonely and need a party", "Teddy's house warming", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1);
        }
    }
}
