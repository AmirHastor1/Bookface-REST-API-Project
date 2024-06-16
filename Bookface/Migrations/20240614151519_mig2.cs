using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookface.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    komentarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    objavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imeKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    komentarTekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    komentarModia = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.komentarId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slikaProfila = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    sifraHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    sifraSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    jwt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datumKreiranjaProfila = table.Column<DateTime>(type: "datetime2", nullable: false),
                    darkTheme = table.Column<bool>(type: "bit", nullable: false),
                    notificationsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    twoFAEnabled = table.Column<bool>(type: "bit", nullable: false),
                    tipKorisnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Lajk",
                columns: table => new
                {
                    lajkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    objavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lajk", x => x.lajkId);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacija",
                columns: table => new
                {
                    notifikacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    objavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    komentarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vrijemeSlanjaNotifikacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    notifikacijaTekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    novaNotifikacija = table.Column<bool>(type: "bit", nullable: false),
                    tipNotifikacije = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacija", x => x.notifikacijaId);
                });

            migrationBuilder.CreateTable(
                name: "Objava",
                columns: table => new
                {
                    objavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    objavaMedia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    objavaTekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vrijemeObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    brojLajkova = table.Column<int>(type: "int", nullable: false),
                    brojKomentara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objava", x => x.objavaId);
                });

            migrationBuilder.CreateTable(
                name: "Prijava",
                columns: table => new
                {
                    prijavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prijavljenaOsobaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prijavljeniKomentarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    podnosilacPrijaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vrstaPrijave = table.Column<int>(type: "int", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijava", x => x.prijavaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Lajk");

            migrationBuilder.DropTable(
                name: "Notifikacija");

            migrationBuilder.DropTable(
                name: "Objava");

            migrationBuilder.DropTable(
                name: "Prijava");
        }
    }
}
