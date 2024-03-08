using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoComida",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComida", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    TipoComidaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Platos_TipoComida_TipoComidaID",
                        column: x => x.TipoComidaID,
                        principalTable: "TipoComida",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoComida",
                columns: new[] { "ID", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Italiana" },
                    { 2, "Mexicana" },
                    { 3, "Americana" },
                    { 4, "Ecuatoriana" },
                    { 5, "Colombiana" }
                });

            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "ID", "Nombre", "Precio", "TipoComidaID" },
                values: new object[,]
                {
                    { 1, "LaSagna", 10.0, 1 },
                    { 2, "Tacos", 8.5, 2 },
                    { 3, "Hamburguesa", 7.5, 3 },
                    { 4, "Guatita", 9.0, 4 },
                    { 5, "Ceviche", 5.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Platos_TipoComidaID",
                table: "Platos",
                column: "TipoComidaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platos");

            migrationBuilder.DropTable(
                name: "TipoComida");
        }
    }
}
