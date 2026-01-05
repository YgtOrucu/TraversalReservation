using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Mail = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Subject = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    MessageBody = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    MessageDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");
        }
    }
}
