using Bookface.Interfaces;
using Bookface.Models.Enums;
using Bookface.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookface.Controllers
{
    [Route("api/prijave")]
    [ApiController]
    [Authorize]
    public class PrijavaController : ControllerBase
    {
        private readonly IPrijavaService _prijavaService;

        public PrijavaController(IPrijavaService prijavaService)
        {
            _prijavaService = prijavaService;
        }

        [HttpPost]
        [Route("objava")]
        public IActionResult KreirajPrijavuZaObjavu(Guid objavaId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis)
        {
            try
            {
                _prijavaService.kreirajPrijavuZaObjavu(objavaId, podnosilacPrijaveId, vrstaPrijave, opis);
                return Ok("Prijava za objavu je uspješno kreirana.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("komentar")]
        public IActionResult KreirajPrijavuZaKomentar(Guid komentarId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis)
        {
            try
            {
                _prijavaService.kreirajPrijavuZaKomentar(komentarId, podnosilacPrijaveId, vrstaPrijave, opis);
                return Ok("Prijava za komentar je uspješno kreirana.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("sve")]
        public ActionResult<IEnumerable<Prijava>> DohvatiPrijave()
        {
            try
            {
                var prijave = _prijavaService.dohvatiPrijave();
                return Ok(prijave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{prijavaId}")]
        public IActionResult ObrisiPrijavu(Guid prijavaId)
        {
            try
            {
                _prijavaService.obrisiPrijavu(prijavaId);
                return Ok("Prijava je uspješno obrisana.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}