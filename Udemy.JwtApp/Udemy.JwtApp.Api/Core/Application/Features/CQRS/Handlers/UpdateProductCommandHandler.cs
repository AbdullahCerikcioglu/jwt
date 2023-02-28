using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
          var updateData =  await _repository.GetByIdAsync2(request.Id);
            if (updateData != null)
            {
               updateData.CategoryId = request.CategoryId;
               updateData.Price = request.Price;
               updateData.Stock = request.Stock;
               updateData.Name = request.Name;

                await _repository.UpdateAsync2(updateData);
            }
            
            return Unit.Value;
        }
    }
}
