using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedMango.API.Migrations
{
    /// <inheritdoc />
    public partial class addMenuItemTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll", 7.9900000000000002, "" },
                    { 2, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 2", 7.9900000000000002, "" },
                    { 3, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 3", 7.9900000000000002, "" },
                    { 4, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 4", 7.9900000000000002, "" },
                    { 5, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 5", 7.9900000000000002, "" },
                    { 6, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 6", 7.9900000000000002, "" },
                    { 7, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 7", 7.9900000000000002, "" },
                    { 8, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 8", 7.9900000000000002, "" },
                    { 9, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 9", 7.9900000000000002, "" },
                    { 10, "Appetizer", "Spring Roll Description", "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg", "Spring Roll 10", 7.9900000000000002, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<double>(
                name: "Image",
                table: "MenuItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
