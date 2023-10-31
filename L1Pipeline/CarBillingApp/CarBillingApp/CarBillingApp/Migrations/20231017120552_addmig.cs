using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBillingApp.Migrations
{
    /// <inheritdoc />
    public partial class addmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BillingEntity",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(255)", nullable: false),
                    VIN = table.Column<string>(type: "longtext", nullable: false),
                    PurchasedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerInformations = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingEntity", x => x.CustomerId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingEntity");
        }
    }
}
