using Microsoft.EntityFrameworkCore.Migrations;

namespace TaviscaAssessment.Migrations
{
    public partial class updatedmodel35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Ingredients_IngredientsId",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_IngredientsId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_IngredientsId",
                table: "Pizza",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Ingredients_IngredientsId",
                table: "Pizza",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
