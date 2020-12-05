using System;

namespace Hackathon.AgriFood.Models.Models.Relations
{
    public class TagToProduct
    {
        public Guid TagId { get; set; }
        public Guid ProductId { get; set; }
        public Tag Tag { get; set; }
        public Product Product { get; set; }
    }
}