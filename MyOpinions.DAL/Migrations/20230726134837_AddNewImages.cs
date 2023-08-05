using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOpinions.DAL.Migrations
{
    public partial class AddNewImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostImage",
                table: "Posts",
                newName: "PictureName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureName",
                table: "Posts",
                newName: "PostImage");
        }
    }
}
