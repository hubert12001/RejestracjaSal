using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class naprawa_zdjec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Image",
                value: "sala-lekcyjna17.jpg");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Image",
                value: "sala-lekcyjna19.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Image",
                value: "sala-lekcyjna4.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Image",
                value: "sala-lekcyjna19.png");
        }
    }
}
