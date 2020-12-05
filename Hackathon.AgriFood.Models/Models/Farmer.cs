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
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<FarmerPhoto> Photos { get; set; }
        public IEnumerable<ShopToFarmer> Shops { get; set; }
        public IEnumerable<CustomerToFarmer> FavoringCustomers { get; set; }
    }
}