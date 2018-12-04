using Peikko.Domain.PeikkoDomain.Interfaces;
using System;

namespace Peikko.Domain.PeikkoDomain.Models
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
