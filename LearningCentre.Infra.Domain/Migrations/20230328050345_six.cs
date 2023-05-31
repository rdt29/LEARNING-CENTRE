using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class six : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserId",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Users_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoleMappings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Technologies",
                newName: "userRoleMappingId");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_UserId",
                table: "Technologies",
                newName: "IX_Technologies_userRoleMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_UserRoleMappings_userRoleMappingId",
                table: "Technologies",
                column: "userRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Users_UserId",
                table: "UserRoleMappings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_userRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Users_UserId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserRoleMappings",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_UserId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_RoleId");

            migrationBuilder.RenameColumn(
                name: "userRoleMappingId",
                table: "Technologies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_userRoleMappingId",
                table: "Technologies",
                newName: "IX_Technologies_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserId",
                table: "Technologies",
                column: "UserId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Users_RoleId",
                table: "UserRoleMappings",
                column: "RoleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
