using Microsoft.EntityFrameworkCore.Migrations;

namespace TestverktygAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
