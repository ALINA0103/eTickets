using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class hjhjhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CartId",
                table: "Movies",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cart_CartId",
                table: "Movies",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cart_CartId",
                table: "Users",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cart_CartId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cart_CartId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CartId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CartId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Movies");
        }
    }
}
