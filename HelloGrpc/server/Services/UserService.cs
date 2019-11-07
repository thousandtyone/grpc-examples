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
           var users = GetUsersFromDb();
           foreach(var user in users)
           {
                await Task.Delay(1000);
                await responseStream.WriteAsync(user);
           }
       }


        private List<UserResponse> GetUsersFromDb()
        {
            //This is hardcoded but realistically you would get 
            //this from a database.

           UserResponse user1 = new UserResponse();
           user1.FirstName = "jitu";
           user1.LastName = "pop";
           user1.UserName = "jitu";
           user1.Address = "NA";

           UserResponse user2 = new UserResponse();
           user2.FirstName = "hansa";
           user2.LastName = "pop";
           user2.UserName = "hansa_pop";
           
           UserResponse user3 = new UserResponse();
           user3.FirstName = "test";
           user3.LastName = "pop";
           user3.UserName = "hansa_pop";

           UserResponse user4 = new UserResponse();
           user4.FirstName = "test2";
           user4.LastName = "pop";
           user4.UserName = "hansa_pop";

           UserResponse user5 = new UserResponse();
           user5.FirstName = "test3";
           user5.LastName = "pop";
           user5.UserName = "hansa_pop";

           List<UserResponse> users = new List<UserResponse>();
           users.Add(user1);
           users.Add(user2);
           users.Add(user3);
           users.Add(user4);
           users.Add(user5);
           return users;

        }

    }
}
