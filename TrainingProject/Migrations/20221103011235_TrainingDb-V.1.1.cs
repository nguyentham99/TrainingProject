using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Migrations
{
    public partial class TrainingDbV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TasksId",
                table: "Status",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
