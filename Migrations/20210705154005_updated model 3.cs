using Microsoft.EntityFrameworkCore.Migrations;

namespace TaviscaAssessment.Migrations
{
    public partial class updatedmodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    PizaaTypeId = table.Column<int>(type: "int", nullable: false),
                    PizzaTypeId = table.Column<int>(type: "int", nullable: true),
                    PizaaIngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_PizzaType_PizzaTypeId",
                        column: x => x.PizzaTypeId,
                        principalTable: "PizzaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "", "Dough/Flour", 10 },
                    { 2, "", "Pizza Dough Mix", 20 },
                    { 3, "", "Deep Dish Pizza Dough Mix", 30 },
                    { 4, "", "Ultra Thin/Low Carb Pizza Dough", 40 },
                    { 5, "", "Gluten Free Pizza Crust", 50 },
                    { 6, "", "Pizza Sauce", 80 },
                    { 7, "", "Pizza Sauce Seasoning", 80 }
                });

            migrationBuilder.InsertData(
                table: "PizzaType",
                columns: new[] { "Id", "PizzaImage", "TypeName" },
                values: new object[,]
                {
                    { 1, "", "Margherita" },
                    { 2, "", "Peppy Paneer" },
                    { 3, "", "Mexican Green Wave" },
                    { 4, "", "CHEESE N CORN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PizzaId",
                table: "Order",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_IngredientsId",
                table: "Pizza",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PizzaTypeId",
                table: "Pizza",
                column: "PizzaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientsId",
                table: "PizzaIngredient",
                column: "IngredientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PizzaIngredient");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "PizzaType");
        }
    }
}
