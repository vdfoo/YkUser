using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YkUser.DAL;
using YkUser.Model;

namespace YkUser.Service
{
    public class Authentication
    {
        public User AuthenticationUser(User user)
        {
            User validUser = new User();
            UserDal userDal = new UserDal();
            User databaseUser = userDal.Read(user.Username);
            if(databaseUser.Password.Equals(user.Password))
            {
                validUser = databaseUser;
                validUser.Authenticated = true;
            }

            return validUser;
        }
    }
}
