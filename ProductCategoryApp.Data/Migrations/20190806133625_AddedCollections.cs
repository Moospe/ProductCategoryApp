using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCategoryApp.Data.Migrations
{
    public partial class AddedCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CollectionID",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CollectionID",
                table: "Categories",
                column: "CollectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Collections_CollectionID",
                table: "Categories",
                column: "CollectionID",
                principalTable: "Collections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Collections_CollectionID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CollectionID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CollectionID",
                table: "Categories");
        }
    }
}
