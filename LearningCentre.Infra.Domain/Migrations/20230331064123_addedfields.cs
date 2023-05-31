using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubmittedTasks_AssignTaskId",
                table: "SubmittedTasks");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTasks_AssignTaskId",
                table: "SubmittedTasks",
                column: "AssignTaskId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubmittedTasks_AssignTaskId",
                table: "SubmittedTasks");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTasks_AssignTaskId",
                table: "SubmittedTasks",
                column: "AssignTaskId");
        }
    }
}
