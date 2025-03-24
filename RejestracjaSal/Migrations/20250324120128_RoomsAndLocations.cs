using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejestracjaSal.Migrations
{
    public partial class RoomsAndLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bulding_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Location_id = table.Column<int>(type: "int", nullable: false),
                    Type_id = table.Column<int>(type: "int", nullable: false),
                    Room_price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Type_id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Location_id", "Bulding_code", "City", "Description", "Name", "Street", "Zip_code" },
                values: new object[] { 1, "B01", "Bydgoszcz", "Wejśćie tylnymi drzwiam", "Gimnazjum", "Kamienna 5", "35-705" });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Type_id", "Name" },
                values: new object[] { 1, "Sala naukowa" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Room_id", "Capacity", "Description", "Location_id", "Name", "Room_price", "Type_id" },
                values: new object[,]
                {
                    { 1, 24, "Trzecie pietro", 1, "Sala 31", 50f, 1 },
                    { 2, 24, "Trzecie pietro", 1, "Sala 32", 50f, 1 },
                    { 3, 24, "Trzecie pietro", 1, "Sala 33", 50f, 1 },
                    { 4, 36, "Trzecie pietro", 1, "Sala 34", 75f, 1 },
                    { 5, 16, "Trzecie pietro", 1, "Sala 35", 25f, 1 },
                    { 6, 20, "Trzecie pietro", 1, "Sala 36", 35f, 1 },
                    { 7, 48, "Drugie pietro", 1, "Sala 21", 100f, 1 },
                    { 8, 24, "Drugie pietro", 1, "Sala 22", 50f, 1 },
                    { 9, 24, "Drugie pietro", 1, "Sala 23", 50f, 1 },
                    { 10, 10, "Drugie pietro", 1, "Sala 24", 15f, 1 },
                    { 11, 18, "Drugie pietro", 1, "Sala 25", 35f, 1 },
                    { 12, 18, "Drugie pietro", 1, "Sala 26", 35f, 1 },
                    { 13, 30, "Drugie pietro", 1, "Sala 27", 65f, 1 },
                    { 14, 36, "Drugie pietro", 1, "Sala 28", 80f, 1 },
                    { 15, 36, "Pierwsze pietro", 1, "Sala 11", 75f, 1 },
                    { 16, 18, "Pierwsze pietro", 1, "Sala 12", 50f, 1 },
                    { 17, 24, "Pierwsze pietro", 1, "Sala 13", 75f, 1 },
                    { 18, 24, "Pierwsze pietro", 1, "Sala 14", 46f, 1 },
                    { 19, 28, "Pierwsze pietro", 1, "Sala 15", 75f, 1 },
                    { 20, 24, "Pierwsze pietro", 1, "Sala 16", 50f, 1 },
                    { 21, 12, "Pierwsze pietro", 1, "Sala 17", 25f, 1 },
                    { 22, 12, "Pierwsze pietro", 1, "Sala 18", 25f, 1 },
                    { 23, 12, "Pierwsze pietro", 1, "Sala 19", 50f, 1 },
                    { 24, 24, "Drugie pietro", 1, "Sala 20", 50f, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
