using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixPropertyOwnerRelationForignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "SalesOffices",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"),
                column: "EmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"),
                column: "EmployeeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOffices_EmployeeId",
                table: "SalesOffices",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOffices_Employees_EmployeeId",
                table: "SalesOffices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOffices_Employees_EmployeeId",
                table: "SalesOffices");

            migrationBuilder.DropIndex(
                name: "IX_SalesOffices_EmployeeId",
                table: "SalesOffices");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SalesOffices");
        }
    }
}
