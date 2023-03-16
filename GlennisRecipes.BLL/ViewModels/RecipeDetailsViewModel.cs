using GlennisRecipes.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string ImagePath { get; set; }
        public string OwnerName { get; set; }

        public double OverallRatings { get; set; }
        public int OwnRating { get; set; }
        public List<UserCommentViewModel> UserComments { get; set; }
    }
}
