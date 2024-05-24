using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "OwnerFirstName", "OwnerLastName", "Timestamp" },
                values: new object[] { new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"), null, null, false, null, null, "Jane", "Smith", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"));
        }
    }
}
