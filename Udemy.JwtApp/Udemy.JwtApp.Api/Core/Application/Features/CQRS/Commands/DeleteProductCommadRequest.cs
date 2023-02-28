using MediatR;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommadRequest:IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommadRequest(int id)
        {
            Id = id;    
        }
    }
}
