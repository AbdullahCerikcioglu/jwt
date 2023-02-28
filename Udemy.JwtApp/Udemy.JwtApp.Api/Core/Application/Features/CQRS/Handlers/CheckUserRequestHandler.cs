using MediatR;
using Udemy.JwtApp.Api.Core.Application.Dto;
using Udemy.JwtApp.Api.Core.Application.Features.CQRS.Queries;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _RoleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _RoleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await _userRepository.GetByFilterAsync3(x => x.UserName == request.UserName && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExits = false;

            }
            else
            {
                dto.UserName = user.UserName;
                dto.UserId = user.Id;
                dto.IsExits = true;

                var roleDefinition = await _RoleRepository.GetByFilterAsync3(x => x.Id == user.AppRoleId);

                dto.UserRole = roleDefinition?.Definition;
            }

            return dto;
            

        }
    }
}
