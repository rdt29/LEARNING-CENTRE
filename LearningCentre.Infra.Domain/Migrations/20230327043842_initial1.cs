using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TechnologyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TechnologyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TechnologyId",
                table: "Users",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId");
        }
    }
}
