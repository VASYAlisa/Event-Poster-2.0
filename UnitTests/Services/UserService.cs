using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Mocks;

namespace UnitTests.Services
{
    public class UserService
    {
        private IDbRepos context;
        public UserService(IDbRepos repos)
        {
            context = repos;
        }

        public bool Authenticate(string username, string password)
        {
            var user = context.Users.GetList().Where(u => u.Password == password && u.UserName == username).FirstOrDefault();
            if (user != null) return true;
            return false;
        }

        //public void Registration(Client client)
        //{

        //}
    }
}
