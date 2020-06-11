using BIED.Messaging.Abstractions;
using System.Threading.Tasks;

namespace NotesService.Messaging
{
    public class DummyMessageProducer : IMessageProducer
    {
        public Task SendAsync<T>(T message, string exchangeName, string routeKey = "", string exchangeType = "topic")
        {
            return Task.CompletedTask;
        }
    }
}