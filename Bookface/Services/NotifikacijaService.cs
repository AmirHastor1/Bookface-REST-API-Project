using Bookface.Interfaces;
using Bookface.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Bookface.Services
{
    public class NotifikacijaService : INotifikacijaService
    {
        private readonly IConfiguration _config;
        private readonly BookfaceAppDBContext _dbContext;

        public NotifikacijaService(BookfaceAppDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public IEnumerable<Notifikacija> dohvatiNotifikacije(Guid korisnikId)
        {
            return _dbContext.Notifikacija
                .Where(n => n.korisnikId == korisnikId)
                .ToList();
        }

        public IEnumerable<Notifikacija> dohvatiNajnovijNotifikacije(Guid korisnikId, BigInteger broj)
        {
            return _dbContext.Notifikacija
                .Where(n => n.korisnikId == korisnikId)
                .OrderByDescending(n => n.vrijemeSlanjaNotifikacije)
                .Take((int)broj)
                .ToList();
        }

        public void oznaciSveKaoProcitano(Guid korisnikId)
        {
            var notifikacije = _dbContext.Notifikacija
                .Where(n => n.korisnikId == korisnikId && n.novaNotifikacija)
                .ToList();

            foreach (var notifikacija in notifikacije)
            {
                notifikacija.novaNotifikacija = false;
            }

            _dbContext.SaveChanges();
        }
    }
}
