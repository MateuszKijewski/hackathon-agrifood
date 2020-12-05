using System;

namespace Hackathon.AgriFood.Models.Dtos.Relations
{
    public class CustomerToFarmerDto
    {
        public Guid CustomerId { get; set; }
        public Guid FarmerId { get; set; }
        public CustomerDto Customer { get; set; }
        public FarmerDto Farmer { get; set; }
    }
}