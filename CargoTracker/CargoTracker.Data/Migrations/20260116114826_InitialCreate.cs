using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargoTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IMO = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CapacityTEU = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentPort = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "Id", "CapacityTEU", "CurrentPort", "IMO", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 23800, "Singapore", "IMO9125050", "EVER ACE", 2 },
                    { 2, 15800, "Mumbai", "IMO9787301", "HMM ALGEBRAS", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_IMO",
                table: "Vessels",
                column: "IMO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
