using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobinjaClone.Migrations
{
    /// <inheritdoc />
    public partial class AddOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Minimumwage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minimum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minimumwage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearExprience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearExprience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrefersContactId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    JobCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ExpectedSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearExpriceId = table.Column<int>(type: "int", nullable: false),
                    MinmumWageId = table.Column<int>(type: "int", nullable: false),
                    GenderImportent = table.Column<bool>(type: "bit", nullable: false),
                    Gnder = table.Column<int>(type: "int", nullable: false),
                    MilitaryStatusImportent = table.Column<bool>(type: "bit", nullable: false),
                    military = table.Column<int>(type: "int", nullable: false),
                    offerStatus = table.Column<int>(type: "int", nullable: false),
                    EmployId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Employer_EmployId",
                        column: x => x.EmployId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_JobCategories_JobCategoriesId",
                        column: x => x.JobCategoriesId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Minimumwage_MinmumWageId",
                        column: x => x.MinmumWageId,
                        principalTable: "Minimumwage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_PrefersContacts_PrefersContactId",
                        column: x => x.PrefersContactId,
                        principalTable: "PrefersContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_YearExprience_YearExpriceId",
                        column: x => x.YearExpriceId,
                        principalTable: "YearExprience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EmployId",
                table: "Offers",
                column: "EmployId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_JobCategoriesId",
                table: "Offers",
                column: "JobCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MinmumWageId",
                table: "Offers",
                column: "MinmumWageId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PrefersContactId",
                table: "Offers",
                column: "PrefersContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProvinceId",
                table: "Offers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_YearExpriceId",
                table: "Offers",
                column: "YearExpriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Minimumwage");

            migrationBuilder.DropTable(
                name: "YearExprience");
        }
    }
}
