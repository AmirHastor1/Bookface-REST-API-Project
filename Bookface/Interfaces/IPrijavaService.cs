using Bookface.Models;
using Bookface.Models.Enums;

namespace Bookface.Interfaces
{
    public interface IPrijavaService
    {
        void kreirajPrijavuZaObjavu(Guid objavaId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis);
        void kreirajPrijavuZaKomentar(Guid komentarId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis);
        IEnumerable<Prijava> dohvatiPrijave();
        void obrisiPrijavu(Guid prijavaId);
    }
}
