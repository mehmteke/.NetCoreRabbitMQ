using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory();
            //factory.Uri = new Uri("amqp://ugtyfnnw:UNR12-I4-zKp_dU4mjcmTmuK3PHd3Hz-@rattlesnake.rmq.cloudamqp.com/ugtyfnnw");
            factory.HostName = "localhost";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "Hello word";
                    var bodyMessage = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, bodyMessage);

                    Console.WriteLine("Mesajınız Gönderilmiştir.");
                }

                Console.WriteLine("Çıkış yapmak için tıklayınız..");
                Console.ReadLine();
            }


        }
    }
}
