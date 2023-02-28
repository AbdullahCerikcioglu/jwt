namespace Udemy.JwtApp.Api.Core.Application.Dto
{
    public class CheckUserResponseDto
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public bool IsExits { get; set; }
    }
}
