using System;

namespace Hackathon.AgriFood.Models.Dtos.Relations
{
    public class CustomerToProductDto
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
    }
}