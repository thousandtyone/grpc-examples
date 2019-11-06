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

        public override Task<UserResponse> GetUserDetails(UserRequest request, ServerCallContext context)
        {
           return Task.FromResult(new UserResponse
            {
                FirstName = "Rajiv Popat"
            });
        }
    }
}
