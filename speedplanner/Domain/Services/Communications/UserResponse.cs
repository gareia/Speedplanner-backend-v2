﻿using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class UserResponse:BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource) { }

        public UserResponse(string message) : base(message) { }
    }
}
