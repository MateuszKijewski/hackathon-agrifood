using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Models.Relations;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Tag : EntityBase
    {
        public ICollection<TagToProduct> TaggedProducts { get; set; }
    }
}