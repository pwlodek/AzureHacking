using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Consumer
{
    class EventReceiver
    {
        private string _connectionString = "Endpoint=sb://testeventhub111.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tAjPkAV2gM3/ewR55y7Fm+X+wQMhkB1EDW/7VH5dZ2E=";
        private string _eventHubName = "myeventhub";
        private EventHubClient _client;

        public EventReceiver()
        {
            // Create namespace client
            NamespaceManager namespaceClient = NamespaceManager.CreateFromConnectionString(_connectionString);
            namespaceClient.CreateEventHubIfNotExists(_eventHubName);
            
            _client = EventHubClient.CreateFromConnectionString(_connectionString, _eventHubName);
        }

        public void Receive()
        {
            
            _client.GetDefaultConsumerGroup().RegisterProcessor<Processor>(new Lease(), null);
        }

        public void Close()
        {
            
            _client.Close();
        }
    }

    public class Processor : IEventProcessor
    {
        public async Task CloseAsync(PartitionContext context, CloseReason reason)
        {
        }

        public async Task OpenAsync(PartitionContext context)
        {
        }

        public async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            Console.WriteLine("Event");
        }
    }
}
