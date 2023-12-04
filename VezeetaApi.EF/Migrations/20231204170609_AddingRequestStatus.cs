using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VezeetaApi.EF.Migrations
{
    public partial class AddingRequestStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestState",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestState",
                table: "requests");
        }
    }
}
