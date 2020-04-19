using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YkUser.Model;
using YkUser.Service;

namespace YkUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        // GET: api/Authenticate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // POST: api/Authenticate
        [HttpPost]
        public User Post([FromBody] User user)
        {
            User unauthorizedUser = new User()
            {
                Name = "Unauthorized Access"
            };

            // Validation
            if(string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return unauthorizedUser;
            }

            // Authentication
            Authentication authentication = new Authentication();
            User authenticatedUser = authentication.AuthenticationUser(user);
            
            // Assert and return
            if(authenticatedUser.Authenticated)
            {
                return authenticatedUser;
            }
            else
            {
                return unauthorizedUser;
            }
        }
    }
}
