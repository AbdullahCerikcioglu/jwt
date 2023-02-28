using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductListDto>>        
    {
        
    }
}
