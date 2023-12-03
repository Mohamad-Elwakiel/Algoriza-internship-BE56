using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VezeetaApi.EF.Migrations
{
    public partial class RemovingRequestID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_AspNetUsers_UserId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_AspNetUsers_UserId",
                table: "doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_AspNetUsers_UserId",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_AspNetUsers_UserId",
                table: "doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
