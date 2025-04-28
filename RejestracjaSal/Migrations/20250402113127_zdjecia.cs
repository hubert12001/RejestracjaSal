using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class zdjecia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Image",
                value: "sala-lekcyjna4.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Image",
                value: "sala-lekcyjna17.png");
        }
    }
}
