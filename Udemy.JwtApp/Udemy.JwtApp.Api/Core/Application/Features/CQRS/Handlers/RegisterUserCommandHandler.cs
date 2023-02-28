using MediatR;
using Udemy.JwtApp.Api.Core.Application.Enums;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Commands;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {

        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
           await _repository.CreateAsync1(new AppUser
            {
                Password  = request.Password,
                UserName  = request.UserName,
                AppRoleId = (int)RoleType.member,
            });

            return Unit.Value;


        }
    }
}
