using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class submittedreftaskEvalutionv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations",
                column: "SubmittedTaskId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEvaluations_SubmittedTaskId",
                table: "TaskEvaluations",
                column: "SubmittedTaskId");
        }
    }
}
