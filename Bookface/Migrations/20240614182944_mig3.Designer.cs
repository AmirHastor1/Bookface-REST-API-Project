﻿// <auto-generated />
using System;
using Bookface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookface.Migrations
{
    [DbContext(typeof(BookfaceAppDBContext))]
    [Migration("20240614182944_mig3")]
    partial class mig3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookface.Models.Komentar", b =>
                {
                    b.Property<Guid>("komentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imeKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("komentarMedia")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("komentarTekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("korisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("objavaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("komentarId");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("Bookface.Models.Korisnik", b =>
                {
                    b.Property<Guid>("korisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("darkTheme")
                        .HasColumnType("bit");

                    b.Property<DateTime>("datumKreiranjaProfila")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jwt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("notificationsEnabled")
                        .HasColumnType("bit");

                    b.Property<byte[]>("sifraHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("sifraSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("slikaProfila")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("tipKorisnika")
                        .HasColumnType("int");

                    b.Property<bool>("twoFAEnabled")
                        .HasColumnType("bit");

                    b.HasKey("korisnikId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Bookface.Models.Lajk", b =>
                {
                    b.Property<Guid>("lajkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("korisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("objavaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("lajkId");

                    b.ToTable("Lajk");
                });

            modelBuilder.Entity("Bookface.Models.Notifikacija", b =>
                {
                    b.Property<Guid>("notifikacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("komentarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("korisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("notifikacijaTekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("novaNotifikacija")
                        .HasColumnType("bit");

                    b.Property<Guid?>("objavaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("prijavaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("tipNotifikacije")
                        .HasColumnType("int");

                    b.Property<DateTime>("vrijemeSlanjaNotifikacije")
                        .HasColumnType("datetime2");

                    b.HasKey("notifikacijaId");

                    b.ToTable("Notifikacija");
                });

            modelBuilder.Entity("Bookface.Models.Objava", b =>
                {
                    b.Property<Guid>("objavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("brojKomentara")
                        .HasColumnType("int");

                    b.Property<int>("brojLajkova")
                        .HasColumnType("int");

                    b.Property<Guid>("korisnikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("objavaMedia")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("objavaTagovi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objavaTekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeObjave")
                        .HasColumnType("datetime2");

                    b.HasKey("objavaId");

                    b.ToTable("Objava");
                });

            modelBuilder.Entity("Bookface.Models.Prijava", b =>
                {
                    b.Property<Guid>("prijavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("podnosilacPrijave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("prijavljenaObjavaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("prijavljeniKomentarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("vrstaPrijave")
                        .HasColumnType("int");

                    b.HasKey("prijavaId");

                    b.ToTable("Prijava");
                });
#pragma warning restore 612, 618
        }
    }
}
