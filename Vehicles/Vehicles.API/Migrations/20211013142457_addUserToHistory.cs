using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.API.Migrations
{
    public partial class addUserToHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "histories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_histories_UserId",
                table: "histories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_histories_AspNetUsers_UserId",
                table: "histories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_histories_AspNetUsers_UserId",
                table: "histories");

            migrationBuilder.DropIndex(
                name: "IX_histories_UserId",
                table: "histories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "histories");
        }
    }
}
