using AutoMapper;
using GlennisRecipes.BLL.Interfaces;
using GlennisRecipes.BLL.ViewModels;
using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Enums;
using GlennisRecipes.Model.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Services
{
    public class RecipeAppService: IRecipeAppService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IAuthRepository authRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public RecipeAppService(IRecipeRepository recipeRepository,
                                IAuthRepository authRepository,
                                UserManager<User> userManager,
                                IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.authRepository = authRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<(List<RecipeViewModel>, PaginationData)> GetRecipesAsync(PaginationData paginationData, string searchString = null)
        {
            var recipes = await recipeRepository.GetRecipesAsync(paginationData, searchString);

            var recipeViewModels = mapper.Map<List<RecipeViewModel>>(recipes.Item1);

            return (recipeViewModels, paginationData);
        }

        public async Task<(List<RecipeViewModel>, PaginationData)> GetAllOwnRecipesAsync(string userId, PaginationData paginationData)
        {
            var recipes = await recipeRepository.GetAllOwnRecipesAsync(userId, paginationData);

            var recipeViewModels = mapper.Map<List<RecipeViewModel>>(recipes.Item1);

            return (recipeViewModels, paginationData);
        }

        public async Task<RecipeDetailsViewModel> UpdateRecipeAsync(string recipeId, RecipeEditViewModel recipeEditViewModel, string imagePath = null)
        {
            var recipe = mapper.Map<Recipe>(recipeEditViewModel);
            recipe.Id = recipeId;

            await recipeRepository.UpdateRecipeAsync(recipe, imagePath);

            return mapper.Map<RecipeDetailsViewModel>(await recipeRepository.GetRecipeAsync(recipe.Id));
        }

        public async Task<RecipeDetailsViewModel> GetRecipeDetailsAsync(string recipeId, string? userId = null)
        {
            var recipe = await recipeRepository.GetRecipeAsync(recipeId);

            var recipeDetailsViewModel = mapper.Map<RecipeDetailsViewModel>(recipe);

            recipeDetailsViewModel.OwnerName = recipe.Owner.UserName;

            if(recipe.UserRatings.Count() != 0)
            {
                var allRatings = recipe.UserRatings;
                recipeDetailsViewModel.OverallRatings = Math.Round((recipe.UserRatings.Sum(r => (int)r.Rating) / (double)recipe.UserRatings.Count()),2);
            }
            else
            {
                recipeDetailsViewModel.OverallRatings = 0;
            }

            recipeDetailsViewModel.AllRatings = recipe.UserRatings.Count();

            if (userId == null)
                recipeDetailsViewModel.OwnRating = 0;
            else
            {
                var ownRating = recipe.UserRatings.SingleOrDefault(rating => rating.UserId == userId);
                if(ownRating == null)
                    recipeDetailsViewModel.OwnRating = 0;
                else
                    recipeDetailsViewModel.OwnRating = (int)ownRating.Rating;
            }

            var userComments = recipe.UserComments;

            recipeDetailsViewModel.UserComments =  mapper.Map<List<UserCommentViewModel>>(userComments);

            return recipeDetailsViewModel;
        }

        public async Task<CreateRecipeViewModel> CreateNewRecipeAsync(CreateRecipeViewModel createRecipeViewModel, string userId, string imagePath)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                ImagePath = imagePath,
                Instructions = createRecipeViewModel.Instructions,
                Name = createRecipeViewModel.Name,
                OwnerId = userId                
            };

            await recipeRepository.CreateNewRecipeAsync(recipe);

            return createRecipeViewModel;
        }

        public async Task DeletePictureFileAsync(string recipeId, string rootPath)
        {
            await recipeRepository.DeletePictureFileAsync(recipeId, rootPath);
        }

        public async Task<UserComment> CommentOnRecipe(string userId, string recipeId, string comment)
        {
            return await recipeRepository.CommentOnRecipeAsync(userId, recipeId, comment);
        }

        public async Task<UserRating> RateRecipe(string userId, string recipeId, RatingEnum rating)
        {
            return await recipeRepository.RateRecipeAsync(userId, recipeId, rating);
        }
    }
}
