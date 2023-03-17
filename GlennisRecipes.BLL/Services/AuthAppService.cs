using AutoMapper;
using GlennisRecipes.BLL.Interfaces;
using GlennisRecipes.BLL.ViewModels;
using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Exceptions;
using GlennisRecipes.Model.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenAppService tokenService;
        private readonly IIdentityService identityService;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;

        public AuthAppService (UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                ITokenAppService tokenService,
                                IIdentityService identityService,
                                IAuthRepository authRepository,
                                IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.identityService = identityService;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }

        public async Task<TokenViewModel> Login(LoginViewModel loginDto)
        {
            var storedUser = await userManager.FindByEmailAsync(loginDto.Email);
            if(storedUser == null)
                throw new AuthException("Wrong username or password");
            var result = await signInManager.PasswordSignInAsync(storedUser.UserName, loginDto.Password, true, false);
            if (result.Succeeded)
            {
                return new TokenViewModel
                {
                    AccessToken = await tokenService.CreateNormalAccessToken(storedUser),
                    RefreshToken = await tokenService.CreateNormalRefreshTokenAsync(storedUser)
                };
            }
            throw new AuthException("Wrong username or password");
        }

        public async Task Logout()
        {
            var userId = await identityService.GetCurrentUserIdAsync();
            await signInManager.SignOutAsync();
            await authRepository.RemoveRefreshTokenAsync(userId.ToString());
        }

        public async Task<TokenViewModel> Register(RegisterViewModel registerDto)
        {
            var registerData = mapper.Map<RegisterData>(registerDto);
            await authRepository.RegisterAsync(registerData);

            var storedUser = await userManager.FindByEmailAsync(registerDto.Email);

            return new TokenViewModel
            {
                AccessToken = await tokenService.CreateNormalAccessToken(storedUser),
                RefreshToken = await tokenService.CreateNormalRefreshTokenAsync(storedUser)
            };
        }

        public async Task<TokenViewModel> RenewToken(string refreshToken)
        {
            var user = await authRepository.GetUserByRefreshTokenAsync(refreshToken);

            if (user == null)
            {
                throw new AuthException("There is no user with that specific refresh token");
            }
            return new TokenViewModel
            {
                AccessToken = await tokenService.CreateNormalAccessToken(user),
                RefreshToken = await tokenService.CreateNormalRefreshTokenAsync(user)
            };
        }
    }
}
