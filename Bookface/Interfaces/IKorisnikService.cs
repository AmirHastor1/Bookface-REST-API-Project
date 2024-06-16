using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookface.Models;

namespace Bookface.Interfaces
{
    public interface IKorisnikService
    {
        void registrujKorisnika(string username, string email, string password, byte[]? image);
        bool obrisiKorisnika(Guid korisnikId, string authorizationKey);
        string logIn(string email, string password);
        void logOut(string jwt);
        void izmijeniKorisnika(string jwt, Guid korisnikId, string email, string naziv, bool darkTheme, bool notificationOn, bool twoFAEnabled, byte[]? image = null);
        Korisnik? dohvatiKorisnikaPoKorisnickomImenu(string korisnickoIme);

    }
}
