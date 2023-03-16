using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Exceptions;
using GlennisRecipes.Model.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;

        public AuthRepository(ApplicationDbContext dbContext,
                                UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<User> GetUserAsync(string Id) => await dbContext.Users.SingleOrDefaultAsync(user => user.Id == Id);

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var userToFind = await dbContext.Users.SingleOrDefaultAsync(user => user.RefreshToken == refreshToken);

            if (userToFind == null)
            {
                throw new AuthException("Nobody has that refresh token");
            }
            return userToFind;
        }

        public async Task RegisterAsync(RegisterData registerData)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerData.UserName,
                NormalizedUserName = registerData.UserName,
            };
            try
            {
                var result = await userManager.CreateAsync(user, registerData.Password);
                if (result.Succeeded)
                {
                    await dbContext.SaveChangesAsync();

                    await userManager.AddToRoleAsync(user, "Normal");

                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    var errors = result.Errors.Select(error => error.Description).ToList();
                    throw new AuthException(errors);
                }
            }
            catch (Exception e)
            {
                throw new AuthException(e.Message);
            }
        }

        public async Task RemoveRefreshTokenAsync(string userId)
        {
            await SetRefreshToken(userId, string.Empty);
        }

        public async Task SaveRefreshTokenAsync(User user, string refreshToken)
        {
            await SetRefreshToken(user.Id, refreshToken);
        }

        private async Task SetRefreshToken(string userId, string refreshToken)
        {
            var userToFind = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if (userToFind == null)
            {
                throw new DbException($"User was not found with ID: {userId}");
            }

            userToFind.RefreshToken = refreshToken;
            await dbContext.SaveChangesAsync();
        }
    }
}
