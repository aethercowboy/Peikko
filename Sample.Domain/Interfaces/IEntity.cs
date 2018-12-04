using Peikko.Domain.Interfaces;
using System;

namespace Sample.Domain.Interfaces
{
    public interface IEntity : IEntity<Guid>
    {
    }
}
