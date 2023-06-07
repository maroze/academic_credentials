using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class RowColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "column",
                table: "Parkings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "row",
                table: "Parkings",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "column",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "row",
                table: "Parkings");
        }
    }
}
