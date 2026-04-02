using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryStore.Migrations
{
    /// <inheritdoc />
    public partial class Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TheProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheProducts_ProductId",
                table: "TheProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheProducts_Products_ProductId",
                table: "TheProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheProducts_Products_ProductId",
                table: "TheProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_TheProducts_ProductId",
                table: "TheProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TheProducts");
        }
    }
}
