using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AvaloniaApp.Migrations
{
    /// <inheritdoc />
    public partial class NameOfUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("equipment_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "request_equipment",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying", nullable: false),
                    reqid = table.Column<long>(type: "bigint", nullable: true),
                    eqid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("request_equipment_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("type_request_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    passowrd = table.Column<string>(type: "text", nullable: true),
                    roleid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pk", x => x.id);
                    table.ForeignKey(
                        name: "user_role_fk",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    serial_number = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<long>(type: "bigint", nullable: true),
                    clientid = table.Column<long>(type: "bigint", nullable: true),
                    mechaid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("request_pk", x => x.id);
                    table.ForeignKey(
                        name: "request_type_request_fk",
                        column: x => x.Type,
                        principalTable: "type_request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "request_user_fk",
                        column: x => x.clientid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "request_user_fk_1",
                        column: x => x.mechaid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_request_clientid",
                table: "request",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_request_mechaid",
                table: "request",
                column: "mechaid");

            migrationBuilder.CreateIndex(
                name: "IX_request_Type",
                table: "request",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleid",
                table: "User",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "request_equipment");

            migrationBuilder.DropTable(
                name: "type_request");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
