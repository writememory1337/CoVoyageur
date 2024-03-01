using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "DrivingLicence", "Email", "Firstname", "InscriptionDate", "IsAdmin", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(298), true, "test1@test.com", "Leo", new DateTime(2024, 3, 1, 10, 57, 43, 585, DateTimeKind.Local).AddTicks(1460), true, "Dorat", "Sup4Str0ngP455W0RD!!1" },
                    { 2, new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1708), true, "test2@test.com", "Lea", new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1696), false, "Naconda", "Sup4Str0ngP455W0RD!!2" },
                    { 3, new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1714), true, "test3@test.com", "Leon", new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1712), false, "Sendort", "Sup4Str0ngP455W0RD!!3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
