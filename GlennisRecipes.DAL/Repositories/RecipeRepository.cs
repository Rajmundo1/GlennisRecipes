using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Enums;
using GlennisRecipes.Model.Exceptions;
using GlennisRecipes.Model.Interfaces;
using GlennisRecipes.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICommonHelper commonHelper;

        public RecipeRepository(ApplicationDbContext dbContext,
                                ICommonHelper commonHelper)
        {
            this.dbContext = dbContext;
            this.commonHelper = commonHelper;
        }
        public async Task<UserComment> CommentOnRecipeAsync(string userId, string recipeId, string comment)
        {
            var newComment = new UserComment
            {
                Id = Guid.NewGuid().ToString(),
                Comment = comment,
                UserId = userId,
                RecipeId = recipeId,
                TimeStamp = DateTime.Now,
            };

            await dbContext.UserComments.AddAsync(newComment);
            await dbContext.SaveChangesAsync();

            return newComment;
        }

        public async Task<Recipe> CreateNewRecipeAsync(Recipe recipe)
        {
            var newRecipe = new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                ImagePath = recipe.ImagePath,
                Instructions = recipe.Instructions,
                Name = recipe.Name,
                OwnerId = recipe.OwnerId
            };

            await dbContext.Recipes.AddAsync(newRecipe);
            await dbContext.SaveChangesAsync();

            return newRecipe;
        }

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
        {
            var storedRecipe = await GetRecipeAsync(recipe.Id);

            storedRecipe.Instructions = recipe.Instructions;
            storedRecipe.Name = recipe.Name;
            storedRecipe.ImagePath = recipe.ImagePath;

            await dbContext.SaveChangesAsync();

            return storedRecipe;
        }

        public async Task<List<UserComment>> GetAllCommentsForRecipeAsync(string recipeId)
        {
            var comments = await dbContext.UserComments
                .Where(rating => rating.RecipeId == recipeId)
                .ToListAsync();

            return comments;
        }

        public async Task<(List<Recipe>, PaginationData)> GetAllOwnRecipesAsync(string userId, PaginationData paginationData)
        {
            var ownRecipes = dbContext.Recipes
                .Where(recipe => recipe.OwnerId == userId);

            var ownRecipeCount = ownRecipes.Count();

            paginationData = commonHelper.CheckForOverPaging(paginationData, ownRecipeCount);

            var pagedOwnRecipes = await ownRecipes
                .Skip((paginationData.Page - 1) * paginationData.ItemPerPage)
                .Take(paginationData.ItemPerPage)
                .ToListAsync();

            return (pagedOwnRecipes, paginationData);
        }

        public async Task<List<UserRating>> GetAllRatingsForRecipeAsync(string recipeId)
        {
            var ratings = await dbContext.UserRatings
                .Where(rating => rating.RecipeId == recipeId)
                .ToListAsync();

            return ratings;
        }

        public async Task<UserRating> GetUserRatingByUserIdAsync(string recipeId, string userId)
        {
            var rating = await dbContext.UserRatings
                .SingleOrDefaultAsync(rating => rating.RecipeId == recipeId && rating.UserId == userId);

            return rating;
        }

        public async Task<(List<Recipe>, PaginationData)> GetRecipesAsync(PaginationData paginationData, string searchString = null)
        {
            var totalRecipeCount = dbContext.Recipes.Count();

            paginationData = commonHelper.CheckForOverPaging(paginationData, totalRecipeCount);

            var pagedRecipes = new List<Recipe>();

            if (!string.IsNullOrEmpty(searchString))
            {
                pagedRecipes = await dbContext.Recipes
                    .Where(recipe => recipe.Name.Contains(searchString))
                    .Skip((paginationData.Page - 1) * paginationData.ItemPerPage)
                    .Take(paginationData.ItemPerPage)
                    .ToListAsync();
            }
            else
            {
                pagedRecipes = await dbContext.Recipes
                    .Where(recipe => recipe.Name.Contains(searchString))
                    .Skip((paginationData.Page - 1) * paginationData.ItemPerPage)
                    .Take(paginationData.ItemPerPage)
                    .ToListAsync();
            }


            return (pagedRecipes, paginationData);
        }

        public async Task<Recipe> GetRecipeAsync(string recipeId)
        {
            var recipe = await dbContext.Recipes
                .Include(recipe => recipe.Owner)
                .Include(recipe => recipe.UserComments)
                .ThenInclude(comments => comments.User)
                .Include(recipe => recipe.UserRatings)
                .SingleOrDefaultAsync(c => c.Id == recipeId);

            if (recipe == null)
                throw new DbException("Content not found");

            return recipe;
        }

        public async Task<UserRating> RateRecipeAsync(string userId, string recipeId, RatingEnum rating)
        {
            var existingRating = await dbContext.UserRatings
                .SingleOrDefaultAsync(rating => rating.UserId == userId && rating.RecipeId == recipeId);

            if(existingRating != null)
            {
                existingRating.Rating = rating;

                await dbContext.SaveChangesAsync();

                return existingRating;
            }

            var newUserRating = new UserRating
            {
                Id = Guid.NewGuid().ToString(),
                Rating = rating,
                RecipeId = recipeId,
                UserId = userId,
            };

            await dbContext.UserRatings.AddAsync(newUserRating);
            await dbContext.SaveChangesAsync();

            return newUserRating;
        }

    }
}
