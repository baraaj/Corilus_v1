using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corilus.Migrations
{
    /// <inheritdoc />
    public partial class Create_Records_infiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorFileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Files_ErrorFileId",
                        column: x => x.ErrorFileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Records_ErrorFileId",
                table: "Records",
                column: "ErrorFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

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
    }
}
