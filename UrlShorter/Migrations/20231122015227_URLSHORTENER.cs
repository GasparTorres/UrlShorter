using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShorter.Migrations
{
    /// <inheritdoc />
    public partial class URLSHORTENER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    RolUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URLShort = table.Column<string>(type: "TEXT", nullable: true),
                    URLLong = table.Column<string>(type: "TEXT", nullable: true),
                    contador = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLs_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_URLs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trabajo" },
                    { 2, "Diversion" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "RolUser" },
                values: new object[,]
                {
                    { 1, "Gaspar", "password", 0 },
                    { 2, "Jose", "password", 1 },
                    { 3, "Guest", "password", 2 }
                });

            migrationBuilder.InsertData(
                table: "URLs",
                columns: new[] { "Id", "IdCategoria", "IdUser", "URLLong", "URLShort", "contador" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lasoadsat", "jef", 0 },
                    { 2, 2, 2, "Lasotsdasdsa", "Karenaaa", 1 },
                    { 3, 2, 2, "Ldsadsadasdasot", "asddsadsa", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLs_IdCategoria",
                table: "URLs",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_URLs_IdUser",
                table: "URLs",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLs");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
