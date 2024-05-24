using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedAt", "CreatedBy", "DateOfBirth", "EmpFirstName", "EmpLastName", "IsDeleted", "ModifiedAt", "ModifiedBy", "SalesOfficeId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("0197f334-8f09-41f3-8ec8-f94a9d7d63e7"), 30, null, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", false, null, null, new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"), 40, null, null, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, null, new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"),
                column: "ManagerId",
                value: new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"));

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"),
                column: "ManagerId",
                value: new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0197f334-8f09-41f3-8ec8-f94a9d7d63e7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"));

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"),
                column: "ManagerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"),
                column: "ManagerId",
                value: null);
        }
    }
}
