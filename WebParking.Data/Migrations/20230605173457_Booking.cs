using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "user_id",
            //    keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlateNumder",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "UserLots",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.CreateTable(
            //    name: "IdentityRole",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "text", nullable: false),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        NormalizedName = table.Column<string>(type: "text", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IdentityRole", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_IdentityRole_RoleId",
            //    table: "Users",
            //    column: "RoleId",
            //    principalTable: "IdentityRole",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Users_IdentityRole_RoleId",
            //    table: "Users");

            //migrationBuilder.DropTable(
            //    name: "IdentityRole");

            //migrationBuilder.DropIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlateNumder",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "UserLots");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "user_id", "username", "password", "RoleId" },
            //    values: new object[] { 4, "user123@gmail.com", "uLPgvqSITeMvVge9ngnqiazK9ZZf7WMT/Ro9Z4BrAkM=", "b7883915-6e29-42a1-8c85-39ff4aa69b53" });
        }
    }
}
