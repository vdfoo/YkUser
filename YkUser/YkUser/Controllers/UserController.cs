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
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            UserDal dal = new UserDal();
            return dal.ReadAll();
        }

        // GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public User Get(string id)
        {
            UserDal dal = new UserDal();
            return dal.Read(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserDal dal = new UserDal();
            dal.Add(user);
        }

        // PUT: api/User
        [HttpPut]
        public void Put([FromBody] User user)
        {
            UserDal dal = new UserDal();
            dal.Update(user);
        }
    }
}
