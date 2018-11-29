using AuthenticationWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            UserContext context = HttpContext.RequestServices.GetService(typeof(AuthenticationWS.Models.UserContext)) as UserContext;
            return context.AuthenticateUser(username, password);
        }

        // GET api/user/username/password
        [HttpGet("{username}/{password}")]
        public int GetUserId(string username, string password)
        {
            UserContext context = HttpContext.RequestServices.GetService(typeof(AuthenticationWS.Models.UserContext)) as UserContext;
            return context.GetUserId(username, password);
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserContext context = HttpContext.RequestServices.GetService(typeof(AuthenticationWS.Models.UserContext)) as UserContext;
            context.CreateUser(user);
        }

    }
}