using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class LocalizationDto : EntityBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int? StreetNumber { get; set; }
        public int? LocalNumber { get; set; }

        public IEnumerable<FarmerDto> Farmers { get; set; }
        public IEnumerable<ShopDto> Shops { get; set; }
    }
}