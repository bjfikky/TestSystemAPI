using Microsoft.EntityFrameworkCore.Migrations;

namespace TestSystemASP.Data.Migrations
{
    public partial class AddQuestionOptionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Options",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Options");
        }
    }
}
