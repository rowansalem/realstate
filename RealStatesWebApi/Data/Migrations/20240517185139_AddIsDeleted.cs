using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SalesOffices",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PropertyOwners",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Properties",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Owners",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("417fa29a-5a30-487d-a994-dd3d3060f021"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4eccc760-57ce-483a-82cd-644caf6d28d9"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0197f334-8f09-41f3-8ec8-f94a9d7d63e7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("64d6ee5f-e553-43a8-8c47-d7a9f447c614"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("47a0f14a-b028-403f-8ba3-a1489d8e266e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("58fd99d4-3553-4fb4-b1ed-78d9c765a53a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("958de581-e471-4079-b232-3d6900acfd25"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("4e0c5b04-b174-4230-b39c-5ee6aa966313"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PropertyOwners",
                keyColumn: "Id",
                keyValue: new Guid("9247b51c-c626-44bd-b7b8-414a321e1485"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("028aa2c5-d4a3-4369-ab0b-86b3d74ffb23"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SalesOffices",
                keyColumn: "Id",
                keyValue: new Guid("8e56f097-eec5-4b0e-bed5-aa8766212b67"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e354a5cd-5d4a-464e-a356-7cc434c5913d"),
                column: "IsDeleted",
                value: false);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SalesOffices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PropertyOwners");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

       
        }
    }
}
