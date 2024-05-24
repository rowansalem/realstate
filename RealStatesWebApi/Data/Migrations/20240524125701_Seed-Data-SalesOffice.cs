using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataSalesOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "SalesOffices",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "SalesOffices",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CreatedBy", "IsDeleted", "ManagerId", "ModifiedAt", "ModifiedBy", "SalesOfficeName", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"), new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"), null, null, false, null, null, null, "New Cairo Office", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"), new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"), null, null, false, null, null, null, "Downtown Office", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"));

            migrationBuilder.DeleteData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "SalesOffices",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
