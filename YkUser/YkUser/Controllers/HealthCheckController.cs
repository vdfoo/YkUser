using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YkUser.DAL;
using YkUser.Model;

namespace YkUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/HealthCheck
        [HttpGet]
        public string Get()
        {
            return "Awesome";
        }

        // GET: api/HealthCheck/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if(id == 1)
            {
                UserDal dal = new UserDal();
                dal.Add(new User() { 
                    Username = "2003",
                    Password = "p2003",
                    Admin = true,
                    Name = "Daniel Foo"
                });

                User user = dal.Read("2003");

                user.Name = "Daniel Foo - updated";
                user.Password = "_p2003";
                dal.Update(user);

                List<User> users = dal.ReadAll();
            }

            return ":)";
        }
    }
}
