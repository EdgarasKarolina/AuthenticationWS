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
    public class UserController : ControllerBase
    {
        // GET api/user/username/password
        [HttpGet("{username}/{password}")]
        public int AuthenticateUser(string username, string password)
        {
            IUserRepository repository = HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            return repository.AuthenticateUser(username, password);
        }

        // GET api/user/username/password
        [HttpGet("userId/{username}/{password}")]
        public List<object> GetUserIdEmailIsAdmin(string username, string password)
        {
            IUserRepository repository = HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            return repository.GetUserIdEmailIsAdmin(username, password);
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] User user)
        {
            IUserRepository repository = HttpContext.RequestServices.GetService(typeof(UserRepository)) as UserRepository;
            repository.CreateUser(user);
        }

    }
}