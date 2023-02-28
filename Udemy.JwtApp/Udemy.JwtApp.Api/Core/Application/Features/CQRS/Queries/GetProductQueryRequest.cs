using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest: IRequest<ProductListDto> 
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
