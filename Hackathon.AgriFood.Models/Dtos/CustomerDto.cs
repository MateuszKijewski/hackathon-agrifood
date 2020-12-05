using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class CustomerDto : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ShopDto> FavoriteShops { get; set; }
        public IEnumerable<FarmerDto> FavoriteFarmers { get; set; }
        public IEnumerable<ProductDto> FavoriteProducts { get; set; }
    }
}