using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
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

                //data = data.ToUpper();
                //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                //stream.Write(msg, 0, msg.Length);
                //Console.WriteLine("Sent: {0}", data);
            }
        }
    }
}