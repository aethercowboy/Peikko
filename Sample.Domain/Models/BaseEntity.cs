using Sample.Domain.Interfaces;
using System;

namespace Sample.Domain.Models
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
