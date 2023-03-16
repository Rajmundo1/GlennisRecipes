using GlennisRecipes.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Interfaces
{
    public interface IAuthAppService
    {
        Task<TokenViewModel> Login(LoginViewModel loginDto);
        Task Logout();
        Task<TokenViewModel> Register(RegisterViewModel registerDto);
        Task<TokenViewModel> RenewToken(string refreshToken);
    }
}
