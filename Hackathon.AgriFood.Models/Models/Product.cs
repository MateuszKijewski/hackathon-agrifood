using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Enums;
using Hackathon.AgriFood.Models.Models.Relations;
using System;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float? Rating { get; set; }
        public int Quantity { get; set; }
        public Origin? Origin { get; set; }
        public Availability? Availability { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public Guid? FarmerId { get; set; }
        public Guid? ShopId { get; set; }

        public Farmer Farmer { get; set; }
        public Shop Shop { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }
        public ICollection<TagToProduct> Tags { get; set; }
        public ICollection<CustomerToProduct> FavoringCustomers { get; set; }
    }
}