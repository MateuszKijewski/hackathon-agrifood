using Hackathon.AgriFood.Models.Common.Interfaces;
using System;

namespace Hackathon.AgriFood.Models.Models
{
    public class FarmerPhoto : EntityBase
    {
        public string Url { get; set; }
        public bool IsProfilePhoto { get; set; }
        public Guid? FarmerId { get; set; }

        public Farmer Farmer { get; set; }

    }
}