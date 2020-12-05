using System;

namespace Hackathon.AgriFood.Models.Models.Relations
{
    public class CustomerToProduct
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}