using Microsoft.EntityFrameworkCore.Migrations;

namespace TaviscaAssessment.Migrations
{
    public partial class updatedmodel35445 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizaaIngredientId",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "PizzaIngredient",
                newName: "PizzaTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "PizzaTypeId",
                table: "PizzaIngredient",
                newName: "PizzaId");

            migrationBuilder.AddColumn<int>(
                name: "PizaaIngredientId",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
