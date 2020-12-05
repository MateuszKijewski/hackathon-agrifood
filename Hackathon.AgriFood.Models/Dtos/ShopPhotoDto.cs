using Hackathon.AgriFood.Models.Common.Interfaces;
using System;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class ShopPhotoDto : EntityBase
    {
        public string Url { get; set; }
        public bool IsMainPhoto { get; set; }
        public bool IsBackgroundPhoto { get; set; }
        public Guid? ShopId { get; set; }

        public ShopDto Shop { get; set; }
    }
}