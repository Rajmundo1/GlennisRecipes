using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserAsync(string Id);
        Task RegisterAsync(RegisterData registerData);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task RemoveRefreshTokenAsync(string userId);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
    }
}
