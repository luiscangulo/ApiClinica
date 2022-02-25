using ApiClinica.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ApiClinica.Data;
using AutoMapper;
using ApiClinica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiClinica.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public UsuarioRepositorio(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }


        public async Task<string> Login(string emailUsuario, string password)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x=>x.userName.ToLower().Equals(emailUsuario.ToLower()));
            
            if (usuario == null)
            {
                return "nouser";
            }
            else if (!VerificarPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return "wrongpassword";
            }
            else
            {
                return CrearToken(usuario);
            }
        }

        public async Task<string> Register(Usuario usuario, string password)
        {
            try
            {
                if (await UserExiste(usuario.userName))
                {
                    return "existe";
                }

                CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;

                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return CrearToken(usuario);
            }
            catch (Exception)
            {

                return "error";
            }
        }

        public async Task<bool> UserExiste(string emailusuario)
        {
            if (await _db.Usuarios.AnyAsync(x=>x.userName.ToLower().Equals(emailusuario.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.userName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddYears(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
