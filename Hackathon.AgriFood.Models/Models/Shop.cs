using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Enums;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Shop : EntityBase
    {
        public string Slug { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public float? Rating { get; set; }
        public DeliveryMethod? PreferredDeliveryMethod { get; set; }
        public Guid LocalizationId { get; set; }

        public Localization Localization { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}