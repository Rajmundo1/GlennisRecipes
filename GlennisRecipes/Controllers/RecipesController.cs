using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlennisRecipes.DAL;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.BLL.Interfaces;
using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Interfaces;
using GlennisRecipes.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GlennisRecipes.Model.Enums;

namespace GlennisRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeAppService recipeAppService;
        private readonly IIdentityService identityService;
        private readonly IAuthAppService authAppService;


        public RecipesController(IRecipeAppService recipeAppService,
                                    IIdentityService identityService,
                                    IAuthAppService authAppService)
        {
            this.recipeAppService = recipeAppService;
            this.identityService = identityService;
            this.authAppService = authAppService;
        }

        //GET: Recipes
        public async Task<IActionResult> Index(string searchString)
        {
            var recipes = await recipeAppService.GetRecipesAsync(new PaginationData { ItemPerPage = 100, Page = 1 });
            return View(recipes.Item1);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            string userId;
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                userId = await identityService.GetCurrentUserIdAsync();
            }
            else
                userId = null;
            var recipe = await recipeAppService.GetRecipeDetailsAsync(id, userId);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [Authorize]
        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Instructions,ImagePath")] CreateRecipeViewModel recipe)
        {
            if (ModelState.IsValid)
            {
                var userId = await identityService.GetCurrentUserIdAsync();
                await recipeAppService.CreateNewRecipeAsync(recipe, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rate(string recipeId, int rate)
        {
            var userId = await identityService.GetCurrentUserIdAsync();
            await recipeAppService.RateRecipe(userId, recipeId, (RatingEnum)rate);
            return RedirectToAction("Details", new { id = recipeId });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(string recipeId, string comment)
        {
            var userId = await identityService.GetCurrentUserIdAsync();
            await recipeAppService.CommentOnRecipe(userId, recipeId, comment);
            return RedirectToAction("Details", new { id = recipeId });
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeDetails = await recipeAppService.GetRecipeDetailsAsync(id);
            if (recipeDetails == null)
            {
                return NotFound();
            }
            return View(recipeDetails);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Instructions,ImagePath")] RecipeDetailsViewModel recipeDetailsViewModel)
        {
            if (id != recipeDetailsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await recipeAppService.UpdateRecipeAsync(recipeDetailsViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(recipeDetailsViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                await authAppService.Login(loginViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email,Password,UserName")]RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                await authAppService.Register(registerViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(registerViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await authAppService.Logout();
            return RedirectToAction(nameof(Index));
        }

        

        #region Delete Auto Generated
        //// GET: Recipes/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.Recipes == null)
        //    {
        //        return NotFound();
        //    }

        //    var recipe = await _context.Recipes
        //        .Include(r => r.Owner)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(recipe);
        //}

        //// POST: Recipes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.Recipes == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Recipes'  is null.");
        //    }
        //    var recipe = await _context.Recipes.FindAsync(id);
        //    if (recipe != null)
        //    {
        //        _context.Recipes.Remove(recipe);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RecipeExists(string id)
        //{
        //  return (_context.Recipes?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        #endregion
    }
}
