using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Tag : EntityBase
    {
        public ICollection<Product> TaggedProducts { get; set; }
    }
}