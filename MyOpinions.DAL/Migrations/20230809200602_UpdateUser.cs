using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOpinions.DAL.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 23, 6, 1, 865, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Role" },
                values: new object[] { new DateTime(2023, 8, 9, 23, 6, 1, 866, DateTimeKind.Local).AddTicks(6358), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 20, 53, 17, 565, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Role" },
                values: new object[] { new DateTime(2023, 8, 9, 20, 53, 17, 567, DateTimeKind.Local).AddTicks(442), 0 });
        }
    }
}
