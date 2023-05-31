using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Users_UserId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_UserId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "UserRoleMappings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoleMappings");

            migrationBuilder.DropColumn(
                name: "UserRoleMappingId",
                table: "Technologies");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Technologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleMappingId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_UserId",
                table: "Technologies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles",
                column: "UserRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UserRoleMappings_UserRoleMappingId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_UserId",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Users_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_UserId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technologies");

            migrationBuilder.AddColumn<int>(
                name: "TechnologyId",
                table: "UserRoleMappings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRoleMappings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleMappingId",
                table: "Technologies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleMappingId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_UserId",
                table: "UserRoleMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_UserRoleMappingId",
                table: "Technologies",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Users_UserId",
                table: "UserRoleMappings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
