using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobinjaClone.Migrations
{
    /// <inheritdoc />
    public partial class changeOfficeFeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeFieldId",
                table: "Office");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeFieldId",
                table: "Office",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
