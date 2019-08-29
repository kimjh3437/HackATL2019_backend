using Microsoft.EntityFrameworkCore.Migrations;

namespace HackATL_EEVM_backend.Migrations
{
    public partial class UserlistDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserList",
                table: "UserList",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "Token", "Username" },
                values: new object[] { 1, "Gabriel", "Kim", null, null, null, null, "kimjh3437" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserList",
                table: "UserList");

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "UserList",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
