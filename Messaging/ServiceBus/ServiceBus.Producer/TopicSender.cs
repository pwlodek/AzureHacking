using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer
{
    class TopicSender
    {
        private string _connectionString = "Endpoint=sb://piotrwservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=embSACe0jQiiSwWkAu9kAFcKa2vUZ8tEAUDLWggCCmw=";
        private string _queueName = "testtopic";
        private TopicClient _client;

        public TopicSender()
        {
            _client = TopicClient.CreateFromConnectionString(_connectionString, _queueName);
        }

        public void Send(string message)
        {
            var msg = new BrokeredMessage(message);
            _client.Send(msg);
        }

        public void Close()
        {
            _client.Close();
        }
    }
}
