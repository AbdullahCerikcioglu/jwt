using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _ctgrRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IRepository<Category> ctgrRepository, IMapper mapper)
        {
            _ctgrRepository = ctgrRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updateEntity = await _ctgrRepository.GetByIdAsync2(request.Id);
            if (updateEntity != null)
            {
                updateEntity.Name = request.Name;
                await _ctgrRepository.UpdateAsync2(updateEntity);
            }
            return Unit.Value;
           
        }
    }
}
