using GlennisRecipes.BLL.ViewModels;
using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.Interfaces
{
    public interface IRecipeAppService
    {
        Task<(List<RecipeViewModel>, PaginationData)> GetRecipesAsync(PaginationData paginationData, string searchString = null);
        Task<RecipeDetailsViewModel> GetRecipeDetailsAsync(string recipeId, string? userId = null);
        Task<CreateRecipeViewModel> CreateNewRecipeAsync(CreateRecipeViewModel recipe, string userId, string imagePath);
        Task<UserRating> RateRecipe(string userId, string recipeId, RatingEnum rating);
        Task<UserComment> CommentOnRecipe(string userId, string recipeId, string comment);
        Task<(List<RecipeViewModel>, PaginationData)> GetAllOwnRecipesAsync(string userId, PaginationData paginationData);
        Task<RecipeDetailsViewModel> UpdateRecipeAsync (string recipeId, RecipeEditViewModel recipeDetailsViewModel, string imagePath = null);
        Task DeletePictureFileAsync (string recipeId, string rootPath);
    }
}
