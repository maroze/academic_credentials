using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Users_is_users",
                table: "UserLots");

            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "Users",
                newName: "avatar");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "PlateNumder",
                table: "Users",
                newName: "state_num");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "is_users",
                table: "UserLots",
                newName: "id_users");

            migrationBuilder.RenameColumn(
                name: "IsExpired",
                table: "UserLots",
                newName: "is_expired");

            migrationBuilder.RenameIndex(
                name: "IX_UserLots_is_users",
                table: "UserLots",
                newName: "IX_UserLots_id_users");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Users_id_users",
                table: "UserLots",
                column: "id_users",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Users_id_users",
                table: "UserLots");

            migrationBuilder.RenameColumn(
                name: "avatar",
                table: "Users",
                newName: "Avatar");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "state_num",
                table: "Users",
                newName: "PlateNumder");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "is_expired",
                table: "UserLots",
                newName: "IsExpired");

            migrationBuilder.RenameColumn(
                name: "id_users",
                table: "UserLots",
                newName: "is_users");

            migrationBuilder.RenameIndex(
                name: "IX_UserLots_id_users",
                table: "UserLots",
                newName: "IX_UserLots_is_users");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Users_is_users",
                table: "UserLots",
                column: "is_users",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
