using Bookface.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookface.Interfaces
{
    public interface IObjavaService
    {
        void kreirajObjavu(Guid korisnikId, byte[] media, string tekst, string tagovi);
        void kreirajKomentar(Guid objavaId, Guid korisnikId, string komentarTeskt, byte[] komentarMedia);
        void kreirajLajk(Guid korisnikId, Guid objavaId);
        IEnumerable<Objava> dohvatiObjave();
        bool obrisiObjavu(Guid objavaId, string jwt);
        bool obrisiKomentar(Guid komentarId, string jwt);
        IEnumerable<Komentar> dohvatiKomentare(Guid objavaId, int paginacija);
        IEnumerable<Objava> dohvatiObjaveKorisnika(Guid korisnikId, int paginacija);
        IEnumerable<Objava> dohvatiObjave(int paginacija);

        IEnumerable<string> vratiOmiljeneTagoveKorisnika(Guid korisnikId);
        IEnumerable<Objava> dohvatiPreporuceneObjave(Guid korisnikId);

    }
}
