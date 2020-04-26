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
            if(args == null) {
                Console.WriteLine("Args null");
            }
            else {
                args = new string[1];
                args[0] = "100";
            }

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://ugtyfnnw:UNR12-I4-zKp_dU4mjcmTmuK3PHd3Hz-@rattlesnake.rmq.cloudamqp.com/ugtyfnnw");
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicQos(0, 1, false);
                    Console.WriteLine("mesajları bekliyorum....");

                    consumer.Received += (model, ea) =>
                     {
                         var message =  Encoding.UTF8.GetString(ea.Body.ToArray());
                         Console.WriteLine("Mesaj Alındı:" + message);

                         int time = int.Parse(GetMessage(args));
                         Thread.Sleep(time);
                         Console.WriteLine("Mesaj işlendi...");

                         channel.BasicAck(ea.DeliveryTag, false);
                     };

                    channel.BasicConsume("task_queue", false, consumer);

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
