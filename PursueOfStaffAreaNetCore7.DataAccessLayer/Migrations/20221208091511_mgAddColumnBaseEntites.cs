using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mgAddColumnBaseEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Profession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "EducationStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Dutys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "DutyAssigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "Areas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "AllowTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisteringUser",
                table: "AllowRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Profession");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "EducationStates");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Dutys");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "DutyAssigns");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "AllowTypes");

            migrationBuilder.DropColumn(
                name: "RegisteringUser",
                table: "AllowRequests");
        }
    }
}
