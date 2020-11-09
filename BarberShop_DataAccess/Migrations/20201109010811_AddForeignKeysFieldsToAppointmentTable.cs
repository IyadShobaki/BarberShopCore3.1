using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop_DataAccess.Migrations
{
    public partial class AddForeignKeysFieldsToAppointmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_SalonServices_SalonServiceId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SalonServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SalonServiceId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "SalonService_Id",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Appointments",
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
                name: "FK_Appointments_SalonServices_SalonService_Id",
                table: "Appointments",
                column: "SalonService_Id",
                principalTable: "SalonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_User_Id",
                table: "Appointments",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_SalonServices_SalonService_Id",
                table: "Appointments");

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
                name: "SalonService_Id",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalonServiceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SalonServiceId",
                table: "Appointments",
                column: "SalonServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_SalonServices_SalonServiceId",
                table: "Appointments",
                column: "SalonServiceId",
                principalTable: "SalonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
