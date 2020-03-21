using AuthenticationWS.Models;
using AuthenticationWS.Repositories;
using AuthenticationWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthenticationWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users/user1/password/password1
        [HttpGet("{username}/password/{password}")]
        public int AuthenticateUser(string username, string password)
        {
            IUserRepository repository =
                    HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            return repository.AuthenticateUser(username, password);
        }

        // GET api/users/user1/username/
        [HttpGet("{userId}/username")]
        public string GetUserName(int userId)
        {
            IUserRepository repository = HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            return repository.GetUserName(userId);
        }

        // GET api/users/user1/password/password1/email
        [HttpGet("{username}/password/{password}/email")]
        public List<object> GetUserIdEmailIsAdmin(string username, string password)
        {
            IUserRepository repository =
                    HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            return repository.GetUserIdEmailIsAdmin(username, password);
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] User user)
        {
            IUserRepository repository =
                    HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            repository.CreateUser(user);
        }
    }
}