using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class eight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserRoleMappingId",
                table: "Roles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleMappingId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserRoleMappingId",
                table: "Roles",
                column: "UserRoleMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles",
                column: "UserRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
