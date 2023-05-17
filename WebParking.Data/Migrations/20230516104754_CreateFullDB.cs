using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebParking.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateFullDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "user_id");

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    parking_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image = table.Column<byte[]>(type: "bytea", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    adress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.parking_id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    lot_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_bloked = table.Column<bool>(type: "boolean", nullable: false),
                    is_booked = table.Column<bool>(type: "boolean", nullable: false),
                    id_parkings = table.Column<int>(type: "integer", nullable: false),
                    ParksParkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.lot_id);
                    table.ForeignKey(
                        name: "FK_Lots_Parkings_ParksParkId",
                        column: x => x.ParksParkId,
                        principalTable: "Parkings",
                        principalColumn: "parking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLots",
                columns: table => new
                {
                    user_lot_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    booked_at = table.Column<string>(type: "text", nullable: false),
                    id_lots = table.Column<int>(type: "integer", nullable: false),
                    LotsLotId = table.Column<int>(type: "integer", nullable: false),
                    is_users = table.Column<int>(type: "integer", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLots", x => x.user_lot_id);
                    table.ForeignKey(
                        name: "FK_UserLots_Lots_LotsLotId",
                        column: x => x.LotsLotId,
                        principalTable: "Lots",
                        principalColumn: "lot_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLots_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ParksParkId",
                table: "Lots",
                column: "ParksParkId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_LotsLotId",
                table: "UserLots",
                column: "LotsLotId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLots_UsersUserId",
                table: "UserLots",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLots");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "UserId");
        }
    }
}
