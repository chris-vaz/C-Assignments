using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefsnDishes.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_CookChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CookChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CookChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "CookChefId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CookChefId",
                table: "Dishes",
                column: "CookChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_CookChefId",
                table: "Dishes",
                column: "CookChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId");
        }
    }
}
