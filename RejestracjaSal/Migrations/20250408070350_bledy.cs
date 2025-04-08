using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class bledy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Image",
                value: "sala-lekcyjna19.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 1,
                column: "Role_id",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Image",
                value: "sala-lekcyjna19.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_id",
                keyValue: 1,
                column: "Role_id",
                value: 3);
        }
    }
}
