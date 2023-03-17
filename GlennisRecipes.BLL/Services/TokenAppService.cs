using GlennisRecipes.BLL.Interfaces;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Services
{
    public class TokenAppService : ITokenAppService
    {
        private readonly IAuthRepository authRepository;
        private readonly IConfiguration configuration;

        public TokenAppService(IAuthRepository authRepository,
                                IConfiguration configuration)
        {
            this.authRepository = authRepository;
            this.configuration = configuration;
        }

        public async Task<string> CreateNormalAccessToken(User user)
        {
            var claims = new[]
{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Authentication")["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               configuration.GetSection("Authentication")["JwtNormal"],
               configuration.GetSection("Authentication")["JwtNormal"],
               claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: creds
            );
            return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<string> CreateNormalRefreshTokenAsync(User user)
        {
            var random = new Random();
            string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 30; ++i)
            {
                int index = (int)(random.NextDouble() * charPool.Length);
                if (index == charPool.Length)
                {
                    --index;
                }
                sb.Append(charPool[index]);
            }
            string refreshToken = sb.ToString();
            await authRepository.SaveRefreshTokenAsync(user, refreshToken);

            return refreshToken;
        }

        public async Task RemoveRefreshToken(string userId)
        {
            await authRepository.RemoveRefreshTokenAsync(userId);
        }
    }
}
