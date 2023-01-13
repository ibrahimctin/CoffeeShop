using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Infrastructure.Migrations
{
    public partial class new_props_for_coffeeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CoffeeProducts",
                newName: "CoffeeName");

            migrationBuilder.AddColumn<string>(
                name: "CoffeeCategoryId",
                table: "CoffeeProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProducts_CoffeeCategoryId",
                table: "CoffeeProducts",
                column: "CoffeeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_CoffeeCategories_CoffeeCategoryId",
                table: "CoffeeProducts",
                column: "CoffeeCategoryId",
                principalTable: "CoffeeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_CoffeeCategories_CoffeeCategoryId",
                table: "CoffeeProducts");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeProducts_CoffeeCategoryId",
                table: "CoffeeProducts");

            migrationBuilder.DropColumn(
                name: "CoffeeCategoryId",
                table: "CoffeeProducts");

            migrationBuilder.RenameColumn(
                name: "CoffeeName",
                table: "CoffeeProducts",
                newName: "Name");
        }
    }
}
