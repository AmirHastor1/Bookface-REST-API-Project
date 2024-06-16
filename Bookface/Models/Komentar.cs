using System.ComponentModel.DataAnnotations;

namespace Bookface.Models
{
    public class Komentar
    {
        [Key]
        public Guid komentarId { get; set; }
        public Guid objavaId { get; set; }
        public Guid korisnikId { get; set; }
        public string? imeKorisnika { get; set; } = string.Empty;
        public string? komentarTekst { get; set; } = string.Empty;
        public byte[]? komentarMedia { get; set; }
    }
}