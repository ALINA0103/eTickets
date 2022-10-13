using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class jhjhjhuyh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Cart",
                newName: "User_fk");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "Cart",
                newName: "Movie_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_fk",
                table: "Cart",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "Movie_fk",
                table: "Cart",
                newName: "MoviesId");
        }
    }
}
