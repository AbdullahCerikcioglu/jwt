using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync1(new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            });

            return Unit.Value;
        }
    }
}
