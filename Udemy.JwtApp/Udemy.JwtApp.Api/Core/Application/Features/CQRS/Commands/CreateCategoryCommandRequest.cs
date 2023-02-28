using MediatR;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest:IRequest
    {
        public string? Name { get; set; }
    }
}
