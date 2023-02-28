using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _ctgrRepository;
        private readonly IMediator _mediator;
        public CreateCategoryCommandHandler(IRepository<Category> ctgrRepository, IMediator mediator)
        {
            _ctgrRepository = ctgrRepository;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _ctgrRepository.CreateAsync1(new Category
            {
                Name = request.Name,
            });

            return Unit.Value;
        }
    }
}
