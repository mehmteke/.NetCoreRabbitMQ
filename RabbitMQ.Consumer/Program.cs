using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://ugtyfnnw:UNR12-I4-zKp_dU4mjcmTmuK3PHd3Hz-@rattlesnake.rmq.cloudamqp.com/ugtyfnnw");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);

                    consumer.Received += (model, ea) =>
                     {
                         var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                         Console.WriteLine("Mesaj Alındı:" + message);

                     };

                    Console.WriteLine("Mesajınız Gönderilmiştir.");
                }

                Console.WriteLine("Çıkış yapmak için tıklayınız..");
                Console.ReadLine();
            }
        }
    }
}
