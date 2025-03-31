using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class mam_dosc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 7,
                column: "Image",
                value: "sala-lekcyjna7.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 7,
                column: "Image",
                value: "sala-lekcyjna25.jpg");
        }
    }
}
