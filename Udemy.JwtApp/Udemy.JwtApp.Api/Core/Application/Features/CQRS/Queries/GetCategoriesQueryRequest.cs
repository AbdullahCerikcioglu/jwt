using MediatR;
using System.Collections.Generic;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest:IRequest<List<CategoryListDto>>
    { 
    }
}
