using Hackathon.AgriFood.Models.Common.Interfaces;
using System;

namespace Hackathon.AgriFood.Models.Dtos
{
    public class ProductPhotoDto : EntityBase
    {
        public string Url { get; set; }
        public bool IsMainPhoto { get; set; }
        public Guid? ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}