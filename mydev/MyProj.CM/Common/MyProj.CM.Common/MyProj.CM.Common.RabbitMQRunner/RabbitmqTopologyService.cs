using MyProj.CM.Common.RabbitMQRunner.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyProj.CM.Common.RabbitMQRunner
{
    public class RabbitmqTopologyService
    {
        private RabbitMQConnectionDetail _rabbitMQConnectionDetail;
        public IConnection GetConnection(RabbitMQConnectionDetail rabbitMQConnectionDetail)
        {
            _rabbitMQConnectionDetail = rabbitMQConnectionDetail;
            var connectionFactory = new ConnectionFactory
            {
                HostName = rabbitMQConnectionDetail.HostName,
                VirtualHost = rabbitMQConnectionDetail.VirtualHost,
                Port = rabbitMQConnectionDetail.Port,
                UserName = rabbitMQConnectionDetail.UserName,
                Password = rabbitMQConnectionDetail.Password
            };
            return connectionFactory.CreateConnection();
        }

        public void CreateMessageDeliveryTopology(IConnection connection,string topologyFileName)
        {
            using(var channel = connection.CreateModel())
            {
                foreach(var setting in ReadTopologySetting(topologyFileName))
                {
                    if (true)
                    {
                        channel.ExchangeDelete(setting.Name);
                        var args = new Dictionary<string, object>();
                        var exchangeType = setting.Type;
                        if(setting.MessageDelayEnable)
                        {
                            //exchangeType = "x-delayed-message";
                            //args.Add("x-delayed-type", setting.Type);
                        }
                        channel.ExchangeDeclare(setting.Name, exchangeType, setting.Durable, setting.AutoDelete, args);
                        if(setting.Queue != null)
                        {
                            foreach(var queue in setting.Queue)
                            {
                                channel.QueueDelete(queue.Name);
                                channel.QueueDeclare(queue.Name, queue.Durable, queue.Exclusive, queue.AutoDelete, queue.Properties);
                                if(queue.RoutingKeys != null)
                                {
                                    foreach(var routingKey in queue.RoutingKeys)
                                    {
                                        channel.QueueBind(queue.Name, setting.Name, routingKey);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<RabbitMQExchange> ReadTopologySetting(string fileName)
        {
            var topicSettings = new List<RabbitMQExchange>();
            using(var streamReader = new StreamReader(Path.Combine(AppContext.BaseDirectory,fileName + ".json")))
            {
                var json = streamReader.ReadToEnd();
                topicSettings = JsonConvert.DeserializeObject<List<RabbitMQExchange>>(json);
            }
            return topicSettings;
        }
    }
}
