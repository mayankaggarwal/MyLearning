﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
             var factory = new ConnectionFactory() { HostName = "13.76.154.218", UserName = "mayankgg", Password="Admin123+" };
             using (var connection = factory.CreateConnection())
             {
                 using (var channel = connection.CreateModel())
                 {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                 }
             }
             Console.WriteLine(" Press [enter] to exit.");
             Console.ReadLine();
        }
    }
}