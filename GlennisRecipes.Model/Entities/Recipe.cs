using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Entities
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string ImagePath { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public List<UserRating> UserRatings { get; set; }
        public List<UserComment> UserComments { get; set; }
    }
}
