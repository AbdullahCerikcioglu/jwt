using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommadRequest>
    {

        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommadRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync2(request.Id);
            if (deletedEntity != null)
            {
                await _repository.RemoveAsync3(deletedEntity);
                
            }
            return Unit.Value;

        }
    }
}
