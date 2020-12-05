using Hackathon.AgriFood.Models.Common.Interfaces;
using System;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class FarmerPhotoDto : EntityBase
    {
        public string Url { get; set; }
        public bool IsProfilePhoto { get; set; }
        public Guid? FarmerId { get; set; }

        public FarmerDto Farmer { get; set; }

    }
}