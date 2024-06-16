using Bookface.Models;
using System.Numerics;

namespace Bookface.Interfaces
{
    public interface INotifikacijaService
    {
        IEnumerable<Notifikacija> dohvatiNotifikacije(Guid korisnikId);
        IEnumerable<Notifikacija> dohvatiNajnovijNotifikacije(Guid korisnikId, BigInteger broj);
        void oznaciSveKaoProcitano(Guid korisnikId);
    }
}
