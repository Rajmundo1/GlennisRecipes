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
            var result = await signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, true, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(loginDto.Email);
                return new TokenViewModel
                {
                    AccessToken = await tokenService.CreateNormalAccessToken(user),
                    RefreshToken = await tokenService.CreateNormalRefreshTokenAsync(user)
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
