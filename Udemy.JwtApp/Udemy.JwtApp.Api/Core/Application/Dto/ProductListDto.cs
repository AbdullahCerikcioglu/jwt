using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Core.Application.Dto
{
    public class ProductListDto
    {
        public int ıd { get; set; }
        public string name { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
        public int categoryıd { get; set; }

        //public static IEnumerable<Product> products { get; set; }
    }
}
