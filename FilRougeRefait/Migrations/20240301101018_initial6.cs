using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ride",
                columns: new[] { "Id", "Arrival", "DateHour", "Departure", "DriverID", "Id_Rider", "NbPlaces", "Price" },
                values: new object[,]
                {
                    { 1, "01/01/2025", new DateTime(2024, 3, 1, 11, 10, 17, 667, DateTimeKind.Local).AddTicks(8647), "01/01/2025", null, 1, 4, 45m },
                    { 2, "02/01/2025", new DateTime(2024, 3, 1, 11, 10, 17, 668, DateTimeKind.Local).AddTicks(132), "02/01/2025", null, 2, 2, 39m }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ride",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(298), new DateTime(2024, 3, 1, 10, 57, 43, 585, DateTimeKind.Local).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1708), new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1696) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "InscriptionDate" },
                values: new object[] { new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1714), new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1712) });
        }
    }
}
