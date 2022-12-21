using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mgAddNewColumnStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffStatuId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DegreeId",
                table: "Staffs",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffStatuId",
                table: "Staffs",
                column: "StaffStatuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Degrees_DegreeId",
                table: "Staffs",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_StaffStatus_StaffStatuId",
                table: "Staffs",
                column: "StaffStatuId",
                principalTable: "StaffStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Degrees_DegreeId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_StaffStatus_StaffStatuId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DegreeId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_StaffStatuId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffStatuId",
                table: "Staffs");
        }
    }
}
