using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YkUser.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
        public string Password { get; set; }
    }
}
