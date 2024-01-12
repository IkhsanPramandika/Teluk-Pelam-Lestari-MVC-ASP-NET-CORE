using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Migrations
{
    /// <inheritdoc />
    public partial class Transaksi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPembeli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBeli = table.Column<int>(type: "int", nullable: false),
                    TotalHarga = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaksi");
        }
    }
}
