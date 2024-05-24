using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "City", "CreatedAt", "CreatedBy", "IsDeleted", "ListPrice", "ModifiedAt", "ModifiedBy", "NoOfBathrooms", "NoOfBedrooms", "SalesOfficeId", "Status", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), "Anytown", null, null, false, 250000m, null, null, 2, 3, new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), "For Sale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("958de581-e471-4079-b232-3d6900acfd25"), "Anytown", null, null, false, 300000m, null, null, 3, 4, new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), "For Sale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("958de581-e471-4079-b232-3d6900acfd25"));
        }
    }
}
