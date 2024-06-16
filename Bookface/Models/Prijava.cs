using System.ComponentModel.DataAnnotations;
using Bookface.Models.Enums;

namespace Bookface.Models
{
    public class Prijava
    {
        [Key] 
        public Guid prijavaId { get; set; }
        public Guid? prijavljenaObjavaId { get; set; } = null;
        public Guid? prijavljeniKomentarId { get; set; } = null;
        public Guid podnosilacPrijave { get; set; }
        public VrstaPrijave vrstaPrijave { get; set; }
        public string? opis { get; set; } = string.Empty;
    }
}
