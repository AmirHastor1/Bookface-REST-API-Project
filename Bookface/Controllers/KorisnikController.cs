using Bookface.Services;
using Bookface.Interfaces;
using Bookface.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bookface.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class KorisnikController : ControllerBase
    {

        private readonly IKorisnikService _korisnikService;

        public KorisnikController(IKorisnikService userService)
        {
            _korisnikService = userService;
        }

        
        [HttpPost]
        [Route("korisnik/registracija"), AllowAnonymous]
        public void registrujKorisnika(string username, string email, string password, byte[]? image)
        {
            if (username == null || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine(username + " ili " + email + "nisu definisani");
                throw new Exception("Invalid request parameters");
            }
            _korisnikService.registrujKorisnika(username, email, password, image);
        }

        [HttpPost]
        [Route("korisnik/logIn"), AllowAnonymous]
        public string prijaviKorisnika(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) == null || string.IsNullOrWhiteSpace(password))
                throw new Exception("Invalid request parameters");
            return _korisnikService.logIn(email, password);
        }

        [HttpPut]
        [Route("korisnik/logOut"), AllowAnonymous]
        public void logOut(string jwt)
        {
            _korisnikService.logOut(jwt);
        }

        [HttpPut("korisnik/uredi"), AllowAnonymous]
        public void izmijeniKorisnika(string jwt, Guid korisnikId, string email, byte[] image, string naziv, bool darkTheme, bool notificationOn, bool twoFAEnabled)
        {
            _korisnikService.izmijeniKorisnika(jwt, korisnikId, email,naziv, darkTheme, notificationOn, twoFAEnabled, image);
        }

        [HttpGet]
        [Route("korisnik/poKorisnickomImenu"), AllowAnonymous]
        public Korisnik dohvatiKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            return _korisnikService.dohvatiKorisnikaPoKorisnickomImenu(korisnickoIme);
        }
        /*

        [HttpGet("korisnik/{korisnikId}"), AllowAnonymous]
        public Korisnik dohvatiKorisnika(Guid korisnikId)
        {
            return _korisnikService.dohvatiKorisnika(korisnikId);
        }

        [HttpGet]
        [Route("korisnik/imePoId"), AllowAnonymous]
        public string dohvatiKorisnickoImePoId(Guid korisnikId)
        {
            return _korisnikService.dohvatiKorisnickoImePoId(korisnikId);
        }

        [HttpGet]
        [Route("korisnik/poJWT"), AllowAnonymous]
        public IEnumerable<Korisnik> dohvatiKorisnikaPoJWT(string jwt)
        {
            return _korisnikService.dohvatiKorisnikaPoJWT(jwt);
        }

        

        [HttpGet]
        [Route("korisnik/poKorisnickomImenu"), AllowAnonymous]
        public IEnumerable<Korisnik> dohvatiKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            return _korisnikService.dohvatiKorisnikaPoKorisnickomImenu(korisnickoIme);
        }

        


        
        */

    }
}
