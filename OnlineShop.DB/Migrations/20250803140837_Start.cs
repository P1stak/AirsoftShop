using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.DB.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDeliveryInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeliveryInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserDeliveryInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDeliveryInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0198650b-ffda-704e-9e8b-3a5f4c1d2e7a"), 4000m, "Пистолет страйкбольный WELL Mauser C96 CO2", "/images/c96.jpg", "Mauser C96" },
                    { new Guid("0198650b-ffda-7172-aaf0-b596e6081587"), 10000m, "Страйкбольная штурмовая винтовка Cyma CM.518", "/images/cyma518.jpg", "CM.518" },
                    { new Guid("0198650b-ffda-72ec-9252-758d4d5f3615"), 9000m, "Автомат страйкбольный G36-C Specna Arms SA-G12 EBB Tan", "/images/G36-C.jpg", "G36-C" },
                    { new Guid("0198650b-ffda-75ca-988a-60f3a98a9718"), 5000m, "Пистолет-пулемет страйкбольный MP7 R4 WELL Plastic Body", "/images/mp7.jpg", "MP7" },
                    { new Guid("0198650b-ffda-7a5f-8d3e-4c2b1a9d8e6f"), 4500m, "Дробовик EE M56DL Black", "/images/M56DL.jpg", "M56DL" },
                    { new Guid("0198650b-ffda-7b6c-9e2d-3a4f5b6c7d8e"), 12000m, "Подствольный гранатомет Pyrosoft ГП-1 ЗНИЧ", "/images/GP1.jpg", "ГП-1" },
                    { new Guid("0198650b-ffda-7c7d-8e3f-4b5a6d7e8f9a"), 1200m, "Выносная тактическая кнопка Fenix AER-03 v2.0", "/images/aer.jpg", "Fenix AER-03" },
                    { new Guid("0198650b-ffda-7d8e-9f4a-5c6b7e8f9a1b"), 4500m, "Гильза Г52Д для гранатомёта страйкбольного Pyrosof", "/images/G52D.jpg", "Г52Д" },
                    { new Guid("0198650b-ffda-7e5d-904c-e60e6f1a815d"), 22000m, "Пулемет страйкбольный РПК-74М CYMA CM.052А", "/images/rpk-74m.jpg", "РПК-74М" },
                    { new Guid("0198650b-ffda-7f5d-a449-36a22b72b3e8"), 2500m, "Пистолет страйкбольный Colt 1911 STTI Green Gas", "/images/1911.jpg", "Colt 1911" },
                    { new Guid("7b8c9d0e-1f2a-3b4c-5d6e-7f8a9b0c1d2e"), 23500m, "Автомат страйкбольный E&L АКС-74 ELS-74 MN Gen2", "/images/ak74.jpg", "АКС-74" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CartId",
                table: "Items",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserDeliveryInfo");
        }
    }
}
