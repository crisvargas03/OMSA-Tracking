using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMSATrackingAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Origin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Longitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Plate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EstimatedArrivalHour = table.Column<string>(type: "text", nullable: false),
                    PassengerLimit = table.Column<int>(type: "integer", nullable: false),
                    RouteId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buss_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IndentificationDocument = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Buss_BusId",
                        column: x => x.BusId,
                        principalTable: "Buss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIdentificationCode = table.Column<int>(type: "integer", nullable: false),
                    IdBus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteRoutes_Buss_IdBus",
                        column: x => x.IdBus,
                        principalTable: "Buss",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Address", "Code", "CreatedBy", "CreationDate", "Destination", "IsDeleted", "ModificationDate", "Name", "Origin" },
                values: new object[,]
                {
                    { 1001, "Av. Maximo Gomez", "R001", "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(6240), "Destino 1", false, null, "Ruta Principal", "Origen 1" },
                    { 1002, "Corredor John F. Kennedy", "R002", "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(6244), "Destino 2", false, null, "Ruta Secundaria", "Origen 2" }
                });

            migrationBuilder.InsertData(
                table: "Buss",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "EstimatedArrivalHour", "IsDeleted", "Latitude", "Longitude", "ModificationDate", "Name", "PassengerLimit", "Plate", "RouteId" },
                values: new object[,]
                {
                    { 1001, "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(2129), "08:00", false, "18.486057", "-69.931212", null, "Bus 1", 30, "A123456", 1001 },
                    { 1002, "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(2135), "08:00", false, "18.486057", "-69.931212", null, "Bus 2", 30, "B123456", 1002 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "BusId", "CreatedBy", "CreationDate", "IndentificationDocument", "IsDeleted", "LastName", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1001, 1001, "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(3749), "123456789", false, "Driver 1", null, "Driver 1" },
                    { 1002, 1002, "Admin", new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(3751), "987654321", false, "Driver 2", null, "Driver 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buss_RouteId",
                table: "Buss",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_BusId",
                table: "Drivers",
                column: "BusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRoutes_IdBus",
                table: "FavoriteRoutes",
                column: "IdBus",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "FavoriteRoutes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Buss");

            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
