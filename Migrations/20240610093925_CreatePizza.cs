using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Windy_City_Pizza.Migrations
{
    /// <inheritdoc />
    public partial class CreatePizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSmall = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceMeduim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceLarge = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
