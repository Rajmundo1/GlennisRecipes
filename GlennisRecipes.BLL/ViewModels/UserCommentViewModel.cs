using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL.ViewModels
{
    public class UserCommentViewModel
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public string OwnerName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
