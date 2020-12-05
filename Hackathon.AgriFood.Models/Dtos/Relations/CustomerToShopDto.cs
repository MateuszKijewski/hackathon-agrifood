using System;

namespace Hackathon.AgriFood.Models.Dtos.Relations
{
    public class CustomerToShopDto
    {
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
        public CustomerDto Customer { get; set; }
        public ShopDto Shop { get; set; }
    }
}