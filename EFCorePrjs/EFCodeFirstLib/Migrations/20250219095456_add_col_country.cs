using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCodeFirstLib.Migrations
{
    /// <inheritdoc />
    public partial class add_col_country : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "customers");
        }
    }
}
