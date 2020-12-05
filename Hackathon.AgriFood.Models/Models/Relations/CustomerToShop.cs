using System;

namespace Hackathon.AgriFood.Models.Models.Relations
{
    public class CustomerToShop
    {
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
        public Customer Customer { get; set; }
        public Shop Shop { get; set; }
    }
}