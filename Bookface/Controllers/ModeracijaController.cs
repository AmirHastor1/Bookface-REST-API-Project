using Bookface.Interfaces;
using Bookface.Models;
using Bookface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookface.Controllers
{
    [Route("moderacija")]
    [ApiController]
    [Authorize]
    public class ModeracijaController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        private readonly IObjavaService _objavaService;
        public ModeracijaController(IKorisnikService userService, IObjavaService objavaService)
        {
            _korisnikService = userService;
            _objavaService = objavaService;
        }
        [HttpDelete]
        [Route("korisnik/obrisi")]
        public IActionResult obrisiKorisnika(Guid korisnikId)
        {
            if (Request.Headers.TryGetValue("Authorization", out var authHeader))
            {

                var authorizationKey = authHeader.FirstOrDefault();
                var token = authorizationKey.Replace("Bearer ", string.Empty);


                if (!string.IsNullOrEmpty(authorizationKey))
                {
                    var result = _korisnikService.obrisiKorisnika(korisnikId, token);
                    if (result)
                    {
                        return Ok("User removed");
                    }
                }
            }

            return Unauthorized("Error unauthorized");
        }

        [HttpDelete]
        [Route("objava/obrisi")]
        public IActionResult obrisiObjavu(Guid objavaId)
        {
            if (Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var authorizationKey = authHeader.FirstOrDefault();
                var token = authorizationKey.Replace("Bearer ", string.Empty);

                if (!string.IsNullOrEmpty(authorizationKey))
                {
                    var result = _objavaService.obrisiObjavu(objavaId, token);
                    if (result)
                    {
                        return Ok("Post removed");
                    }
                }
            }

            return Unauthorized("Error");
        }

        [HttpDelete]
        [Route("komentar/obrisi")]
        public IActionResult obiriKomentar(Guid komentarId)
        {
            if (Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var authorizationKey = authHeader.FirstOrDefault();
                var token = authorizationKey.Replace("Bearer ", string.Empty);

                if (!string.IsNullOrEmpty(authorizationKey))
                {
                    var result = _objavaService.obrisiKomentar(komentarId, token);
                    if (result)
                    {
                        return Ok("Comment removed");
                    }
                }
            }

            return Unauthorized("Error");
        }
    }
}
