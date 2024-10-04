using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StructurMessegerFullUserActyvyti.Migrations;

/// <inheritdoc />
public partial class AddUserFriendsTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "UserFriendsTable",
            columns: table => new
            {
                Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserFriendsTable", x => x.Email);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "UserFriendsTable");
    }
}
