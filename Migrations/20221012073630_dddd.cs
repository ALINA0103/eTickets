using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class dddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Cart",
                newName: "Id");
        }
    }
}
