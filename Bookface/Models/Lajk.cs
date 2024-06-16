using System.ComponentModel.DataAnnotations;

namespace Bookface.Models
{
    public class Lajk
    {
        [Key]
        public Guid lajkId { get; set; }
        public Guid korisnikId { get; set; }
        public Guid objavaId { get; set; }

    }
}
