using Hackathon.AgriFood.Models.Common.Interfaces;
using Hackathon.AgriFood.Models.Models.Relations;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<CustomerToShop> FavoriteShops { get; set; }
        public IEnumerable<CustomerToFarmer> FavoriteFarmers { get; set; }
        public IEnumerable<CustomerToProduct> FavoriteProducts { get; set; }
    }
}