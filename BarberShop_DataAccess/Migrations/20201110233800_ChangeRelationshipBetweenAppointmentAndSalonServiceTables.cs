using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop_DataAccess.Migrations
{
    public partial class ChangeRelationshipBetweenAppointmentAndSalonServiceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSalonServices");

            migrationBuilder.AddColumn<int>(
                name: "SalonService_Id",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments",
                column: "SalonService_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_SalonServices_SalonService_Id",
                table: "Appointments",
                column: "SalonService_Id",
                principalTable: "SalonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_SalonServices_SalonService_Id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SalonService_Id",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SalonService_Id",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "AppointmentSalonServices",
                columns: table => new
                {
                    Appointment_Id = table.Column<int>(type: "int", nullable: false),
                    SalonService_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSalonServices", x => new { x.Appointment_Id, x.SalonService_Id });
                    table.ForeignKey(
                        name: "FK_AppointmentSalonServices_Appointments_Appointment_Id",
                        column: x => x.Appointment_Id,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentSalonServices_SalonServices_SalonService_Id",
                        column: x => x.SalonService_Id,
                        principalTable: "SalonServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSalonServices_SalonService_Id",
                table: "AppointmentSalonServices",
                column: "SalonService_Id");
        }
    }
}
