using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Services.ProductApi.Migrations
{
    public partial class SeedingProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 2, "laptop", "new laptop", "1d54f5ds4fsd54f", "asus r565", 23.300000000000001 },
                    { 3, "laptop", "new gaming laptop", "1d5452hjjhs4fsd54f", "asus tuf", 451.30000000000001 },
                    { 4, "laptop", "work laptop", "1d54f5dpp12", "apple macbook m1", 0.0 },
                    { 5, "laptop", "work laptop", "1d54f5dpp12", "apple macbook m1", 0.0 },
                    { 6, "laptop", "student laptop", "1d522pp12", "lenovo ideapad 5 ", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);
        }
    }
}
