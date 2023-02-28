using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {                                        
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            
           var productdata =  await _repository.GetAllAsync1(); // tüm product verilerinş cektik.
            return _mapper.Map<List<ProductListDto>>(productdata); //gelen productu proustlisdto a cevir

        }
    }
}
