using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class dfff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin");

            migrationBuilder.RenameTable(
                name: "UserLogin",
                newName: "UserLogins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "UserId");
        }
    }
}
