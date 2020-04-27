using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQ.Consumer
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
                    var queueName = channel.QueueDeclare().QueueName; 
                    channel.QueueBind(queue: queueName, exchange: "logs", routingKey: "");
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, false);
                    
                    Console.WriteLine("Logları bekliyorum....");
                    var consumer = new EventingBasicConsumer(channel);
                     
                    channel.BasicConsume(queueName, false, consumer);

                    consumer.Received += (model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine("Log Alındı:" + message);

                        int time = int.Parse(GetMessage(args));
                        Thread.Sleep(time);
                        Console.WriteLine("Loglama Tamamlandı...");

                        channel.BasicAck(ea.DeliveryTag, multiple: false);
                    };

                    
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
