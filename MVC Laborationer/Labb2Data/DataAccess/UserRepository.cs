using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class UserRepository:IUserRepository
    {
        public void AddNewUser(UserDataModel user)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }
        public UserDataModel GetUserById(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var currentUser = ctx.Users.Include("Albums").Single(u => u.UserId == id);
                return currentUser;
            }
        }
        public UserDataModel LoginUser(UserDataModel user)
        {
            using (TheContext ctx = new TheContext())
            {
                var userToLogin = ctx.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
                return userToLogin;
            }
        }
    }
}
