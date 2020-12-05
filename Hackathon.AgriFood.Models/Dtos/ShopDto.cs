using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Enums;
using Hackathon.AgriFood.Models.Models.Relations;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class ShopDto : EntityBase
    {
        public string Slug { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public float? Rating { get; set; }
        public DeliveryMethod? PreferredDeliveryMethod { get; set; }
        public Guid LocalizationId { get; set; }

        public LocalizationDto Localization { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<ShopPhotoDto> Photos { get; set; }
        public IEnumerable<FarmerDto> Farmers { get; set; }
        public IEnumerable<CustomerDto> FavoringCustomers { get; set; }
    }
}