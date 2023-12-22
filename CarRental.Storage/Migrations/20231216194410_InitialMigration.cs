using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Storage.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    AverageFuelConsumption = table.Column<double>(type: "float", nullable: false),
                    AvailableModels = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "AvailableModels", "AverageFuelConsumption", "CarLocation", "Name", "PriceCategory", "PricePerDay" },
                values: new object[,]
                {
                    { 1, 7, 6.7000000000000002, "Rzeszów", "car1", "Basic", 360.0 },
                    { 2, 1, 8.1999999999999993, "Rzeszów", "car2", "Standard", 460.0 },
                    { 3, 5, 5.2999999999999998, "Warszawa", "car3", "Medium", 525.0 },
                    { 4, 2, 12.1, "Rzeszów", "car4", "Premium", 754.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
