using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class ge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartModels",
                table: "ShoppingCartModels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShoppingCartModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingCartModels");

            migrationBuilder.RenameTable(
                name: "ShoppingCartModels",
                newName: "ShoppingCartModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartModel",
                table: "ShoppingCartModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartModel",
                table: "ShoppingCartModel");

            migrationBuilder.RenameTable(
                name: "ShoppingCartModel",
                newName: "ShoppingCartModels");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShoppingCartModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingCartModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartModels",
                table: "ShoppingCartModels",
                column: "Id");
        }
    }
}
