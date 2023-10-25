using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp_net_core_rest_api.Migrations
{
    /// <inheritdoc />
    public partial class newData4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4120), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Royal Villa", 4 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4160), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400.0, 750 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 4, "", new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2023, 10, 25, 14, 45, 15, 662, DateTimeKind.Local).AddTicks(4170), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy" },
                values: new object[] { new DateTime(2023, 10, 25, 11, 12, 32, 208, DateTimeKind.Local).AddTicks(8520), "fghdjskfjksfjslfjnsmlfgjndl", "", "lol", 5 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 10, 25, 11, 12, 32, 208, DateTimeKind.Local).AddTicks(8590), "sdfghjh", "", "bbbb", 5, 200.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft" },
                values: new object[] { new DateTime(2023, 10, 25, 11, 12, 32, 208, DateTimeKind.Local).AddTicks(8600), "qqqqqq", "", "qqqqq", 5, 200.0, 550 });
        }
    }
}
