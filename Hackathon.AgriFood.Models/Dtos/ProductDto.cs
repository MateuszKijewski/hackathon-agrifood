using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Enums;
using Hackathon.AgriFood.Models.Models.Relations;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class ProductDto : EntityBase
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float? Rating { get; set; }
        public int Quantity { get; set; }
        public Origin? Origin { get; set; }
        public Availability? Availability { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public Guid? FarmerId { get; set; }
        public Guid? ShopId { get; set; }

        public FarmerDto Farmer { get; set; }
        public ShopDto Shop { get; set; }
        public IEnumerable<ProductPhotoDto> Photos { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<CustomerDto> FavoringCustomers { get; set; }
    }
}