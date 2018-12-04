using Peikko.Domain.PeikkoDomain.Interfaces;

namespace Peikko.Domain.PeikkoDomain.Models
{
    public interface IPublisher : IEntity
    {

    }

    public class Publisher : BaseEntity, IPublisher
    {
    }
}