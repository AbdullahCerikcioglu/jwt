using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;

namespace Udemy.JwtApp.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var productData =  await _mediator.Send(new GetAllProductsQueryRequest());
 
            return Ok(productData);
              
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var firstData = await _mediator.Send(new GetProductQueryRequest(id));
            return firstData == null ? NoContent() : Ok(firstData); //expression seklinde if kontrolü firstdata bos ise notfound dön yoksa firstdatamın içerisindekini dön.200 status code ile.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _mediator.Send(new DeleteProductCommadRequest(id));
            
            return NoContent();
              
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest entity)
        {
           await _mediator.Send(entity);
            return Created("", entity);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateProductCommandRequest Entity)
        {
            await _mediator.Send(Entity);
            return NoContent();
        }



    }
}
