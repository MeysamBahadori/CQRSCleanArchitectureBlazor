using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: true),
                    Lastname = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PhoneNumberCountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(320)", maxLength: 320, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "VARCHAR(34)", maxLength: 34, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BankAccountNumber", "DateOfBirth", "Email", "Firstname", "Lastname", "PhoneNumber", "PhoneNumberCountryCode" },
                values: new object[,]
                {
                    { new Guid("09532446-967b-45e4-be15-013a4f03437e"), "1234123412341234", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bahadori.meysam@outlook.com", "Meysam", "Bahadori", "09397524270", null },
                    { new Guid("85259efb-0ca9-41d8-8159-e85c8535184f"), "3124312431243124", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "abdi.faranak@yahoo.com", "Faranak", "Abdi", "09111111112", null },
                    { new Guid("8bd6dfea-6784-4b02-97c7-6d69b47e332a"), "4123412341234123", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "shirazi.donya@gmail.com", "Donya", "shirazi", "09111111113", null },
                    { new Guid("e40156ae-992e-4fc1-a071-0bfacf8f427d"), "213421342134", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "iman.nasr@gmail.com", "Iman", "Nasr", "09111111111", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Firstname_Lastname_DateOfBirth",
                table: "Customers",
                columns: new[] { "Firstname", "Lastname", "DateOfBirth" },
                unique: true,
                filter: "[Firstname] IS NOT NULL AND [Lastname] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
