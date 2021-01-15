
using Domain;
using MassTransit;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEventService
    {
        Task PublishEvent();
    }
}
