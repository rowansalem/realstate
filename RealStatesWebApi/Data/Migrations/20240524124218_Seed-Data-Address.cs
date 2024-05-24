using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "City", "CreatedAt", "CreatedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "State", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"), "123 Main St", "Texas City", null, null, false, null, null, "Texas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" },
                    { new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"), "123 Victore St", "Alexandria", null, null, false, null, null, "Alex", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
