using AutoMapper;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
