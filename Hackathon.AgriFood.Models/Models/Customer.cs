using Hackathon.AgriFood.Models.Common.Interfaces;
using System.Collections.Generic;

namespace Hackathon.AgriFood.Models.Models
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Shop> FavoriteShops { get; set; }
        public ICollection<Farmer> FavoriteFarmers { get; set; }
    }
}