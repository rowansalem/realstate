using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataPropertyOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PropertyOwners",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "OwnerId", "PercentOwned", "PropertyId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("4e0c5b04-b174-4230-b39c-5ee6aa966313"), null, null, false, null, null, new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), 100m, new Guid("958de581-e471-4079-b232-3d6900acfd25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9247b51c-c626-44bd-b7b8-414a321e1485"), null, null, false, null, null, new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), 100m, new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("4e0c5b04-b174-4230-b39c-5ee6aa966313"));

            migrationBuilder.DeleteData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("9247b51c-c626-44bd-b7b8-414a321e1485"));
        }
    }
}
