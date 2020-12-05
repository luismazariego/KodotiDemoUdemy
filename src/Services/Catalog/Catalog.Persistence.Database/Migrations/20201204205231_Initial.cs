using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stock_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "Product 1", 114m },
                    { 73, "Description for Product 73", "Product 73", 918m },
                    { 72, "Description for Product 72", "Product 72", 663m },
                    { 71, "Description for Product 71", "Product 71", 205m },
                    { 70, "Description for Product 70", "Product 70", 486m },
                    { 69, "Description for Product 69", "Product 69", 839m },
                    { 68, "Description for Product 68", "Product 68", 828m },
                    { 67, "Description for Product 67", "Product 67", 776m },
                    { 66, "Description for Product 66", "Product 66", 188m },
                    { 65, "Description for Product 65", "Product 65", 248m },
                    { 64, "Description for Product 64", "Product 64", 259m },
                    { 63, "Description for Product 63", "Product 63", 101m },
                    { 62, "Description for Product 62", "Product 62", 210m },
                    { 61, "Description for Product 61", "Product 61", 584m },
                    { 60, "Description for Product 60", "Product 60", 470m },
                    { 59, "Description for Product 59", "Product 59", 832m },
                    { 58, "Description for Product 58", "Product 58", 787m },
                    { 57, "Description for Product 57", "Product 57", 418m },
                    { 56, "Description for Product 56", "Product 56", 539m },
                    { 55, "Description for Product 55", "Product 55", 847m },
                    { 54, "Description for Product 54", "Product 54", 549m },
                    { 53, "Description for Product 53", "Product 53", 799m },
                    { 74, "Description for Product 74", "Product 74", 683m },
                    { 52, "Description for Product 52", "Product 52", 195m },
                    { 75, "Description for Product 75", "Product 75", 364m },
                    { 77, "Description for Product 77", "Product 77", 117m },
                    { 98, "Description for Product 98", "Product 98", 297m },
                    { 97, "Description for Product 97", "Product 97", 407m },
                    { 96, "Description for Product 96", "Product 96", 229m },
                    { 95, "Description for Product 95", "Product 95", 514m },
                    { 94, "Description for Product 94", "Product 94", 815m },
                    { 93, "Description for Product 93", "Product 93", 967m },
                    { 92, "Description for Product 92", "Product 92", 75m },
                    { 91, "Description for Product 91", "Product 91", 319m },
                    { 90, "Description for Product 90", "Product 90", 990m },
                    { 89, "Description for Product 89", "Product 89", 860m },
                    { 88, "Description for Product 88", "Product 88", 409m },
                    { 87, "Description for Product 87", "Product 87", 526m },
                    { 86, "Description for Product 86", "Product 86", 423m },
                    { 85, "Description for Product 85", "Product 85", 71m },
                    { 84, "Description for Product 84", "Product 84", 703m },
                    { 83, "Description for Product 83", "Product 83", 939m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for Product 82", "Product 82", 830m },
                    { 81, "Description for Product 81", "Product 81", 129m },
                    { 80, "Description for Product 80", "Product 80", 78m },
                    { 79, "Description for Product 79", "Product 79", 283m },
                    { 78, "Description for Product 78", "Product 78", 217m },
                    { 76, "Description for Product 76", "Product 76", 554m },
                    { 51, "Description for Product 51", "Product 51", 375m },
                    { 50, "Description for Product 50", "Product 50", 112m },
                    { 49, "Description for Product 49", "Product 49", 887m },
                    { 22, "Description for Product 22", "Product 22", 575m },
                    { 21, "Description for Product 21", "Product 21", 962m },
                    { 20, "Description for Product 20", "Product 20", 705m },
                    { 19, "Description for Product 19", "Product 19", 732m },
                    { 18, "Description for Product 18", "Product 18", 204m },
                    { 17, "Description for Product 17", "Product 17", 463m },
                    { 16, "Description for Product 16", "Product 16", 969m },
                    { 15, "Description for Product 15", "Product 15", 175m },
                    { 14, "Description for Product 14", "Product 14", 369m },
                    { 13, "Description for Product 13", "Product 13", 536m },
                    { 12, "Description for Product 12", "Product 12", 685m },
                    { 11, "Description for Product 11", "Product 11", 464m },
                    { 10, "Description for Product 10", "Product 10", 766m },
                    { 9, "Description for Product 9", "Product 9", 606m },
                    { 8, "Description for Product 8", "Product 8", 817m },
                    { 7, "Description for Product 7", "Product 7", 987m },
                    { 6, "Description for Product 6", "Product 6", 607m },
                    { 5, "Description for Product 5", "Product 5", 55m },
                    { 4, "Description for Product 4", "Product 4", 62m },
                    { 3, "Description for Product 3", "Product 3", 483m },
                    { 2, "Description for Product 2", "Product 2", 681m },
                    { 23, "Description for Product 23", "Product 23", 312m },
                    { 24, "Description for Product 24", "Product 24", 696m },
                    { 25, "Description for Product 25", "Product 25", 229m },
                    { 26, "Description for Product 26", "Product 26", 584m },
                    { 48, "Description for Product 48", "Product 48", 242m },
                    { 47, "Description for Product 47", "Product 47", 505m },
                    { 46, "Description for Product 46", "Product 46", 201m },
                    { 45, "Description for Product 45", "Product 45", 462m },
                    { 44, "Description for Product 44", "Product 44", 145m },
                    { 43, "Description for Product 43", "Product 43", 507m },
                    { 42, "Description for Product 42", "Product 42", 458m },
                    { 41, "Description for Product 41", "Product 41", 390m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for Product 40", "Product 40", 99m },
                    { 39, "Description for Product 39", "Product 39", 286m },
                    { 99, "Description for Product 99", "Product 99", 896m },
                    { 38, "Description for Product 38", "Product 38", 800m },
                    { 36, "Description for Product 36", "Product 36", 688m },
                    { 35, "Description for Product 35", "Product 35", 530m },
                    { 34, "Description for Product 34", "Product 34", 707m },
                    { 33, "Description for Product 33", "Product 33", 908m },
                    { 32, "Description for Product 32", "Product 32", 326m },
                    { 31, "Description for Product 31", "Product 31", 568m },
                    { 30, "Description for Product 30", "Product 30", 396m },
                    { 29, "Description for Product 29", "Product 29", 766m },
                    { 28, "Description for Product 28", "Product 28", 826m },
                    { 27, "Description for Product 27", "Product 27", 73m },
                    { 37, "Description for Product 37", "Product 37", 813m },
                    { 100, "Description for Product 100", "Product 100", 324m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 45 },
                    { 73, 73, 0 },
                    { 72, 72, 72 },
                    { 71, 71, 28 },
                    { 70, 70, 29 },
                    { 69, 69, 33 },
                    { 68, 68, 44 },
                    { 67, 67, 39 },
                    { 66, 66, 82 },
                    { 65, 65, 45 },
                    { 64, 64, 38 },
                    { 63, 63, 80 },
                    { 62, 62, 15 },
                    { 61, 61, 69 },
                    { 60, 60, 2 },
                    { 59, 59, 97 },
                    { 58, 58, 13 },
                    { 57, 57, 96 },
                    { 56, 56, 10 },
                    { 55, 55, 81 },
                    { 54, 54, 93 },
                    { 53, 53, 91 },
                    { 74, 74, 43 },
                    { 52, 52, 72 },
                    { 75, 75, 50 },
                    { 77, 77, 62 },
                    { 98, 98, 34 },
                    { 97, 97, 15 },
                    { 96, 96, 29 },
                    { 95, 95, 97 },
                    { 94, 94, 44 },
                    { 93, 93, 33 },
                    { 92, 92, 51 },
                    { 91, 91, 7 },
                    { 90, 90, 82 },
                    { 89, 89, 6 },
                    { 88, 88, 82 },
                    { 87, 87, 15 },
                    { 86, 86, 61 },
                    { 85, 85, 4 },
                    { 84, 84, 10 },
                    { 83, 83, 66 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 37 },
                    { 81, 81, 55 },
                    { 80, 80, 51 },
                    { 79, 79, 36 },
                    { 78, 78, 26 },
                    { 76, 76, 30 },
                    { 51, 51, 67 },
                    { 50, 50, 35 },
                    { 49, 49, 3 },
                    { 22, 22, 34 },
                    { 21, 21, 25 },
                    { 20, 20, 95 },
                    { 19, 19, 10 },
                    { 18, 18, 46 },
                    { 17, 17, 4 },
                    { 16, 16, 92 },
                    { 15, 15, 33 },
                    { 14, 14, 26 },
                    { 13, 13, 33 },
                    { 12, 12, 14 },
                    { 11, 11, 89 },
                    { 10, 10, 78 },
                    { 9, 9, 11 },
                    { 8, 8, 26 },
                    { 7, 7, 85 },
                    { 6, 6, 38 },
                    { 5, 5, 88 },
                    { 4, 4, 74 },
                    { 3, 3, 65 },
                    { 2, 2, 34 },
                    { 23, 23, 37 },
                    { 24, 24, 51 },
                    { 25, 25, 76 },
                    { 26, 26, 86 },
                    { 48, 48, 32 },
                    { 47, 47, 31 },
                    { 46, 46, 25 },
                    { 45, 45, 15 },
                    { 44, 44, 11 },
                    { 43, 43, 72 },
                    { 42, 42, 95 },
                    { 41, 41, 44 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stock",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 66 },
                    { 39, 39, 46 },
                    { 99, 99, 65 },
                    { 38, 38, 31 },
                    { 36, 36, 4 },
                    { 35, 35, 93 },
                    { 34, 34, 88 },
                    { 33, 33, 75 },
                    { 32, 32, 6 },
                    { 31, 31, 33 },
                    { 30, 30, 72 },
                    { 29, 29, 45 },
                    { 28, 28, 69 },
                    { 27, 27, 69 },
                    { 37, 37, 64 },
                    { 100, 100, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                schema: "Catalog",
                table: "Stock",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
