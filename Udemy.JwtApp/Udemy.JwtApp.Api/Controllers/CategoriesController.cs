using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;

namespace Udemy.JwtApp.Api.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categoryData = await _mediator.Send(new GetCategoriesQueryRequest());
            return Ok(categoryData);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var firstData = await _mediator.Send(new GetByIdCategoryQueryRequest(id));
            return firstData == null ? NoContent() : Ok(firstData); //expression seklinde if kontrolü firstdata bos ise notfound dön ,yoksa firstdatamın içerisindekini dön.200 status code ile.
        }

        [HttpPost]

        public async Task<IActionResult> Created(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
             await _mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent();
        }



    }
}
