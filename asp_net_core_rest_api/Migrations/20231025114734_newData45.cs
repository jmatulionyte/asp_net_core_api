using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_core_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class newData45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 47, 34, 792, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 47, 34, 792, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 47, 34, 792, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 47, 34, 792, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 47, 34, 792, DateTimeKind.Local).AddTicks(9070));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170));
        }
    }
}
