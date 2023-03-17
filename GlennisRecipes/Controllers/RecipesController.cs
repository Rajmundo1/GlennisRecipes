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
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GlennisRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeAppService recipeAppService;
        private readonly IIdentityService identityService;
        private readonly IAuthAppService authAppService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;



        public RecipesController(IRecipeAppService recipeAppService,
                                    IIdentityService identityService,
                                    IAuthAppService authAppService,
                                    IMapper mapper,
                                    IWebHostEnvironment webHostEnvironment)
        {
            this.recipeAppService = recipeAppService;
            this.identityService = identityService;
            this.authAppService = authAppService;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
         }

        //GET: Recipes
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                var recipes = await recipeAppService.GetRecipesAsync(new PaginationData { ItemPerPage = 1000, Page = 1 }, searchString);
                return View(recipes.Item1);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
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
        public async Task<IActionResult> Create([Bind("Name,Instructions")] CreateRecipeViewModel recipe, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid && file != null && file.Length > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = Guid.NewGuid().ToString() + file.FileName;
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var userId = await identityService.GetCurrentUserIdAsync();
                    await recipeAppService.CreateNewRecipeAsync(recipe, userId, fileName);
                    return RedirectToAction(nameof(Index));
                }
                return View(recipe);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rate(string recipeId, int rate)
        {
            try
            {
                var userId = await identityService.GetCurrentUserIdAsync();
                await recipeAppService.RateRecipe(userId, recipeId, (RatingEnum)rate);
                return RedirectToAction("Details", new { id = recipeId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(string recipeId, string comment)
        {
            try
            {
                if (string.IsNullOrEmpty(comment))
                {
                    return RedirectToAction("Details", new { id = recipeId });
                }
                var userId = await identityService.GetCurrentUserIdAsync();
                await recipeAppService.CommentOnRecipe(userId, recipeId, comment);
                return RedirectToAction("Details", new { id = recipeId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            try
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

                return View(mapper.Map<RecipeEditViewModel>(recipeDetails));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Instructions")] RecipeEditViewModel recipeEditViewModel, IFormFile file)
        {
            try
            {
                var modelStates = ModelState.Values.ToList();
                if (modelStates[0].ValidationState == ModelValidationState.Valid &&
                    modelStates[2].ValidationState == ModelValidationState.Valid &&
                    modelStates[3].ValidationState == ModelValidationState.Valid)
                {
                    if(file != null && file.Length > 0 && file.ContentType.Contains("image"))
                    {
                        var fileName = Guid.NewGuid().ToString() + file.FileName;
                        var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        var rootPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
                        await recipeAppService.DeletePictureFileAsync(id, rootPath);
                        await recipeAppService.UpdateRecipeAsync(id, recipeEditViewModel, fileName);
                        return RedirectToAction(nameof(Index));
                    }
                    await recipeAppService.UpdateRecipeAsync(id, recipeEditViewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(recipeEditViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await authAppService.Login(loginViewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,Email,Password")]RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await authAppService.Register(registerViewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(registerViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await authAppService.Logout();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel { Message = ex.Message });
            }

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
