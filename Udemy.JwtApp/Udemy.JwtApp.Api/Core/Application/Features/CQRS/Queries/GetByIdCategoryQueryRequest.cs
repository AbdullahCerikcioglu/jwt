using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries
{
    public class GetByIdCategoryQueryRequest:IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetByIdCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
