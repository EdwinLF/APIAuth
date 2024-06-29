using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaExamen.DA.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    idLog = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeLog = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tableLog = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descriptionLog = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateLog = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.idLog);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
