using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Entities
{
    public class UserComment
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Recipe Recipe { get; set; }
        public string RecipeId { get; set; }

    }
}
