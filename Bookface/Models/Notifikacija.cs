using System.ComponentModel.DataAnnotations;
using Bookface.Models.Enums;

namespace Bookface.Models
{
    public class Notifikacija
    {
        [Key]
        public Guid notifikacijaId { get; set; }
        public Guid korisnikId { get; set; }
        public Guid? objavaId { get; set; } = null;
        public Guid? prijavaId { get; set; } = null;
        public Guid? komentarId { get; set; } = null;
        public DateTime vrijemeSlanjaNotifikacije { get; set; } = DateTime.Now;
        public string notifikacijaTekst { get; set; } = string.Empty;
        public bool novaNotifikacija { get; set; } = true;
        public TipNotifikacije tipNotifikacije { get; set; }
    }
}
