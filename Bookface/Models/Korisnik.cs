using System.ComponentModel.DataAnnotations;
using Bookface.Models.Enums;

namespace Bookface.Models
{
    public class Korisnik
    {
        [Key]
        public Guid korisnikId { get; set; }
        public string naziv { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public byte[]? slikaProfila { get; set; }
        public byte[] sifraHash { get; set; }
        public byte[] sifraSalt { get; set; }
        public string? jwt { get; set; }
        public DateTime datumKreiranjaProfila { get; set; } = DateTime.Now;
        public bool darkTheme { get; set; } = true;
        public bool notificationsEnabled { get; set; } = true;
        public bool twoFAEnabled { get; set; } = true;
        public TipKorisnika tipKorisnika { get; set; } = TipKorisnika.Korisnik;
    }
}
