using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConsole.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    Eta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videogiochi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: true),
                    Anno = table.Column<int>(type: "INTEGER", nullable: false),
                    GenereId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogiochi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videogiochi_Generi_GenereId",
                        column: x => x.GenereId,
                        principalTable: "Generi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videogiochi_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Valutazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideogiocoId = table.Column<int>(type: "INTEGER", nullable: true),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: true),
                    Voto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valutazioni_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Valutazioni_Videogiochi_VideogiocoId",
                        column: x => x.VideogiocoId,
                        principalTable: "Videogiochi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valutazioni_UtenteId",
                table: "Valutazioni",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Valutazioni_VideogiocoId",
                table: "Valutazioni",
                column: "VideogiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogiochi_GenereId",
                table: "Videogiochi",
                column: "GenereId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogiochi_PlatformId",
                table: "Videogiochi",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valutazioni");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Videogiochi");

            migrationBuilder.DropTable(
                name: "Generi");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
