using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoleMappings",
                newName: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RolesId",
                table: "UserRoleMappings",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Roles_RolesId",
                table: "UserRoleMappings",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RolesId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_RolesId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "UserRoleMappings",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
