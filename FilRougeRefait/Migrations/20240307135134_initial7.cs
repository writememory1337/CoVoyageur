using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Ride_TravelID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_PassengerID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_TravelID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PassengerID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "TravelID",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "Statuts",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateHour",
                value: new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateHour",
                value: new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(4971), new DateTime(2024, 3, 7, 14, 51, 33, 848, DateTimeKind.Local).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(6452), new DateTime(2024, 3, 7, 14, 51, 33, 850, DateTimeKind.Local).AddTicks(6451) });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Id_Passenger",
                table: "Reservation",
                column: "Id_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Id_Ride",
                table: "Reservation",
                column: "Id_Ride");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Ride_Id_Ride",
                table: "Reservation",
                column: "Id_Ride",
                principalTable: "Ride",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_Id_Passenger",
                table: "Reservation",
                column: "Id_Passenger",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Ride_Id_Ride",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_Id_Passenger",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Id_Passenger",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Id_Ride",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "Statuts",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PassengerID",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelID",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateHour",
                value: new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateHour",
                value: new DateTime(2024, 3, 1, 11, 10, 17, 668, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 3, 1, 11, 10, 17, 665, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(7230), new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(7236), new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(7234) });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TravelID",
                table: "Reservation",
                column: "TravelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Ride_TravelID",
                table: "Reservation",
                column: "TravelID",
                principalTable: "Ride",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_PassengerID",
                table: "Reservation",
                column: "PassengerID",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
