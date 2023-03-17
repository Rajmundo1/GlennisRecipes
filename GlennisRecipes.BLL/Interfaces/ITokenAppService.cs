using GlennisRecipes.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Interfaces
{
    public interface ITokenAppService
    {
        Task<string> CreateNormalAccessToken(User user);
        Task<string> CreateNormalRefreshTokenAsync(User user);
        Task RemoveRefreshToken(string userId);
    }
}
