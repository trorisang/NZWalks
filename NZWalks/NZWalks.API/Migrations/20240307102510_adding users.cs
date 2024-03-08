using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    public partial class addingusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Roles_RoleId",
                table: "Users_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Users_UserId",
                table: "Users_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Roles",
                table: "Users_Roles");

            migrationBuilder.RenameTable(
                name: "Users_Roles",
                newName: "Users_Role");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Roles_UserId",
                table: "Users_Role",
                newName: "IX_Users_Role_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Roles_RoleId",
                table: "Users_Role",
                newName: "IX_Users_Role_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Role",
                table: "Users_Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Roles_RoleId",
                table: "Users_Role",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Users_UserId",
                table: "Users_Role",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Roles_RoleId",
                table: "Users_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Users_UserId",
                table: "Users_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Role",
                table: "Users_Role");

            migrationBuilder.RenameTable(
                name: "Users_Role",
                newName: "Users_Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Role_UserId",
                table: "Users_Roles",
                newName: "IX_Users_Roles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Role_RoleId",
                table: "Users_Roles",
                newName: "IX_Users_Roles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Roles",
                table: "Users_Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Roles_RoleId",
                table: "Users_Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Users_UserId",
                table: "Users_Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
