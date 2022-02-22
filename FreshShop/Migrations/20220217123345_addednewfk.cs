using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshShop.Migrations
{
    public partial class addednewfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Products_ProductsId",
                table: "ProductGallery");

            migrationBuilder.DropIndex(
                name: "IX_ProductGallery_ProductsId",
                table: "ProductGallery");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ProductGallery");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGallery",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery");

            migrationBuilder.DropIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGallery");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ProductGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductsId",
                table: "ProductGallery",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Products_ProductsId",
                table: "ProductGallery",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
