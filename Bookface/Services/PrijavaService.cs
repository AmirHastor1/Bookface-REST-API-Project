using Bookface.Interfaces;
using Bookface.Models;
using Bookface.Models.Enums;
using Microsoft.EntityFrameworkCore; // Add this for EF Core
using Microsoft.Extensions.Configuration; // Add this for IConfiguration
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this for async/await

namespace Bookface.Services
{
    public class PrijavaService : IPrijavaService
    {
        private readonly IConfiguration _config;
        private readonly BookfaceAppDBContext _dbContext;

        public PrijavaService(BookfaceAppDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public void kreirajPrijavuZaObjavu(Guid objavaId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis)
        {
            Prijava prijava = new Prijava
            {
                prijavaId = Guid.NewGuid(),
                prijavljenaObjavaId = objavaId,
                prijavljeniKomentarId = null,
                podnosilacPrijave = podnosilacPrijaveId, 
                vrstaPrijave = vrstaPrijave,
                opis = opis
            };
            _dbContext.Prijava.Add(prijava);
            _dbContext.SaveChanges();
        }

        public void kreirajPrijavuZaKomentar(Guid komentarId, Guid podnosilacPrijaveId, VrstaPrijave vrstaPrijave, string opis) 
        {
            Prijava prijava = new Prijava
            {
                prijavaId = Guid.NewGuid(),
                prijavljenaObjavaId = null,
                prijavljeniKomentarId = komentarId,
                podnosilacPrijave = podnosilacPrijaveId,
                vrstaPrijave = vrstaPrijave,
                opis = opis
            };

            _dbContext.Prijava.Add(prijava);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Prijava> dohvatiPrijave()
        {
            return _dbContext.Prijava.AsQueryable();
        }

        public void obrisiPrijavu(Guid prijavaId)
        {
            var prijava = _dbContext.Prijava.FirstOrDefault(x => x.prijavaId == prijavaId);
            
            if (prijava != null)
            {
                _dbContext.Prijava.Remove(prijava);
                _dbContext.SaveChanges();
                Console.WriteLine("Report removed");
            }
            else
            {
                Console.WriteLine("Error: Report does not exist");
            }
        }
    }
}
