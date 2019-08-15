using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCulture.DataAccess.Migrations
{
    public partial class Account_Son_Duzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonelInfo",
                table: "Accounts",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonelInfo",
                table: "Accounts",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);
        }
    }
}
