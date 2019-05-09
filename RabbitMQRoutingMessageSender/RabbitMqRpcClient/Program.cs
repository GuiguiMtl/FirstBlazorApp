using System;

namespace RabbitMqRpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RpcClient();
            var response = client.Call("30");
            Console.WriteLine(" [.] Got '{0}'", response);
            client.Close();
        }
    }
}
