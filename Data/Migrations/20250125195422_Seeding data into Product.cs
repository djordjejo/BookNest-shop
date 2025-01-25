using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataintoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("23818011-d27b-47d5-8d39-0083eef89022"), "Abby Muscles", new Guid("f147a008-a693-4c37-b99c-379e3e89a38e"), "ll ", "WS3333333301", null, 65.0, "Cotton Candy" },
                    { new Guid("5089ecfb-17b8-4651-aca9-1036db06cee4"), "Laura Phantom", new Guid("8ec37b41-9c77-4311-8463-ac8d8820cb19"), "oo ", "FOT000000001", null, 23.0, "Leaves and Wonders" },
                    { new Guid("6d350160-fdfa-43cb-96c2-cd06f6c0bde6"), "Ron Parker", new Guid("f147a008-a693-4c37-b99c-379e3e89a38e"), "kkk", "SOTJ1111111101", null, 27.0, "Rock in the Ocean" },
                    { new Guid("6da3390d-045c-466f-a721-c208151a0457"), "Billy Spark", new Guid("8ec37b41-9c77-4311-8463-ac8d8820cb19"), "ss", "SWD9999001", null, 90.0, "Fortune of Time" },
                    { new Guid("766671fc-ef63-4100-abbf-0ce086a57b3b"), "Nancy Hoover", new Guid("bc0d1735-34ef-441d-84b3-a9f8fdfa58ab"), "sss", "CAW777777701", null, 30.0, "Dark Skies" },
                    { new Guid("c8bf5a09-45dc-45fb-8156-e6aaf7fd237e"), "Julian Button", new Guid("bc0d1735-34ef-441d-84b3-a9f8fdfa58ab"), "ss", "RITO5555501", null, 50.0, "Vanish in the Sunset" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
