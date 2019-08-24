using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCulture.DataAccess.Migrations
{
    public partial class Added_PublicId_to_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "FamousPlaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "FamousPlaces");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Accounts");
        }
    }
}
