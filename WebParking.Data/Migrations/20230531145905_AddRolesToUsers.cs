using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fffc49d-18c4-46fd-ac62-f37379c2ab27", null, "manager", "MANAGER" },
                    { "7e83c622-c213-441e-8e55-d49f9f8d9774", null, "admin", "ADMIN" },
                    { "b7883915-6e29-42a1-8c85-39ff4aa69b53", null, "user", "USER" }
                });
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "username", "password", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "0PPE53Od3zW6JCh6ANe25XPbvOW3pYQFbTG2ORH1pC0=", "7e83c622-c213-441e-8e55-d49f9f8d9774" },
                    { 2, "manager@example.com", "s7hPimq9hoSW5FOcksrQ6DdT0i3Br8ewGxXaeoCApYI=", "5fffc49d-18c4-46fd-ac62-f37379c2ab27" },
                    { 3, "user@example.com", "AH7B302Iapxf7EFzZVW0/kJDuf/I3pDPkQ42IxBTakA=", "b7883915-6e29-42a1-8c85-39ff4aa69b53" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Users",
               keyColumn: "user_id",
               keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 3);
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5fffc49d-18c4-46fd-ac62-f37379c2ab27");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7e83c622-c213-441e-8e55-d49f9f8d9774");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b7883915-6e29-42a1-8c85-39ff4aa69b53");
        }
    }
}
