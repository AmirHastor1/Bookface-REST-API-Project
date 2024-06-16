using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookface.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "podnosilacPrijaveId",
                table: "Prijava");

            migrationBuilder.RenameColumn(
                name: "prijavljenaOsobaId",
                table: "Prijava",
                newName: "podnosilacPrijave");

            migrationBuilder.RenameColumn(
                name: "komentarModia",
                table: "Komentar",
                newName: "komentarMedia");

            migrationBuilder.AlterColumn<Guid>(
                name: "prijavljeniKomentarId",
                table: "Prijava",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "prijavljenaObjavaId",
                table: "Prijava",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "objavaTagovi",
                table: "Objava",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "prijavaId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "objavaId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "komentarId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prijavljenaObjavaId",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "objavaTagovi",
                table: "Objava");

            migrationBuilder.RenameColumn(
                name: "podnosilacPrijave",
                table: "Prijava",
                newName: "prijavljenaOsobaId");

            migrationBuilder.RenameColumn(
                name: "komentarMedia",
                table: "Komentar",
                newName: "komentarModia");

            migrationBuilder.AlterColumn<Guid>(
                name: "prijavljeniKomentarId",
                table: "Prijava",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "podnosilacPrijaveId",
                table: "Prijava",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "prijavaId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "objavaId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "komentarId",
                table: "Notifikacija",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
