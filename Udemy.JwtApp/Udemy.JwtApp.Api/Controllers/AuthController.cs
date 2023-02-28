using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Infrastructure.Tools;

namespace Udemy.JwtApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
           await _mediator.Send(request);
            return Created("", request);
          
        }

        [HttpPost("Login")] //action demek method adını al, ha login yazmışız ha action farketmez.

        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExits)
            {
                

                return Created("", JwtTokenGenerator.GenereateToken(dto));
            }
            else
            {
                return BadRequest("kullanıcı adı veya şifre hatalı.");
            }
            
        }


    }
}
