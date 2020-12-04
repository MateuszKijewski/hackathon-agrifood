using System;

namespace Hackathon.AgriFood.Models.Common.Interfaces
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}