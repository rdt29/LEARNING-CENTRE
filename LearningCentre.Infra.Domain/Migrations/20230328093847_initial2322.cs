using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial2322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RolesId",
                table: "UserRoleMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Technologies_technologiesId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "technologiesId",
                table: "UserRoleMappings",
                newName: "TechnologyId");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "UserRoleMappings",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_technologiesId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_TechnologyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_RolesId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Technologies_TechnologyId",
                table: "UserRoleMappings",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Technologies_TechnologyId",
                table: "UserRoleMappings");

            migrationBuilder.RenameColumn(
                name: "TechnologyId",
                table: "UserRoleMappings",
                newName: "technologiesId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoleMappings",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_TechnologyId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_technologiesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                newName: "IX_UserRoleMappings_RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Roles_RolesId",
                table: "UserRoleMappings",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Technologies_technologiesId",
                table: "UserRoleMappings",
                column: "technologiesId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
