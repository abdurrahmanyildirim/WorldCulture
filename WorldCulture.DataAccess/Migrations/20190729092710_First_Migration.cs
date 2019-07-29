using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCulture.DataAccess.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(maxLength: 150, nullable: false),
                    Population = table.Column<string>(maxLength: 13, nullable: false),
                    Currency = table.Column<string>(maxLength: 6, nullable: false),
                    Capital = table.Column<string>(maxLength: 100, nullable: false),
                    President = table.Column<string>(maxLength: 80, nullable: false),
                    SummaryInfo = table.Column<string>(nullable: false),
                    FlagPhotoPath = table.Column<string>(nullable: false),
                    EthnicIdentity = table.Column<string>(maxLength: 20, nullable: false),
                    Language = table.Column<string>(maxLength: 20, nullable: false),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryID = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    Population = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CityPhotoPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    PersonelInfo = table.Column<string>(type: "nvarchar", maxLength: 120, nullable: false),
                    ProfilePhotoPath = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamousPlaces",
                columns: table => new
                {
                    FamousPlaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<int>(nullable: false),
                    PlaceName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamousPlaces", x => x.FamousPlaceID);
                    table.ForeignKey(
                        name: "FK_FamousPlaces_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromAccountID = table.Column<int>(nullable: false),
                    ToAccountID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationID);
                    table.ForeignKey(
                        name: "FK_Relations_Accounts_FromAccountID",
                        column: x => x.FromAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relations_Accounts_ToAccountID",
                        column: x => x.ToAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despatches",
                columns: table => new
                {
                    DespatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamousPlaceID = table.Column<int>(nullable: false),
                    AccountID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    DespatchPhotoPath = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<byte>(nullable: false),
                    CountOfView = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despatches", x => x.DespatchID);
                    table.ForeignKey(
                        name: "FK_Despatches_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despatches_FamousPlaces_FamousPlaceID",
                        column: x => x.FamousPlaceID,
                        principalTable: "FamousPlaces",
                        principalColumn: "FamousPlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespatchID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ReviewContent = table.Column<string>(nullable: false),
                    Rate = table.Column<byte>(nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Despatches_DespatchID",
                        column: x => x.DespatchID,
                        principalTable: "Despatches",
                        principalColumn: "DespatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Despatches_AccountID",
                table: "Despatches",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Despatches_FamousPlaceID",
                table: "Despatches",
                column: "FamousPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_FamousPlaces_CityID",
                table: "FamousPlaces",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_FromAccountID",
                table: "Relations",
                column: "FromAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ToAccountID",
                table: "Relations",
                column: "ToAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DespatchID",
                table: "Reviews",
                column: "DespatchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Despatches");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "FamousPlaces");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
