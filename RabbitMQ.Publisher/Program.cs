using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ.Publisher
{
    class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://ugtyfnnw:UNR12-I4-zKp_dU4mjcmTmuK3PHd3Hz-@rattlesnake.rmq.cloudamqp.com/ugtyfnnw");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                { 
                    channel.ExchangeDeclare("logs", durable: true, type: ExchangeType.Fanout);
                     
                    string message = GetMessage(args);
                    for (int i = 1; i < 11; i++)
                    { 
                        var bodyByte = Encoding.UTF8.GetBytes($"{message}-{i}");
                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;
                        channel.BasicPublish("logs", routingKey: "", properties, body: bodyByte);
                        Console.WriteLine($"Mesajınız gönderilmiştir:{message}-{i}");
                    }
                }

                Console.WriteLine("Çıkış yapmak için tıklayınız..");
                Console.ReadLine();
            }
        }

        private static string GetMessage(string[] args)
        {
            return args[0].ToString();
        }
    }
}
