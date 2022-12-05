using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mgAddEntityProfession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DutyAssigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ProfessionId",
                table: "Staffs",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Profession_ProfessionId",
                table: "Staffs",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Profession_ProfessionId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ProfessionId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DutyAssigns");
        }
    }
}
