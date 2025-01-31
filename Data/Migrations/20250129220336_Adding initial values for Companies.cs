using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddinginitialvaluesforCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "StreetAdress" },
                values: new object[,]
                {
                    { new Guid("5e6a7c89-4b21-4f9e-9215-f7d3e8a9c3c8"), "San Francisco", "InnoSoft", 987654321, 94101, "456 Innovation Ave" },
                    { new Guid("9d8b7c6a-1e34-4c57-8b2a-f2a1d4e6b5f3"), "Chicago", "DataWorks", 555666777, 60601, "789 Data Blvd" },
                    { new Guid("b3a1f5d2-3d5e-4d76-a2a8-bb8e4ef4e0f4"), "New York", "Tech Corp", 123456789, 10001, "123 Tech Street" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
