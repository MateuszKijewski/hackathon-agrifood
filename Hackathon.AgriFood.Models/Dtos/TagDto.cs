using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class TagDto : EntityBase
    {
        public IEnumerable<ProductDto> TaggedProducts { get; set; }
    }
}