using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.DataTransferModels
{
    public class PaginationData
    {
        public int ItemPerPage { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
