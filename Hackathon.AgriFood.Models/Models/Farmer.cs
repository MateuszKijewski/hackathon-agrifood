using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Models.Relations;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Farmer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Guid? LocalizationId { get; set; }

        public Localization Localization { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<FarmerPhoto> Photos { get; set; }
        public ICollection<ShopToFarmer> Shops { get; set; }
        public ICollection<CustomerToFarmer> FavoringCustomers { get; set; }
    }
}