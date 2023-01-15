using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrojaRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class addMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Menus_MenuId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MenuId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Menus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuId",
                table: "Meals",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MenuId",
                table: "Categories",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Menus_MenuId",
                table: "Categories",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
