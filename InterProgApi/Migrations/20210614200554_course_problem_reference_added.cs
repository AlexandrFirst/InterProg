using Microsoft.EntityFrameworkCore.Migrations;

namespace InterProgApi.Migrations
{
    public partial class course_problem_reference_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Courses_CourseId",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Courses_CourseId",
                table: "Problems",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Courses_CourseId",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Problems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Courses_CourseId",
                table: "Problems",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
