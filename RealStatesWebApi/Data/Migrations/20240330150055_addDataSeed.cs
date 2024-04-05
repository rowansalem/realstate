using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "City", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "State", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"), "123 Main St", "Texas City", null, null, null, null, "Texas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" },
                    { new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"), "123 Victore St", "Alexandria", null, null, null, null, "Alex", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "OwnerFirstName", "OwnerLastName", "Timestamp" },
                values: new object[] { new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), null, null, null, null, "Jane", "Smith", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Timestamp", "UserEmail" },
                values: new object[] { new Guid("e354a5cd-5d4a-464e-a356-7cc434c5913d"), null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@example.com" });

            migrationBuilder.InsertData(
                table: "SalesOffices",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CreatedBy", "ManagedByEmployeeId", "ModifiedAt", "ModifiedBy", "SalesOfficeName", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"), null, null, new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"), null, null, "New Cairo Office", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"), null, null, new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"), null, null, "Downtown Office", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedAt", "CreatedBy", "DateOfBirth", "EmpFirstName", "EmpLastName", "ModifiedAt", "ModifiedBy", "SalesOfficeId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("0197f334-8f09-41f3-8ec8-f94a9d7d63e7"), 30, null, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", null, null, new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"), 40, null, null, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", null, null, new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "City", "CreatedAt", "CreatedBy", "ListPrice", "ModifiedAt", "ModifiedBy", "NoOfBathrooms", "NoOfBedrooms", "SalesOfficeId", "Status", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), "Anytown", null, null, 250000m, null, null, 2, 3, new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), "For Sale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("958de581-e471-4079-b232-3d6900acfd25"), "Anytown", null, null, 300000m, null, null, 3, 4, new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), "For Sale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PropertyOwners",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "OwnerId", "PercentOwned", "PropertyId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("4e0c5b04-b174-4230-b39c-5ee6aa966313"), null, null, null, null, new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), 100m, new Guid("958de581-e471-4079-b232-3d6900acfd25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9247b51c-c626-44bd-b7b8-414a321e1485"), null, null, null, null, new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), 100m, new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
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

            migrationBuilder.DeleteData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("4e0c5b04-b174-4230-b39c-5ee6aa966313"));

            migrationBuilder.DeleteData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("9247b51c-c626-44bd-b7b8-414a321e1485"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e354a5cd-5d4a-464e-a356-7cc434c5913d"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("958de581-e471-4079-b232-3d6900acfd25"));

            migrationBuilder.DeleteData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"));

            migrationBuilder.DeleteData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"));
        }
    }
}
