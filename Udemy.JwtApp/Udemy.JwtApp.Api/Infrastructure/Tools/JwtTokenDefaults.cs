using System.Text;

namespace Udemy.JwtApp.Api.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer   = "http://localhost";
        public const string Key   = "abdullahabdullah";
        public const int Expire   = 5;
        
    }
}
