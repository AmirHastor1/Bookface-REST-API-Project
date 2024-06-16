using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookface.Models
{
    public class Objava
    {
        [Key]
        public Guid objavaId { get; set; }
        public Guid korisnikId { get; set; }
        public byte[]? objavaMedia { get; set; }
        public string? objavaTekst { get; set; } = string.Empty;
        public DateTime vrijemeObjave { get; set; } = DateTime.Now;
        public int brojLajkova { get; set; } = 0;
        public int brojKomentara { get; set; } = 0;
        public string? objavaTagovi { get; set; } = string.Empty;

    }
}
