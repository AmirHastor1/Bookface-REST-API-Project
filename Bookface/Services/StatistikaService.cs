using Bookface.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using Bookface.Models;
using Bookface.Models.Enums;

namespace Bookface.Services
{
    public class StatistikaService : IStatistikaService
    {
        private readonly IConfiguration _config;
        private readonly BookfaceAppDBContext _dbContext;

        public StatistikaService(BookfaceAppDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public int DajBrojKorisnika() {
            return _dbContext.Korisnik.Count(k => k.tipKorisnika == TipKorisnika.Korisnik);
        }

        public int DajBrojModeratora() {
            return _dbContext.Korisnik.Count(k => k.tipKorisnika == TipKorisnika.Moderator);
        }

        public int DajBrojAdministratora() {
            return _dbContext.Korisnik.Count(k => k.tipKorisnika == TipKorisnika.Administrator);
        }

    }
}
