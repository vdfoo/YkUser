﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YkUser.Model;

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
            User invalidUser = new User()
            {
                Name = "Unauthorized Access"
            };

            if(string.IsNullOrEmpty(user.Id) || string.IsNullOrEmpty(user.Password))
            {
                return invalidUser;
            }

            User authenticatedUser = new User();

            if (user.Id == "1001" && user.Password == "p1001")
            {
                authenticatedUser = new User
                {
                    Id = user.Id,
                    Admin = true,
                    Name = "Daniel - Authenticated"
                };
            }  
            else if (user.Id == "1002" && user.Password == "p1002")
            {
                authenticatedUser = new User
                {
                    Id = user.Id,
                    Admin = false,
                    Name = "Sebastian - Authenticated"
                };
            }
            else if (user.Id == "1003" && user.Password == "p1003")
            {
                authenticatedUser = new User
                {
                    Id = user.Id,
                    Admin = false,
                    Name = "Kelvin - Authenticated"
                };
            }
            else
            {
                authenticatedUser = invalidUser;
            }

            return authenticatedUser;
        }
    }
}
