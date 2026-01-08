using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class tipiCamereAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Camere");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Camere");

            migrationBuilder.AddColumn<int>(
                name: "TipoCameraId",
                table: "Camere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipiCamere",
                columns: table => new
                {
                    TipoCameraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiCamere", x => x.TipoCameraId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camere_TipoCameraId",
                table: "Camere",
                column: "TipoCameraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Camere_TipiCamere_TipoCameraId",
                table: "Camere",
                column: "TipoCameraId",
                principalTable: "TipiCamere",
                principalColumn: "TipoCameraId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camere_TipiCamere_TipoCameraId",
                table: "Camere");

            migrationBuilder.DropTable(
                name: "TipiCamere");

            migrationBuilder.DropIndex(
                name: "IX_Camere_TipoCameraId",
                table: "Camere");

            migrationBuilder.DropColumn(
                name: "TipoCameraId",
                table: "Camere");

            migrationBuilder.AddColumn<decimal>(
                name: "Prezzo",
                table: "Camere",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Camere",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
