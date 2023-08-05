using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOpinions.DAL.Migrations
{
    public partial class NewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AppUserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AppUserID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AppUserID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppUserID",
                table: "Posts",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AppUserID",
                table: "Comments",
                column: "AppUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AppUserID",
                table: "Posts",
                column: "AppUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
