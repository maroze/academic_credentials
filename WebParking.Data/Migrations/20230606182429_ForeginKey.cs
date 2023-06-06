using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Parkings_ParksParkId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Lots_LotsLotId",
                table: "UserLots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Users_UsersUserId",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_UserLots_LotsLotId",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_UserLots_UsersUserId",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_ParksParkId",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "LotsLotId",
                table: "UserLots");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UserLots");

            migrationBuilder.DropColumn(
                name: "ParksParkId",
                table: "Lots");

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_id_lots",
                table: "UserLots",
                column: "id_lots");

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_is_users",
                table: "UserLots",
                column: "is_users");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_id_parkings",
                table: "Lots",
                column: "id_parkings");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Parkings_id_parkings",
                table: "Lots",
                column: "id_parkings",
                principalTable: "Parkings",
                principalColumn: "parking_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Lots_id_lots",
                table: "UserLots",
                column: "id_lots",
                principalTable: "Lots",
                principalColumn: "lot_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Users_is_users",
                table: "UserLots",
                column: "is_users",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Parkings_id_parkings",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Lots_id_lots",
                table: "UserLots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLots_Users_is_users",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_UserLots_id_lots",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_UserLots_is_users",
                table: "UserLots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_id_parkings",
                table: "Lots");

            migrationBuilder.AddColumn<int>(
                name: "LotsLotId",
                table: "UserLots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "UserLots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParksParkId",
                table: "Lots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_LotsLotId",
                table: "UserLots",
                column: "LotsLotId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_UsersUserId",
                table: "UserLots",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ParksParkId",
                table: "Lots",
                column: "ParksParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Parkings_ParksParkId",
                table: "Lots",
                column: "ParksParkId",
                principalTable: "Parkings",
                principalColumn: "parking_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Lots_LotsLotId",
                table: "UserLots",
                column: "LotsLotId",
                principalTable: "Lots",
                principalColumn: "lot_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLots_Users_UsersUserId",
                table: "UserLots",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
