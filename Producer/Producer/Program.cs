using System.Net.Sockets;

internal class Program
{
    static TcpClient tcpClient = new TcpClient();

    private static void Main(string[] args)
    {
        while (true)
        {
            if (tcpClient.Connected) Send();
            else
            {
                try
                {
                    tcpClient.Connect("api", 82);
                }
                catch (SocketException e) { 
                Console.WriteLine(e.ToString());    
                }
            }

            Task.Delay(5000).Wait();
        }
    }

    private static void Send()
    {
       Random random= new Random(); 
        string message  = random.Next(0,99).ToString();
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
        NetworkStream stream = tcpClient.GetStream();
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"{message} sent");
    }
}