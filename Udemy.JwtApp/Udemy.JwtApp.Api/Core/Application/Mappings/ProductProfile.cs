using AutoMapper;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
