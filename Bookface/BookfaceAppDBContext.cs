using Bookface.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bookface
{
    public class BookfaceAppDBContext : DbContext
    {
        public BookfaceAppDBContext(DbContextOptions<BookfaceAppDBContext> options) : base(options)
        {

        }
        public DbSet<Korisnik> Korisnik { get; set; } //User Table in DB
        public DbSet<Objava> Objava { get; set; } //Blog Table in DB
        public DbSet<Lajk> Lajk { get; set; } //Like Table in DB
        public DbSet<Komentar> Komentar { get; set; } //Comment Table in DB
        public DbSet<Notifikacija> Notifikacija { get; set; } //Notification Table in DB
        public DbSet<Prijava> Prijava { get; set; } //Notification Table in DB
    }
}
