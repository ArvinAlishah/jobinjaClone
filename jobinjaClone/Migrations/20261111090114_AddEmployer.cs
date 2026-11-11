using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobinjaClone.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileImage_JobSeekerId",
                table: "ProfileImage");

            migrationBuilder.CreateTable(
                name: "EmploeyNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploeyNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeFeild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeFeild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeNameFarsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveLogo = table.Column<bool>(type: "bit", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    PrivateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployNumberId = table.Column<int>(type: "int", nullable: false),
                    OfficeFieldId = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    AboutOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_EmploeyNumber_EmployNumberId",
                        column: x => x.EmployNumberId,
                        principalTable: "EmploeyNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Office_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Office_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeOfficeFeild",
                columns: table => new
                {
                    OfficeFeildId = table.Column<int>(type: "int", nullable: false),
                    officeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeOfficeFeild", x => new { x.OfficeFeildId, x.officeId });
                    table.ForeignKey(
                        name: "FK_OfficeOfficeFeild_OfficeFeild_OfficeFeildId",
                        column: x => x.OfficeFeildId,
                        principalTable: "OfficeFeild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeOfficeFeild_Office_officeId",
                        column: x => x.officeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImage_JobSeekerId",
                table: "ProfileImage",
                column: "JobSeekerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employer_UserId",
                table: "Employer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_EmployerId",
                table: "Office",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Office_EmployNumberId",
                table: "Office",
                column: "EmployNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_ProvinceId",
                table: "Office",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeOfficeFeild_officeId",
                table: "OfficeOfficeFeild",
                column: "officeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeOfficeFeild");

            migrationBuilder.DropTable(
                name: "OfficeFeild");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "EmploeyNumber");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImage_JobSeekerId",
                table: "ProfileImage");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImage_JobSeekerId",
                table: "ProfileImage",
                column: "JobSeekerId");
        }
    }
}
