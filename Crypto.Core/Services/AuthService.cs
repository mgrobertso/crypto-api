using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Data;
using Crypto.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Crypto.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ILogger<CryptoService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(DataContext context, ILogger<CryptoService> _logger, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            this._logger = _logger;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()) };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7037",
                audience: "https://localhost:7037",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                //token system 
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private bool VeriftyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }


        }

        private void CreatPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public UserDto GetUserId(Guid id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            var mappedUser =_mapper.Map<UserDto>(user);

            if (user == null)
            {
                throw new NotImplementedException();
            }
            return mappedUser;

        }

        public AuthenticatedResponse Login(string Username, string Password)
        {

            var user = _context.Users.Where(user => user.UserName == Username).Select(user => new User
            {
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            }).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("user not found");
            }

            if (user.UserName != Username )
            {
                throw new Exception("User not found.");
            }

            if (!VeriftyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
            {
            throw new Exception("Wrong Password");
            }


            string token = CreateToken(user);
            return (new AuthenticatedResponse { Token = token });

        }



        public async Task<User> Register(CreateUserDto NewUser)
        {
            if (_context.Users.Any(user => user.Email.Equals(NewUser.Email)))
            {
                throw new Exception("User is already Created");
            }
   

            User user = new User();
            user.Id = new Guid();
            user.UserName = NewUser.Username;
            user.Email = NewUser.Email;
            user.FirstName = NewUser.FirstName;
            user.LastName = NewUser.LastName;
            CreatPasswordHash(NewUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

    }

}
