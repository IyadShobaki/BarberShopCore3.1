using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop_DataAccess.Migrations
{
    public partial class AddCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_User_Id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_User_Id",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Customer_Id",
                table: "Appointments",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments",
                column: "SalonService_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_Customer_Id",
                table: "Appointments",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_Customer_Id",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Customer_Id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments",
                column: "SalonService_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_User_Id",
                table: "Appointments",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_User_Id",
                table: "Appointments",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
