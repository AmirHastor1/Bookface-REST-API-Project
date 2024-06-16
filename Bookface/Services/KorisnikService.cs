using Bookface.Interfaces;
using Bookface.Models;
using Bookface.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Bookface.Services

{
    public class KorisnikService : IKorisnikService
    {
        private readonly IConfiguration _config;
        private readonly BookfaceAppDBContext _dbContext;

        public KorisnikService(BookfaceAppDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public void registrujKorisnika(string username, string email, string password, byte[]? image = null)
        {
            if (!DoesUserExist(email, username)) throw new Exception("User already exists");

            if (!IsValidEmail(email)) throw new Exception("Invalid email address");

            if (!IsValidPassword(password)) throw new Exception("Invalid password");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            Korisnik korisnik = new Korisnik
            {
                naziv = username,
                email = email,
                sifraSalt = passwordSalt,
                sifraHash = passwordHash,
                korisnikId = Guid.NewGuid(),
                slikaProfila = image,
                tipKorisnika = TipKorisnika.Korisnik



            };
            _dbContext.Korisnik.Add(korisnik);
            _dbContext.SaveChanges();
        }
        public bool DoesUserExist(string email, string username)
        {
            var emailCheck = _dbContext.Korisnik.FirstOrDefault(x => x.email == email);
            var userCheck = _dbContext.Korisnik.FirstOrDefault(x => x.naziv == username);
            return (emailCheck == null && userCheck == null);
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPassword(string password)
        {
            return password.Length >= 5;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        public bool obrisiKorisnika(Guid korisnikId, string jwt)
        {
            var user = GetUserByJwt(jwt);
            if (user == null)
            {
                Console.WriteLine("jwt nepostoji");
                return false;

            }
            if (user.tipKorisnika != TipKorisnika.Moderator && user.tipKorisnika != TipKorisnika.Administrator)
            {
                Console.WriteLine("Korisnik nije privlegovan");
                return false;
            }

            var korisnik = _dbContext.Korisnik.AsQueryable().FirstOrDefault(k => k.korisnikId == korisnikId);

            if (korisnik == null)
            {
                Console.WriteLine("Korisnik nepostoji za brisanje");

                return false;
            }

            // Obriši korisnika iz baze
            _dbContext.Korisnik.Remove(korisnik);
            _dbContext.SaveChanges();

            return true;
        }


        public string logIn(string email, string password)
        {
            var foundUser = GetUser(email);
            if (foundUser == null) throw new Exception("Wrong credentials");

            if (!VerifyPasswordHash(password, foundUser.sifraHash, foundUser.sifraSalt))
            {
                throw new Exception("Wrong credentials");
            }

            if (foundUser.jwt != null) return foundUser.jwt;

            return CreateToken(foundUser);
        }
        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);

        }
        public void logOut(string jwt)
        {
            var user = GetUserByJwt(jwt);
            if (user == null) throw new Exception("Wrong credentials");

            user.jwt = null;
            _dbContext.Korisnik.Update(user);
            _dbContext.SaveChanges();
        }

        private string CreateToken(Korisnik user)
        {

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var expiryDate = DateTime.Now.AddMinutes(40);
            var token = new JwtSecurityToken(
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.email)
                },
                expires: expiryDate,
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            InitiateToken(user, jwt, expiryDate);
            return jwt;
        }
        public void InitiateToken(Korisnik user, string jwt, DateTime expiry)
        {
            user.jwt = jwt;
            _dbContext.Korisnik.Update(user);
            _dbContext.SaveChanges();
        }

        public Korisnik? GetUser(string Email)
        {
            Console.WriteLine("EMAAIAL IS: " + Email);
            if (!string.IsNullOrEmpty(Email))
                return _dbContext.Korisnik.AsQueryable().FirstOrDefault(x => x.email == Email);
            else
            {
                return null;
            }
        }
        public Korisnik? GetUserByJwt(string jwt)
        {
            return _dbContext.Korisnik.AsQueryable().FirstOrDefault(x => x.jwt == jwt);
        }

        public void izmijeniKorisnika(string jwt, Guid korisnikId, string email,string naziv, bool darkTheme, bool notificationOn, bool twoFAEnabled, byte[]? image = null)
        {
            var user = _dbContext.Korisnik.FirstOrDefault(u => u.korisnikId == korisnikId && u.jwt == jwt);
            if (user != null)
            {
                // Update the user properties
                user.slikaProfila = image;
                user.darkTheme = darkTheme;
                user.notificationsEnabled = notificationOn;
                user.twoFAEnabled = twoFAEnabled;
                user.naziv = naziv;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Validation Failed");

            }
        }

        public Korisnik? dohvatiKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {   
            return _dbContext.Korisnik.AsQueryable().FirstOrDefault(x => x.naziv == korisnickoIme);
        }

    }
}
