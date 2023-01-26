using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhoneNumberCountryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("09532446-967b-45e4-be15-013a4f03437e"),
                column: "PhoneNumberCountryCode",
                value: "IR");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("85259efb-0ca9-41d8-8159-e85c8535184f"),
                column: "PhoneNumberCountryCode",
                value: "IR");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8bd6dfea-6784-4b02-97c7-6d69b47e332a"),
                column: "PhoneNumberCountryCode",
                value: "IR");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e40156ae-992e-4fc1-a071-0bfacf8f427d"),
                column: "PhoneNumberCountryCode",
                value: "IR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("09532446-967b-45e4-be15-013a4f03437e"),
                column: "PhoneNumberCountryCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("85259efb-0ca9-41d8-8159-e85c8535184f"),
                column: "PhoneNumberCountryCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8bd6dfea-6784-4b02-97c7-6d69b47e332a"),
                column: "PhoneNumberCountryCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e40156ae-992e-4fc1-a071-0bfacf8f427d"),
                column: "PhoneNumberCountryCode",
                value: null);
        }
    }
}
