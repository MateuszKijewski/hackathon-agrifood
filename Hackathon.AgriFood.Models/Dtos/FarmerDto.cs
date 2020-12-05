using Hackathon.AgriFood.Models.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class FarmerDto : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Guid? LocalizationId { get; set; }

        public LocalizationDto Localization { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<FarmerPhotoDto> Photos { get; set; }
        public IEnumerable<ShopDto> Shops { get; set; }
        public IEnumerable<CustomerDto> FavoringCustomers { get; set; }
    }
}