using Microsoft.EntityFrameworkCore.Migrations;

namespace TaviscaAssessment.Migrations
{
    public partial class updatedmodel3544562 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_PizzaType_PizzaTypeId",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_PizzaTypeId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "PizzaTypeId",
                table: "Pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaTypeId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PizzaTypeId",
                table: "Pizza",
                column: "PizzaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_PizzaType_PizzaTypeId",
                table: "Pizza",
                column: "PizzaTypeId",
                principalTable: "PizzaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
