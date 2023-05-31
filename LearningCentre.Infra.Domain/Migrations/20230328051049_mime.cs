using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class mime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_UserRoleMappings_userRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_userRoleMappingId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "userRoleMappingId",
                table: "Technologies");

            migrationBuilder.AddColumn<int>(
                name: "technologiesId",
                table: "UserRoleMappings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_technologiesId",
                table: "UserRoleMappings",
                column: "technologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMappings_Technologies_technologiesId",
                table: "UserRoleMappings",
                column: "technologiesId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMappings_Technologies_technologiesId",
                table: "UserRoleMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleMappings_technologiesId",
                table: "UserRoleMappings");

            migrationBuilder.DropColumn(
                name: "technologiesId",
                table: "UserRoleMappings");

            migrationBuilder.AddColumn<int>(
                name: "userRoleMappingId",
                table: "Technologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_userRoleMappingId",
                table: "Technologies",
                column: "userRoleMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_UserRoleMappings_userRoleMappingId",
                table: "Technologies",
                column: "userRoleMappingId",
                principalTable: "UserRoleMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
