using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class hfhfhg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "movie_fk_id",
                table: "Cart",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "movie_fk_id");
        }
    }
}
