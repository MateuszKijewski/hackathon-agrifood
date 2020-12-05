using System;

namespace Hackathon.AgriFood.Models.Models.Relations
{
    public class CustomerToFarmer
    {
        public Guid CustomerId { get; set; }
        public Guid FarmerId { get; set; }
        public Customer Customer { get; set; }
        public Farmer Farmer { get; set; }
    }
}