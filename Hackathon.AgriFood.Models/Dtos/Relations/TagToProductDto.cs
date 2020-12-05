using System;

namespace Hackathon.AgriFood.Models.Dtos.Relations
{
    public class TagToProductDto
    {
        public Guid TagId { get; set; }
        public Guid ProductId { get; set; }
        public TagDto Tag { get; set; }
        public ProductDto Product { get; set; }
    }
}