﻿using RabbitMQ.Client;
using ContactusDemo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactusDemo.Api.MessageBroker
{
    public class NormalSender : IMessageSender
    {
        public NormalSender(ISendable message, string host, string queue)
        {
            _message = message;
            _host = host;
            _queue = queue;
        }

        private ISendable _message;
        private string _host;
        private string _queue;

        public void SendData()
        {
            var factory = new ConnectionFactory() { HostName = _host };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queue,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(_message.Pack());

                    channel.BasicPublish(exchange: "",
                                         routingKey: _queue,
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
    }
}
