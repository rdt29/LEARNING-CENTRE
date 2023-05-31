using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TasksId",
                table: "AssignTasks");

            migrationBuilder.DropIndex(
                name: "IX_AssignTasks_TasksId",
                table: "AssignTasks");

            migrationBuilder.DropColumn(
                name: "TasksId",
                table: "AssignTasks");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_TaskId",
                table: "AssignTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TaskId",
                table: "AssignTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TaskId",
                table: "AssignTasks");

            migrationBuilder.DropIndex(
                name: "IX_AssignTasks_TaskId",
                table: "AssignTasks");

            migrationBuilder.AddColumn<int>(
                name: "TasksId",
                table: "AssignTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_TasksId",
                table: "AssignTasks",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TasksId",
                table: "AssignTasks",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
