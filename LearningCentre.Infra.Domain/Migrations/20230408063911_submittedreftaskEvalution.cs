using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class submittedreftaskEvalution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEvaluations_AssignTasks_AssignTaskId",
                table: "TaskEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_TaskEvaluations_AssignTaskId",
                table: "TaskEvaluations");

            migrationBuilder.RenameColumn(
                name: "AssignTaskId",
                table: "TaskEvaluations",
                newName: "SubmittedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations",
                column: "SubmittedTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEvaluations_SubmittedTasks_SubmittedTaskId",
                table: "TaskEvaluations",
                column: "SubmittedTaskId",
                principalTable: "SubmittedTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEvaluations_SubmittedTasks_SubmittedTaskId",
                table: "TaskEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations");

            migrationBuilder.RenameColumn(
                name: "SubmittedTaskId",
                table: "TaskEvaluations",
                newName: "AssignTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEvaluations_AssignTaskId",
                table: "TaskEvaluations",
                column: "AssignTaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEvaluations_AssignTasks_AssignTaskId",
                table: "TaskEvaluations",
                column: "AssignTaskId",
                principalTable: "AssignTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
