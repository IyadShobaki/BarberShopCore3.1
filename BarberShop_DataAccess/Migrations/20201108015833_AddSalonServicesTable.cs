using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop_DataAccess.Migrations
{
    public partial class AddSalonServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalonServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(maxLength: 50, nullable: false),
                    ServiceDescription = table.Column<string>(maxLength: 4000, nullable: false),
                    ServiceDuration = table.Column<int>(nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalonServices");
        }
    }
}
