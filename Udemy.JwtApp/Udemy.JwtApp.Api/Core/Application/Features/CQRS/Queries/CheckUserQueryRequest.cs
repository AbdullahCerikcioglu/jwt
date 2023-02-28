using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
