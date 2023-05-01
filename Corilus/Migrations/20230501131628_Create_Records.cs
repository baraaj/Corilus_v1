using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corilus.Migrations
{
    /// <inheritdoc />
    public partial class Create_Records : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_date",
                value: new DateTime(2023, 5, 1, 15, 16, 28, 492, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_date",
                value: new DateTime(2023, 5, 1, 15, 16, 28, 492, DateTimeKind.Local).AddTicks(7459));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_date",
                value: new DateTime(2023, 5, 1, 14, 52, 19, 769, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_date",
                value: new DateTime(2023, 5, 1, 14, 52, 19, 769, DateTimeKind.Local).AddTicks(6462));
        }
    }
}
