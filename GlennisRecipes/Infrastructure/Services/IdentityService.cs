﻿using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GlennisRecipes.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpContext context;
        private readonly UserManager<User> userManager;

        public IdentityService(IHttpContextAccessor httpContextAccessor,
                                UserManager<User> userManager)
        {
            this.context = httpContextAccessor.HttpContext;
            this.userManager = userManager;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var id = context.User.Claims.Single(x => x.Type == "id").Value;
            return await userManager.FindByIdAsync(id);
        }

        public async Task<string> GetCurrentUserIdAsync()
        {
            if (context.User == null)
                return null;

            var claim = context.User.Claims.SingleOrDefault(x => x.Type == "id");
            if (claim != null)
                return claim.Value;

            return null;
        }
    }
}
