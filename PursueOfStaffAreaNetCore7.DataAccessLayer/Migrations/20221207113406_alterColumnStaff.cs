using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class alterColumnStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_EducationStates_EducationStateId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Staffs");

            migrationBuilder.AlterColumn<int>(
                name: "EducationStateId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_EducationStates_EducationStateId",
                table: "Staffs",
                column: "EducationStateId",
                principalTable: "EducationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_EducationStates_EducationStateId",
                table: "Staffs");

            migrationBuilder.AlterColumn<int>(
                name: "EducationStateId",
                table: "Staffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_EducationStates_EducationStateId",
                table: "Staffs",
                column: "EducationStateId",
                principalTable: "EducationStates",
                principalColumn: "Id");
        }
    }
}
