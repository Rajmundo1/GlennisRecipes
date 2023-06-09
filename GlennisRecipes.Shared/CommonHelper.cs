﻿using GlennisRecipes.Model.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System;

namespace GlennisRecipes.Shared
{
    public class CommonHelper : ICommonHelper
    {
        public PaginationData CheckForOverPaging(PaginationData paginationData, int itemCount)
        {
            if (itemCount < (paginationData.Page - 1) * paginationData.ItemPerPage)
            {
                paginationData.Page = (itemCount / paginationData.ItemPerPage) + 1;
            }

            paginationData.Total = itemCount;

            return paginationData;
        }
    }
}
