using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VezeetaApi.EF.Migrations
{
    public partial class AddingTimesAndAccountTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accountType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestID = table.Column<int>(type: "int", nullable: false),
                    requestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Times_requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "requests",
                        principalColumn: "RequestsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Times_RequestsId",
                table: "Times",
                column: "RequestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropColumn(
                name: "accountType",
                table: "AspNetUsers");
        }
    }
}
