using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Migrations
{
    public partial class TrainingDbV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Tasks_TasksId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_TasksId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "TasksId",
                table: "Status");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TasksId",
                table: "Status",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_TasksId",
                table: "Status",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Tasks_TasksId",
                table: "Status",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
