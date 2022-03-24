using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshShop.Migrations
{
    public partial class ProductColumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Products",
                newName: "CoverPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverPhoto",
                table: "Products",
                newName: "CoverImage");
        }
    }
}
