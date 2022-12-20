using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstellationGarage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brands__357D4CF8C2528B45", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__357D4CF89E4D866F", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codecategorie = table.Column<string>(name: "code_categorie", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    codebrand = table.Column<string>(name: "code_brand", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    essence = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    color = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cars__3213E83F01802EF8", x => x.id);
                    table.ForeignKey(
                        name: "FK__cars__code_brand__3D5E1FD2",
                        column: x => x.codebrand,
                        principalTable: "brands",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK__cars__code_categ__3E52440B",
                        column: x => x.codecategorie,
                        principalTable: "categories",
                        principalColumn: "code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_code_brand",
                table: "cars",
                column: "code_brand");

            migrationBuilder.CreateIndex(
                name: "IX_cars_code_categorie",
                table: "cars",
                column: "code_categorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
