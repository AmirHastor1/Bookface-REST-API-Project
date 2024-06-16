using Bookface.Interfaces;
using Bookface.Models;
using Bookface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookface.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ObjavaController : ControllerBase
    {
        private readonly IObjavaService _objavaService;

        public ObjavaController(IObjavaService objavaService)
        {
            _objavaService = objavaService;
        }

        [HttpPost]
        [Route("/objave/kreiraj")]
        public void kreirajObjavu(Guid korisnikId, byte[] media, string tekst, string tagovi)
        {
            _objavaService.kreirajObjavu(korisnikId,media,tekst,tagovi);
        }

        [HttpPost]
        [Route("/komentar/kreiraj")]
        public void kreirajKomentar(Guid objavaId, Guid korisnikId, string komentarTeskt, byte[] komentarMedia)
        {
            _objavaService.kreirajKomentar(objavaId, korisnikId, komentarTeskt, komentarMedia);
        }

        [HttpPost]
        [Route("/lajk/kreiraj")]
        public void kreirajLajk(Guid korisnikId, Guid objavaId)
        {
            _objavaService.kreirajLajk(korisnikId, objavaId);
        }

        [HttpGet]

        [Route("/objava/sve")]
        public ActionResult<IEnumerable<Objava>> dohvatiObjave()
        {
            try
            {
                var prijave = _objavaService.dohvatiObjave();
                return Ok(prijave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/komentar/{objavaId}")]
        public ActionResult<IEnumerable<Komentar>> dohvatiKomentare(Guid objavaId, int paginacija)
        {
            try
            {
                var komentari = _objavaService.dohvatiKomentare(objavaId, paginacija);
                return Ok(komentari);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/objava/{korisnikId}")]
        public ActionResult <IEnumerable<Objava>> dohvatiObjaveKorisnika(Guid korisnikId, int paginacija)
        {
            try
            {
                var objave = _objavaService.dohvatiObjaveKorisnika(korisnikId, paginacija);
                return Ok(objave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/objava/svepaginacija")]
        public ActionResult<IEnumerable<Objava>> dohvatiObjave(int paginacija)
        {
            try
            {
                var objave = _objavaService.dohvatiObjave(paginacija);
                return Ok(objave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/tagovi/omiljeni"), AllowAnonymous]
        public IEnumerable<string> vratiOmiljeneTagoveKorisnika(Guid korisnikId)
        {
            return _objavaService.vratiOmiljeneTagoveKorisnika(korisnikId);
        }

        [HttpGet]
        [Route("svekorisnikpreporuceno"), AllowAnonymous]
        public IEnumerable<Objava> dohvatiPreporuceneObjave(Guid korisnikId)
        {
            return _objavaService.dohvatiPreporuceneObjave(korisnikId);
        }


        /*
        [HttpGet]
        [Route("svepaginated"), AllowAnonymous]
        public IEnumerable<Objava> dohvatiObjave()
        {
            return _objavaService.dohvatiObjave();
        }

        [HttpGet]
        [Route("sve"), AllowAnonymous]
        public IEnumerable<Objava> dohvatiObjave(int paginacija)
        {
            return _objavaService.dohvatiObjave(paginacija);
        }

        [HttpGet]
        [Route("svekorisnik"), AllowAnonymous]
        public IEnumerable<Objava> dohvatiObjaveKorisnika(Guid korisnikId, int paginacija)
        {
            return _objavaService.dohvatiObjaveKorisnika(korisnikId, paginacija);
        }

        

        [HttpGet]
        [Route("sve/komentar"), AllowAnonymous]
        public IEnumerable<Komentar> dohvatiKomentare(Guid objavaId, int paginacija)
        {
            return _objavaService.dohvatiKomentare(objavaId, paginacija);
        }

        [HttpGet]
        [Route("objava"), AllowAnonymous]
        public Objava dohvatiObjavu(Guid objavaId)
        {
            return _objavaService.dohvatiObjavu(objavaId);
        }

        

        [HttpGet]
        [Route("objava/lajk"), AllowAnonymous]
        public IEnumerable<Lajk> dohvatiLajkove(Guid objavaId)
        {
            return _objavaService.dohvatiLajkove(objavaId);
        }

        [HttpDelete]
        [Route("objava"), AllowAnonymous]
        public void obrisiObjavu(Guid objavaId)
        {
            _objavaService.obrisiObjavu(objavaId);
        }

        [HttpDelete]
        [Route("svojaobjava"), AllowAnonymous]
        public void obrisiSvojuObjavu(Guid objavaId)
        {
            _objavaService.obrisiSvojuObjavu(objavaId);
        }

        [HttpDelete]
        [Route("komentar"), AllowAnonymous]
        public void obrisiKomentar(Guid komentarId)
        {
            _objavaService.obrisiKomentar(komentarId);
        }

        [HttpDelete]
        [Route("lajk"), AllowAnonymous]
        public void obrisiLajk(Guid lajkId)
        {
            _objavaService.obrisiLajk(lajkId);
        }
        */
    }
}
