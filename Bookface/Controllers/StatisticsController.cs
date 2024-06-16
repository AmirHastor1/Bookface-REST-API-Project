using Bookface.Interfaces;
using Bookface.Models.Enums;
using Bookface.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookface.Controllers
{
    [Route("api/statistike")]
    [ApiController]
    [Authorize]
    public class StatistikaController : ControllerBase
    {
        private readonly IStatistikaService _statistikaService;

        public StatistikaController(IStatistikaService statistikaService)
        {
            _statistikaService = statistikaService;
        }

        [HttpGet]
        [Route("brojKorisnika")]
        public int DajBrojKorisnika()
        {
            return _statistikaService.DajBrojKorisnika();     
        }


        [HttpGet]
        [Route("brojModeratora")]
        public int DajBrojModeratora()
        {
            return _statistikaService.DajBrojModeratora();
        }


        [HttpGet]
        [Route("brojAdministratora")]
        public int DajBrojAdministratora()
        {
            return _statistikaService.DajBrojAdministratora();
        }

        
    }
}