using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "Id",
                values: new object[]
                {
                    new Guid("53cca54c-213e-4e87-8a1f-7b8cc0922cf4"),
                    new Guid("9929115f-e463-4645-9325-1bebdbda948b")
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");


            const string viewOrdersSql = """
                    CREATE VIEW V_Orders AS
                    SELECT 
                        Id,
                        CustomerID,
                        TotalMoney,
                        OrderCode
                    FROM [Order]
                    """;

            migrationBuilder.Sql(viewOrdersSql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.Sql("DROP VIEW IF EXISTS V_Orders");
        }
    }
}
