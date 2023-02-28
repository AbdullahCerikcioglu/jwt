using MediatR;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
