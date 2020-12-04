using Hackathon.AgriFood.Models.Common.Interfaces;

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
    }
}