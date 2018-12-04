using Sample.Domain.Interfaces;

namespace Sample.Domain.Models
{
    public interface IPublisher : IEntity
    {

    }

    public class Publisher : BaseEntity, IPublisher
    {
    }
}