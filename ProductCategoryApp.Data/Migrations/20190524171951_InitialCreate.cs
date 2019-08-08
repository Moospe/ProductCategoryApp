using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCategoryApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CurrentValue = table.Column<decimal>(nullable: false),
                    PurchaseValue = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Length_X = table.Column<decimal>(nullable: false),
                    Length_Y = table.Column<decimal>(nullable: false),
                    Length_Z = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
