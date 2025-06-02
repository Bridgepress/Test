using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class __CheckModelDiff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("543c1678-8843-4b64-b6b4-43f9935bb931"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("b07af5f6-4e23-4097-a7ed-b00639ed1b2b"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("cc6ee3e7-7725-468a-abd0-73003c1dcc49"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d1a8eeeb-7b7d-4c6e-8112-d6e0469e27db"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("e87d9384-aee1-4dbe-a215-73301d995e0b"));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "OrderCode", "TotalMoney" },
                values: new object[,]
                {
                    { new Guid("2cd4163b-1285-4480-a390-8c72edb83a1a"), new Guid("53cca54c-213e-4e87-8a1f-7b8cc0922cf4"), "ORD004", 150m },
                    { new Guid("7c3265ad-91c7-40d6-b429-7817e1e4b3ba"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD002", 200m },
                    { new Guid("bc65a948-529f-4d62-b53d-0b12ffb01cc8"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD001", 100m },
                    { new Guid("f49e060b-ef72-4f8f-abdb-dcdba3269f96"), new Guid("53cca54c-213e-4e87-8a1f-7b8cc0922cf4"), "ORD005", 250m },
                    { new Guid("f9016454-09ca-4dbd-9f67-e963dee647e2"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD003", 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("2cd4163b-1285-4480-a390-8c72edb83a1a"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("7c3265ad-91c7-40d6-b429-7817e1e4b3ba"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("bc65a948-529f-4d62-b53d-0b12ffb01cc8"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("f49e060b-ef72-4f8f-abdb-dcdba3269f96"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("f9016454-09ca-4dbd-9f67-e963dee647e2"));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "OrderCode", "TotalMoney" },
                values: new object[,]
                {
                    { new Guid("543c1678-8843-4b64-b6b4-43f9935bb931"), new Guid("53cca54c-213e-4e87-8a1f-7b8cc0922cf4"), "ORD005", 250m },
                    { new Guid("b07af5f6-4e23-4097-a7ed-b00639ed1b2b"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD002", 200m },
                    { new Guid("cc6ee3e7-7725-468a-abd0-73003c1dcc49"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD001", 100m },
                    { new Guid("d1a8eeeb-7b7d-4c6e-8112-d6e0469e27db"), new Guid("9929115f-e463-4645-9325-1bebdbda948b"), "ORD003", 300m },
                    { new Guid("e87d9384-aee1-4dbe-a215-73301d995e0b"), new Guid("53cca54c-213e-4e87-8a1f-7b8cc0922cf4"), "ORD004", 150m }
                });
        }
    }
}
