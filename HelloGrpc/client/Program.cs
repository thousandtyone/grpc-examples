using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Grpc.Net.Client;
using HelloGrpc;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Loading Users from the database");
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = 
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpClientHandler);

            var channel = GrpcChannel.ForAddress("https://localhost:5001",
            new GrpcChannelOptions { HttpClient = httpClient });

            var client =  new User.UserClient(channel);
            
            try
            {
                
                UserRequest user = new UserRequest() { CompanyName = "SomeCompany "};
                using (var call = client.GetUserDetails(user))
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                            var currentUser = call.ResponseStream.Current;
                            Console.WriteLine(currentUser.FirstName + " " + currentUser.LastName);
                    }
                }
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
