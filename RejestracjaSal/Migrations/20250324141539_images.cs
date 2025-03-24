using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 1,
                column: "Image",
                value: "sala-lekcyjna1.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 2,
                column: "Image",
                value: "sala-lekcyjna2.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 3,
                column: "Image",
                value: "sala-lekcyjna3.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 4,
                column: "Image",
                value: "sala-lekcyjna4.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 5,
                column: "Image",
                value: "sala-lekcyjna5.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 6,
                column: "Image",
                value: "sala-lekcyjna6.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 7,
                column: "Image",
                value: "sala-lekcyjna7.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 8,
                column: "Image",
                value: "sala-lekcyjna8.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 9,
                column: "Image",
                value: "sala-lekcyjna9.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 10,
                column: "Image",
                value: "sala-lekcyjna10.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 11,
                column: "Image",
                value: "sala-lekcyjna11.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 12,
                column: "Image",
                value: "sala-lekcyjna12.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 13,
                column: "Image",
                value: "sala-lekcyjna13.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 14,
                column: "Image",
                value: "sala-lekcyjna14.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 15,
                column: "Image",
                value: "sala-lekcyjna15.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 16,
                column: "Image",
                value: "sala-lekcyjna16.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 17,
                column: "Image",
                value: "sala-lekcyjna17.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 18,
                column: "Image",
                value: "sala-lekcyjna18.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 19,
                column: "Image",
                value: "sala-lekcyjna19.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 20,
                column: "Image",
                value: "sala-lekcyjna20.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 21,
                column: "Image",
                value: "sala-lekcyjna21.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 22,
                column: "Image",
                value: "sala-lekcyjna22.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 23,
                column: "Image",
                value: "sala-lekcyjna23.png");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_id",
                keyValue: 24,
                column: "Image",
                value: "sala-lekcyjna24.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Rooms");
        }
    }
}
