using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeAsync(string recipeId);
        Task<(List<Recipe>, PaginationData)> GetRecipesAsync(PaginationData paginationData, string searchString = null);
        Task<(List<Recipe>, PaginationData)> GetAllOwnRecipesAsync(string userId, PaginationData paginationData);
        Task<Recipe> CreateNewRecipeAsync(Recipe recipe);
        Task<List<UserRating>> GetAllRatingsForRecipeAsync(string recipeId);
        Task<UserRating> GetUserRatingByUserIdAsync(string recipeId, string userId);
        Task<List<UserComment>> GetAllCommentsForRecipeAsync(string recipeId);
        Task<UserRating> RateRecipeAsync(string userId, string recipeId, RatingEnum rating);
        Task<UserComment> CommentOnRecipeAsync(string userId, string recipeId, string comment);
        Task<Recipe> UpdateRecipeAsync (Recipe recipe);
    }
}
