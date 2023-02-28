namespace Udemy.JwtApp.Api.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Product>? Products { get; set; } //bir category birden fazla product temsil eder 

      
    }
}
