using GlennisRecipes.Model.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Shared
{
    public interface ICommonHelper
    {
        PaginationData CheckForOverPaging(PaginationData paginationData, int itemCount);
    }
}
