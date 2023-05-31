using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Roles_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Technologies_TechnologyId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_TechnologyId",
                table: "UserRoleMappings");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleMappingId",
                table: "Technologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleMappingId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_UserRoleMappingId",
                table: "Technologies",
                column: "UserRoleMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserRoleMappingId",
                table: "Roles",
                column: "UserRoleMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles",
                column: "UserRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserRoleMappingId",
                table: "Technologies",
                column: "UserRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "UserRoleMappingId",
                table: "Roles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_TechnologyId",
                table: "UserRoleMappings",
                column: "TechnologyId");

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
    }
}
