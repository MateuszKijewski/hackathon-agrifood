﻿using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Enums;
using Hackathon.AgriFood.Models.Models.Relations;
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
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ShopPhoto> Photos { get; set; }
        public IEnumerable<ShopToFarmer> Farmers { get; set; }
        public IEnumerable<CustomerToShop> FavoringCustomers { get; set; }
    }
}