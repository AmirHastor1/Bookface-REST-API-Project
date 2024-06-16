using Bookface.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using Bookface.Models;
using Microsoft.AspNetCore.Mvc;
using Bookface.Models.Enums;


namespace Bookface.Services
{
    public class ObjavaService : IObjavaService
    {
        private readonly IConfiguration _config;
        private readonly BookfaceAppDBContext _dbContext;

        public ObjavaService(BookfaceAppDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public void kreirajObjavu(Guid korisnikId, byte[] media, string tekst, string tagovi)
        {
            Objava objava = new Objava
            {
                objavaId = Guid.NewGuid(),
                korisnikId = korisnikId,
                objavaMedia = media,
                objavaTekst = tekst,
                objavaTagovi= tagovi
            };
            _dbContext.Objava.Add(objava);
            _dbContext.SaveChanges();
        }
        public void kreirajKomentar(Guid objavaId, Guid korisnikId, string komentarTeskt, byte[] komentarMedia)
        {

            var user = _dbContext.Korisnik.FirstOrDefault(b => b.korisnikId == korisnikId);
            var blog = _dbContext.Objava.FirstOrDefault(b => b.objavaId == objavaId);

            Komentar comment = new Komentar
            {
                komentarId = Guid.NewGuid(),
                korisnikId = korisnikId,
                objavaId = objavaId,
                imeKorisnika = user.naziv,
                komentarTekst = komentarTeskt,
                komentarMedia = komentarMedia
            };
            if (blog.korisnikId != korisnikId)
            {
                Notifikacija notification = new Notifikacija
                {
                    notifikacijaId = Guid.NewGuid(),
                    vrijemeSlanjaNotifikacije = DateTime.Now,
                    korisnikId = blog.korisnikId,
                    notifikacijaTekst = user.naziv + " commented on your post.",

                };
                _dbContext.Notifikacija.Add(notification);
            }
            _dbContext.Komentar.Add(comment);
            blog.brojKomentara += 1;
            _dbContext.SaveChanges();

        }
        public void kreirajLajk(Guid korisnikId, Guid objavaId)
        {
            var existingLike = _dbContext.Lajk.FirstOrDefault(like => like.korisnikId == korisnikId && like.objavaId == objavaId);
            var blog = _dbContext.Objava.FirstOrDefault(b => b.objavaId == objavaId);
            var user = _dbContext.Korisnik.FirstOrDefault(b => b.korisnikId == korisnikId);

            if (existingLike != null)
            {
                _dbContext.Lajk.Remove(existingLike);
                blog.brojLajkova -= 1;
            }
            else
            {
                Lajk like = new Lajk
                {
                    lajkId = Guid.NewGuid(),
                    korisnikId = korisnikId,
                    objavaId = objavaId
                };
                if (blog.korisnikId != korisnikId)
                {
                    Notifikacija notification = new Notifikacija
                    {
                        notifikacijaId = Guid.NewGuid(),
                        vrijemeSlanjaNotifikacije = DateTime.Now,
                        korisnikId = blog.korisnikId,
                        notifikacijaTekst = user.naziv + " liked your post.",
                        tipNotifikacije = Models.Enums.TipNotifikacije.Lajk

                    };
                    _dbContext.Notifikacija.Add(notification);
                }
                _dbContext.Lajk.Add(like);
                blog.brojLajkova += 1;
            }
            _dbContext.SaveChanges();
        }


        public IEnumerable<Objava> dohvatiObjave()
        {
            return _dbContext.Objava.AsQueryable();
        }

        public bool obrisiObjavu(Guid objavaId, string jwt)
        {
            var user = GetUserByJwt(jwt);
            if (user == null)
            {
                Console.WriteLine("jwt nepostoji");
                return false;

            }
            if (user.tipKorisnika != TipKorisnika.Moderator && user.tipKorisnika != TipKorisnika.Administrator)
            {
                return false;
            }
            var objava = _dbContext.Objava.FirstOrDefault(x => x.objavaId == objavaId);

            if (objava != null)
            {
                _dbContext.Objava.Remove(objava);
                _dbContext.SaveChanges();
                Console.WriteLine("Post removed");
                return true;
            }
            else
            {
                Console.WriteLine("Error: Post does not exist");
                return false;
            }
        }

        public bool obrisiKomentar(Guid komentarId, string jwt)
        {
            var user = GetUserByJwt(jwt);
            if (user == null)
            {
                Console.WriteLine("jwt nepostoji");
                return false;

            }
            if (user.tipKorisnika != TipKorisnika.Moderator && user.tipKorisnika != TipKorisnika.Administrator)
            {
                return false;
            }

            var komentar = _dbContext.Komentar.FirstOrDefault(x => x.komentarId == komentarId);

            if (komentar != null)
            {
                _dbContext.Komentar.Remove(komentar);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                Console.WriteLine("Error: Comment does not exist");
                return false ;
            }
        }

        public IEnumerable<Komentar> dohvatiKomentare(Guid objavaId, int paginacija)
        {
            if (paginacija < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(paginacija),
                    "Pagination (page number) must be greater than or equal to 1.");
            }

            int pageSize = 5; // Number of comments to retrieve per page

            int skip = (paginacija - 1) * pageSize; // Calculate the number of comments to skip

            return _dbContext.Komentar
                .Where(n => n.objavaId == objavaId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Objava> dohvatiObjaveKorisnika(Guid korisnikId, int paginacija)
        {
            if (paginacija < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(paginacija),
                    "Pagination (page number) must be greater than or equal to 1.");
            }

            int pageSize = 5; // Number of objavas to retrieve per page

            int skip = (paginacija - 1) * pageSize; // Calculate the number of objavas to skip

            return _dbContext.Objava
                .Where(n => n.korisnikId == korisnikId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Objava> dohvatiObjave(int paginacija)
        {
            if (paginacija < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(paginacija),
                    "Pagination (page number) must be greater than or equal to 1.");
            }

            int pageSize = 5; // Number of objavas to retrieve per page

            int skip = (paginacija - 1) * pageSize; // Calculate the number of objavas to skip

            return _dbContext.Objava
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<string> vratiOmiljeneTagoveKorisnika(Guid korisnikId)
        {
            // Fetch all posts by the user
            var posts = _dbContext.Objava.Where(o => o.korisnikId == korisnikId).ToList();

            // Extract tags from each post and count their occurrences
            var tagCounts = new Dictionary<string, int>();
            foreach (var post in posts)
            {
                var tags = post.objavaTagovi.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var tag in tags)
                {
                    var trimmedTag = tag.Trim();
                    if (tagCounts.ContainsKey(trimmedTag))
                    {
                        tagCounts[trimmedTag]++;
                    }
                    else
                    {
                        tagCounts[trimmedTag] = 1;
                    }
                }
            }

            // Return the top 2 most frequent tags
            return tagCounts.OrderByDescending(kv => kv.Value).Take(2).Select(kv => kv.Key).ToList();
        }

       public IEnumerable<Objava> dohvatiPreporuceneObjave(Guid korisnikId)
        {
            // Get the user's favorite tags
            var omiljeniTagovi = vratiOmiljeneTagoveKorisnika(korisnikId);

            // Fetch posts containing those tags
            var preporuceneObjave = _dbContext.Objava
                .Where(o => omiljeniTagovi.Any(tag => o.objavaTagovi.Contains(tag)))
                .Take(10)
                .ToList();

            return preporuceneObjave;
        }
        public Korisnik? GetUserByJwt(string jwt)
        {
            return _dbContext.Korisnik.AsQueryable().FirstOrDefault(x => x.jwt == jwt);
        }

    }
}
