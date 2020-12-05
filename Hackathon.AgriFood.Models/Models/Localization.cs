using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Localization : EntityBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int? StreetNumber { get; set; }
        public int? LocalNumber { get; set; }

        public ICollection<Farmer> Farmers { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}