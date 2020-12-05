using System;

namespace Hackathon.AgriFood.Models.Dtos.Relations
{
    public class ShopToFarmerDto
    {
        public Guid ShopId { get; set; }
        public Guid FarmerId { get; set; }
        public ShopDto Shop { get; set; }
        public FarmerDto Farmer { get; set; }
    }
}