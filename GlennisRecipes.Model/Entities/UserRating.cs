using GlennisRecipes.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Entities
{
    public class UserRating
    {
        public string Id { get; set; }
        public RatingEnum Rating { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Recipe Recipe { get; set; }
        public string RecipeId { get; set; }

    }
}
