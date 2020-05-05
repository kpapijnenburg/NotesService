using BIED.Messaging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesService.IntegrationTests
{
    class DummyMessageProducer : IMessageProducer
    {
        public Task SendAsync<T>(T message, string exchangeName, string routeKey = "", string exchangeType = "topic")
        {
            return Task.CompletedTask;
        }
    }
}
