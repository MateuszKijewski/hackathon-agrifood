using Hackathon.AgriFood.Models.Common.Interfaces;

namespace Hackathon.AgriFood.Models.Models
{
    public class Photo : EntityBase
    {
        public string Url { get; set; }
        public Farmer? Farmer { get; set; }
    }
}