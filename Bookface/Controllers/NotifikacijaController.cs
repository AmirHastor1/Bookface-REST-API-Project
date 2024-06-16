using Bookface.Interfaces;
using Bookface.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Bookface.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotifikacijaService _notifikacijaService;

        public NotificationController(INotifikacijaService notifikacijaService)
        {
            _notifikacijaService = notifikacijaService;
        }

        [HttpGet]
        [Route("user/latest"), AllowAnonymous]
        public ActionResult<IEnumerable<Notifikacija>> dohvatiNajnovijNotifikacije(Guid userId, BigInteger broj)
        {
            try
            {
                var notifikacije = _notifikacijaService.dohvatiNajnovijNotifikacije(userId, broj);
                return Ok(notifikacije);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user/{userId}"), AllowAnonymous]
        public ActionResult<IEnumerable<Notifikacija>> dohvatiNotifikacijes(Guid userId)
        {
            try
            {
                var notifikacije = _notifikacijaService.dohvatiNotifikacije(userId);
                return Ok(notifikacije);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("user/markAsRead")]
        public IActionResult oznaciSveKaoProcitanod(Guid userId)
        {
            try
            {
                _notifikacijaService.oznaciSveKaoProcitano(userId);
                return Ok("All notifications marked as read.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}