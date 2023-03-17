using AutoMapper;
using GlennisRecipes.BLL.ViewModels;
using GlennisRecipes.Model.DataTransferModels;
using GlennisRecipes.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Recipe, RecipeDetailsViewModel>();
            CreateMap<Recipe, RecipeDetailsViewModel>().ReverseMap();
            CreateMap<UserComment, UserCommentViewModel>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<RegisterViewModel, RegisterData>();
            CreateMap<RecipeEditViewModel, Recipe>();
            CreateMap<RecipeDetailsViewModel,RecipeEditViewModel>();

        }
    }
}
