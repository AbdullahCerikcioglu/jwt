using AutoMapper;
using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        

        public GetProductQueryHandler(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {

            var firstData =  await _repository.GetByIdAsync2(request.Id);

             var data = _mapper.Map<ProductListDto>(firstData);

            return data;
        }
    }
}
