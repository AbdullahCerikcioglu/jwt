using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {

        private readonly IRepository<Category> _RpstrCategory;
        private readonly IMapper _mapper;



        public GetCategoriesQueryHandler(IRepository<Category> rpstrCategory, IMapper mapper)
        {
            _RpstrCategory = rpstrCategory;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var dataCtgr =  await _RpstrCategory.GetAllAsync1();

            return _mapper.Map<List<CategoryListDto>>(dataCtgr);

           

            
            




        }
    }
}
