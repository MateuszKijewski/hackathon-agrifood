using System;

namespace Hackathon.AgriFood.Models.Models.Relations
{
    public class ShopToFarmer
    {
        public Guid ShopId { get; set; }
        public Guid FarmerId { get; set; }
        public Shop Shop { get; set; }
        public Farmer Farmer { get; set; }
    }
}