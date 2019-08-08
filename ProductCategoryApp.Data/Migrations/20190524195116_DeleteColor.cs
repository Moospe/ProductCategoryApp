using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCategoryApp.Data.Migrations
{
    public partial class DeleteColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorID",
                table: "Products",
                column: "ColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorID",
                table: "Products",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
