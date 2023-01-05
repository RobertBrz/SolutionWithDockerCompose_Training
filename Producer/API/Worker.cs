using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    internal class Worker  : IHostedService
    {
        private readonly MessageValueObjectRepository _messageValueObjectRepository;

        public Worker(MessageValueObjectRepository messageValueObjectRepository)
        {
            _messageValueObjectRepository = messageValueObjectRepository;
            _messageValueObjectRepository.MigrationCheck();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 82);
            var server = new TcpListener(iPEndPoint);
            server.Start();
            Byte[] bytes = new Byte[256];

            while (true)
            {
                using TcpClient client = server.AcceptTcpClient();
                String data = null;
                NetworkStream stream = client.GetStream();

                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    TestValueObject testValueObject = new TestValueObject() { Message =  data};
                    _messageValueObjectRepository.AddMessage(testValueObject);

                    //data = data.ToUpper();
                    //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    //stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Sent: {0}", data);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
