using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCentre.Infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initialv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TasksTaskId",
                table: "AssignTasks");

            migrationBuilder.DropTable(
                name: "UserTaskSubmits");

            migrationBuilder.RenameColumn(
                name: "TechnologyId",
                table: "Technologies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TasksTaskId",
                table: "AssignTasks",
                newName: "TasksId");

            migrationBuilder.RenameColumn(
                name: "AssignTaskId",
                table: "AssignTasks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AssignTasks_TasksTaskId",
                table: "AssignTasks",
                newName: "IX_AssignTasks_TasksId");

            migrationBuilder.CreateTable(
                name: "SubmittedTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AssignTaskId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Submission = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedTasks_AssignTasks_AssignTaskId",
                        column: x => x.AssignTaskId,
                        principalTable: "AssignTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTasks_AssignTaskId",
                table: "SubmittedTasks",
                column: "AssignTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TasksId",
                table: "AssignTasks",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasks_TasksId",
                table: "AssignTasks");

            migrationBuilder.DropTable(
                name: "SubmittedTasks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Technologies",
                newName: "TechnologyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "AssignTasks",
                newName: "TasksTaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssignTasks",
                newName: "AssignTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignTasks_TasksId",
                table: "AssignTasks",
                newName: "IX_AssignTasks_TasksTaskId");

            migrationBuilder.CreateTable(
                name: "UserTaskSubmits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignTaskId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Submission = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskSubmits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskSubmits_AssignTasks_AssignTaskId",
                        column: x => x.AssignTaskId,
                        principalTable: "AssignTasks",
                        principalColumn: "AssignTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskSubmits_AssignTaskId",
                table: "UserTaskSubmits",
                column: "AssignTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasks_TasksTaskId",
                table: "AssignTasks",
                column: "TasksTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
