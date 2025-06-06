﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFrameworkForMSSQLServer.App.Db.Migrations
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
                name: "AppOutgoingEvent",
                schema: "writer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublishedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOutgoingEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DummyItem",
                schema: "writer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOutgoingEventPayload",
                schema: "writer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppOutgoingEventId = table.Column<long>(type: "bigint", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityConcurrencyTokenToDelete = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EntityConcurrencyTokenToInsert = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOutgoingEventPayload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOutgoingEventPayload_AppOutgoingEvent",
                        column: x => x.AppOutgoingEventId,
                        principalSchema: "writer",
                        principalTable: "AppOutgoingEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOutgoingEventPayload_AppOutgoingEventId",
                schema: "writer",
                table: "AppOutgoingEventPayload",
                column: "AppOutgoingEventId");

            migrationBuilder.CreateIndex(
                name: "UX_DummyItem_Name",
                schema: "writer",
                table: "DummyItem",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOutgoingEventPayload",
                schema: "writer");

            migrationBuilder.DropTable(
                name: "DummyItem",
                schema: "writer");

            migrationBuilder.DropTable(
                name: "AppOutgoingEvent",
                schema: "writer");
        }
    }
}
