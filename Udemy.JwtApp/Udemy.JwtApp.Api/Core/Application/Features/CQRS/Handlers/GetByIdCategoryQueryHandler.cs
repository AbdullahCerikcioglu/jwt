using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _RpstrCategory;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(IMapper mapper, IRepository<Category> rpstrCategory)
        {
            _mapper = mapper;
            _RpstrCategory = rpstrCategory;
        }

        public async Task<CategoryListDto> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _RpstrCategory.GetByFilterAsync3(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
            throw new NotImplementedException();
        }
    }
}
