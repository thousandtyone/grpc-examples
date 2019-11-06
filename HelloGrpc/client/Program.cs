using System;
using System.Net.Http;
using System.Threading.Tasks;

using Grpc.Net.Client;
using HelloGrpc;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = 
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpClientHandler);

            var channel = GrpcChannel.ForAddress("https://localhost:5001",
            new GrpcChannelOptions { HttpClient = httpClient });

            var client =  new Greeter.GreeterClient(channel);
            
            try
            {
            var reply =  await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
