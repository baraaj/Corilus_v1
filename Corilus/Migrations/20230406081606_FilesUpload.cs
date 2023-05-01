using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corilus.Migrations
{
    /// <inheritdoc />
    public partial class FilesUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_date",
                value: new DateTime(2023, 4, 6, 10, 16, 5, 940, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_date",
                value: new DateTime(2023, 4, 6, 10, 16, 5, 940, DateTimeKind.Local).AddTicks(4427));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_date",
                value: new DateTime(2023, 4, 6, 10, 3, 41, 235, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_date",
                value: new DateTime(2023, 4, 6, 10, 3, 41, 235, DateTimeKind.Local).AddTicks(1905));
        }
    }
}
