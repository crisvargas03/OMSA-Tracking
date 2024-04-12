using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OMSATrackingAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteBusStop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteBusStop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusStopId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBusStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteBusStop_BusStop_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

 
            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusStop_BusStopId",
                table: "FavoriteBusStop",
                column: "BusStopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteBusStop");

        }
    }
}
