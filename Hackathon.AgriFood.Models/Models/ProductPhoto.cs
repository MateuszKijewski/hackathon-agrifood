using Hackathon.AgriFood.Models.Common.Interfaces;
using System;

namespace Hackathon.AgriFood.Models.Models
{
    public class ProductPhoto : EntityBase
    {
        public string Url { get; set; }
        public bool IsMainPhoto { get; set; }
        public Guid? ProductId { get; set; }

        public Product Product { get; set; }
    }
}