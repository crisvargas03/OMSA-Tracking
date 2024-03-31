using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OMSATrackingAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buss_Route_RouteId",
                table: "Buss");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Buss_BusId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRoutes_Buss_IdBus",
                table: "FavoriteRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buss",
                table: "Buss");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUsers");

            migrationBuilder.RenameTable(
                name: "Buss",
                newName: "Buses");

            migrationBuilder.RenameIndex(
                name: "IX_Buss_RouteId",
                table: "Buses",
                newName: "IX_Buses_RouteId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AppUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AppUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buses",
                table: "Buses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationDate", "Password", "Username" },
                values: new object[] { 1001, "Admin", new DateTime(2024, 3, 31, 3, 8, 3, 41, DateTimeKind.Utc).AddTicks(9959), false, null, "Api12345", "Api" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 43, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 43, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Route_RouteId",
                table: "Buses",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Buses_BusId",
                table: "Drivers",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRoutes_Buses_IdBus",
                table: "FavoriteRoutes",
                column: "IdBus",
                principalTable: "Buses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Route_RouteId",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Buses_BusId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRoutes_Buses_IdBus",
                table: "FavoriteRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buses",
                table: "Buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.RenameTable(
                name: "Buses",
                newName: "Buss");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Buses_RouteId",
                table: "Buss",
                newName: "IX_Buss_RouteId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1001', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buss",
                table: "Buss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Buss",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Buss",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreationDate",
                value: new DateTime(2024, 3, 31, 3, 2, 19, 43, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.AddForeignKey(
                name: "FK_Buss_Route_RouteId",
                table: "Buss",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Buss_BusId",
                table: "Drivers",
                column: "BusId",
                principalTable: "Buss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRoutes_Buss_IdBus",
                table: "FavoriteRoutes",
                column: "IdBus",
                principalTable: "Buss",
                principalColumn: "Id");
        }
    }
}
