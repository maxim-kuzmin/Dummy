using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Makc.Dummy.Writer.Infrastructure.EntityFrameworkForPostgreSQL.App.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "writer");

            migrationBuilder.CreateTable(
                name: "app_outgoing_event",
                schema: "writer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    сoncurrency_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_outgoing_event", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dummy_item",
                schema: "writer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    сoncurrency_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_outgoing_event_payload",
                schema: "writer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    app_outgoing_event_id = table.Column<long>(type: "bigint", nullable: false),
                    сoncurrency_token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    data = table.Column<string>(type: "text", nullable: true),
                    entity_concurrency_token_to_delete = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    entity_concurrency_token_to_insert = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    entity_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    entity_name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_outgoing_event_payload", x => x.Id);
                    table.ForeignKey(
                        name: "fk_app_outgoing_event_payload_app_outgoing_event",
                        column: x => x.app_outgoing_event_id,
                        principalSchema: "writer",
                        principalTable: "app_outgoing_event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_app_outgoing_event_payload_app_outgoing_event_id",
                schema: "writer",
                table: "app_outgoing_event_payload",
                column: "app_outgoing_event_id");

            migrationBuilder.CreateIndex(
                name: "ux_dummy_item_name",
                schema: "writer",
                table: "dummy_item",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_outgoing_event_payload",
                schema: "writer");

            migrationBuilder.DropTable(
                name: "dummy_item",
                schema: "writer");

            migrationBuilder.DropTable(
                name: "app_outgoing_event",
                schema: "writer");
        }
    }
}
