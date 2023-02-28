using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
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
