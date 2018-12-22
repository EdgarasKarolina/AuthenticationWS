﻿using AuthenticationWS.Models;
using System.Collections.Generic;

namespace AuthenticationWS.Repositories.Interfaces
{
    interface IUserRepository
    {
        void CreateUser(User user);
        int AuthenticateUser(string userName, string password);
        List<object> GetUserIdEmailIsAdmin(string userName, string password);
    }
}
