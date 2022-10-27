using System;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ_Test
{
    class Send
    {
        public static void Main()
        {
            string kaynak; 
            Console.Write("Host Name/IP Giriniz: ");
            kaynak = Console.ReadLine();
            var factory = new ConnectionFactory() { HostName = "" + kaynak };
            using (var conn = factory.CreateConnection())
            using (var kanal = conn.CreateModel())
            {
                kanal.QueueDeclare(queue: "Test",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string message = "TestRabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                kanal.BasicPublish(exchange: "",
                                   routingKey: "hello",
                                   basicProperties: null,
                                   body: body);
                Console.WriteLine("[X] Gönder {0}", message);
            }
            Console.WriteLine(" Çıkış İçin Entera Bas.");
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
