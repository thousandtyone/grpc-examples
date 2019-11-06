using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace HelloGrpc
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

       public override async Task GetUserDetails(UserRequest request, 
       IServerStreamWriter<UserResponse> responseStream, ServerCallContext context)
       {
           UserResponse user1 = new UserResponse();
           user1.FirstName = "jitu";
           user1.LastName = "pop";
           user1.UserName = "jitu";
           user1.Address = "NA";

           UserResponse user2 = new UserResponse();
           user2.FirstName = "hansa";
           user2.LastName = "pop";
           user2.UserName = "hansa_pop";
           
           List<UserResponse> users = new List<UserResponse>();
           users.Add(user1);
           users.Add(user2);

           foreach(var user in users)
           {
                await responseStream.WriteAsync(user);
           }
       }
    }
}
